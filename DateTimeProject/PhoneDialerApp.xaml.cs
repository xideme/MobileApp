using Microsoft.Maui.ApplicationModel.Communication;

namespace DateTimeProject;

public partial class PhoneDialerApp : ContentPage
{
    public PhoneDialerApp()
    {
        InitializeComponent();
    }


    async Task RequestPermissions()
    {
        var statusCallPhone = await Permissions.CheckStatusAsync<Permissions.Phone>();
        if (statusCallPhone != PermissionStatus.Granted)
        {
            statusCallPhone = await Permissions.RequestAsync<Permissions.Phone>();
        }

        var statusSendSms = await Permissions.CheckStatusAsync<Permissions.Sms>();
        if (statusSendSms != PermissionStatus.Granted)
        {
            statusSendSms = await Permissions.RequestAsync<Permissions.Sms>();
        }
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        // Reset the entry fields based on the selected action
        switch (actionPicker.SelectedItem.ToString())
        {
            case "Call":
                smsMessageEntry.IsVisible = false;
                emailEntry.IsVisible = false;
                emailSubjectEntry.IsVisible = false;
                emailBodyEntry.IsVisible = false;
                break;
            case "Send SMS":
                smsMessageEntry.IsVisible = true;
                emailEntry.IsVisible = false;
                emailSubjectEntry.IsVisible = false;
                emailBodyEntry.IsVisible = false;
                break;
            case "Send Email":
                smsMessageEntry.IsVisible = false;
                emailEntry.IsVisible = true;
                emailSubjectEntry.IsVisible = true;
                emailBodyEntry.IsVisible = true;
                break;
        }
    }

    private async void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        string action = actionPicker.SelectedItem?.ToString();

        switch (action)
        {
            case "Call":
                await OnCallButtonClicked(sender, e);
                break;
            case "Send SMS":
                await OnSendSmsButtonClicked(sender, e);
                break;
            case "Send Email":
                await OnSendEmailButtonClicked(sender, e);
                break;
        }
    }

    // Event handler for when the Call button is clicked
    private async Task OnCallButtonClicked(object sender, EventArgs e)
    {
        string phoneNumber = phoneNumberEntry.Text;

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            DisplayAlert("Error", "Please enter a valid phone number.", "OK");
            return;
        }

        try
        {
            if (PhoneDialer.Default.IsSupported)
            {
                PhoneDialer.Default.Open(phoneNumber);
            }
            else
            {
                DisplayAlert("Error", "Phone dialing is not supported on this device.", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Unable to dial the number: {ex.Message}", "OK");
        }
    }

    // Event handler for when the Send SMS button is clicked
    private async Task OnSendSmsButtonClicked(object sender, EventArgs e)
    {
        string phoneNumber = phoneNumberEntry.Text; // or get from another entry
        string message = smsMessageEntry.Text; // assume you have a separate entry for SMS

        if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(message))
        {
            await DisplayAlert("Error", "Please enter a valid phone number and message.", "OK");
            return;
        }

        try
        {
            // Use Sms.ComposeAsync to send the SMS
            var smsMessage = new SmsMessage(message, new List<string> { phoneNumber });
            await Sms.Default.ComposeAsync(smsMessage);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to send SMS: {ex.Message}", "OK");
        }
    }
    // Event handler for when the Send Email button is clicked
    private async Task OnSendEmailButtonClicked(object sender, EventArgs e)
    {
        string emailAddress = emailEntry.Text; // Get the email address
        string subject = emailSubjectEntry.Text; // Get the subject
        string body = emailBodyEntry.Text; // Get the body

        if (string.IsNullOrWhiteSpace(emailAddress) || string.IsNullOrWhiteSpace(body))
        {
            await DisplayAlert("Error", "Please enter a valid email address and message body.", "OK");
            return;
        }

        try
        {
            var emailMessage = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = new List<string> { emailAddress }
            };

            await Email.Default.ComposeAsync(emailMessage);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to send email: {ex.Message}", "OK");
        }
    }


}
