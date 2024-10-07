using System.IO;
using System.Xml;

namespace DateTimeProject;

public partial class PhoneDialerApp : ContentPage
{
    private const string ContactsFileName = "Contacts.txt";

    public PhoneDialerApp()
    {
        InitializeComponent();
        actionPicker.SelectedIndex = 0;
        ToggleControlsVisibility("Send SMS");
        LoadContacts();
    }

    private void OnActionPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedAction = actionPicker.SelectedItem?.ToString();
        if (selectedAction != null)
        {
            ToggleControlsVisibility(selectedAction);
        }
    }

    private void ToggleControlsVisibility(string action)
    {
        bool isSmsSelected = action == "Send SMS";
        bool isEmailSelected = action == "Send Email";
        bool isCallSelected = action == "Make Call";

        // SMS controls
        smsPhoneNumberLabel.IsVisible = isSmsSelected;
        phoneNumberEntry.IsVisible = isSmsSelected || isCallSelected;
        sendSmsButton.IsVisible = isSmsSelected;

        // Email controls
        emailAddressLabel.IsVisible = isEmailSelected;
        emailEntry.IsVisible = isEmailSelected;
        emailSubjectLabel.IsVisible = isEmailSelected;
        emailSubjectEntry.IsVisible = isEmailSelected;
        emailBodyLabel.IsVisible = isEmailSelected;
        emailBodyEntry.IsVisible = isEmailSelected;
        sendEmailButton.IsVisible = isEmailSelected;

        // Call controls
        callButton.IsVisible = isCallSelected;  // Show button for Call

        // Name and saved contacts visibility
        nameLabel.IsVisible = isSmsSelected || isCallSelected; // Show for SMS and Call
        nameEntry.IsVisible = isSmsSelected || isCallSelected; // Show for SMS and Call
        saveContactButton.IsVisible = isSmsSelected || isCallSelected; // Show for SMS and Call
        contactsPicker.IsVisible = isSmsSelected || isCallSelected; // Show for SMS and Call
    }


    private async void LoadContacts()
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, ContactsFileName);
        if (File.Exists(filePath))
        {
            var contacts = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    contacts.Add(line);
                }
            }
            contactsPicker.ItemsSource = contacts;
        }
    }

    private async void SendSmsButtonClicked(object sender, EventArgs e)
    {
        string phoneNumber = phoneNumberEntry.Text;

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            await DisplayAlert("Error", "Please enter a valid phone number.", "OK");
            return;
        }

        try
        {
            var smsUri = new Uri($"sms:{phoneNumber}");
            await Launcher.Default.OpenAsync(smsUri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to open SMS app: {ex.Message}", "OK");
        }
    }

    private async void SendEmailButtonClicked(object sender, EventArgs e)
    {

        smsPhoneNumberLabel.IsVisible = false;
        emailAddressLabel.IsVisible = false;
        string emailAddress = emailEntry.Text;
        string subject = emailSubjectEntry.Text;
        string body = emailBodyEntry.Text;

        if (string.IsNullOrWhiteSpace(emailAddress))
        {
            await DisplayAlert("Error", "Please enter a valid email address.", "OK");
            return;
        }

        try
        {
            var mailtoUri = new Uri($"mailto:{emailAddress}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}");
            await Launcher.Default.OpenAsync(mailtoUri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to open email app: {ex.Message}", "OK");
        }
    }

    private async void CallButtonClicked(object sender, EventArgs e)
    {
        string phoneNumber = phoneNumberEntry.Text;

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            await DisplayAlert("Error", "Please enter a valid phone number.", "OK");
            return;
        }

        try
        {
            var phoneUri = new Uri($"tel:{phoneNumber}");
            await Launcher.Default.OpenAsync(phoneUri);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to open dialer: {ex.Message}", "OK");
        }
    }

    private async void SaveContactButtonClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text;
        string phoneNumber = phoneNumberEntry.Text;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber))
        {
            await DisplayAlert("Error", "Please enter a valid name and phone number.", "OK");
            return;
        }

        try
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, ContactsFileName);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                await writer.WriteLineAsync($"{name}: {phoneNumber}");
            }

            await DisplayAlert("Success", "Contact saved successfully!", "OK");
            LoadContacts(); // Refresh the contacts after saving
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to save contact: {ex.Message}", "OK");
        }
    }

    private void OnContactsPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (contactsPicker.SelectedItem != null)
        {
            string selectedContact = contactsPicker.SelectedItem.ToString();
            var parts = selectedContact.Split(':');
            if (parts.Length == 2)
            {
                nameEntry.Text = parts[0].Trim();
                phoneNumberEntry.Text = parts[1].Trim();
            }
        }
    }
}
