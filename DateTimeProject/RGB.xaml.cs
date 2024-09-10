namespace DateTimeProject;

public partial class RGB : ContentPage
{

    public RGB()
    {
        InitializeComponent();
    }


    private void SetColor(object sender, ValueChangedEventArgs args)
    {
        Slider target = sender as Slider;
        int value = (int)target.Value;

        // Check which slider has changed
        if (target == sliderRed)
        {
            lblRedValue.Text = value.ToString();
        }
        else if (target == sliderGreen)
        {
            lblGreenValue.Text = value.ToString();
        }
        else if (target == sliderBlue)
        {
            lblBlueValue.Text = value.ToString();
        }
        else if (target == AlphaSlider)
        {
            lblAlphaValue.Text = value.ToString();
        }


        UpdateSwatch();
    }


    private void UpdateSwatch()
    {
        int r = GetColorValue(lblRedValue);
        int g = GetColorValue(lblGreenValue);
        int b = GetColorValue(lblBlueValue);
        int a = GetColorValue(lblAlphaValue);

        // Apply the color with the alpha (transparency) value
        borderSwatch.BackgroundColor = Color.FromRgba(r, g, b, a / 255.0);

        // Update the hex label (without alpha)
        lblHexColor.Text = $"#{r:X2}{g:X2}{b:X2}";
    }
    private int GetColorValue(Label label)
    {
        // Return the parsed integer value or 0 if the value cannot be parsed
        return int.TryParse(label.Text, out int value) ? value : 0;
    }
}