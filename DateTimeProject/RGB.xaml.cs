using Microsoft.Maui.Controls.Shapes;

namespace DateTimeProject;

public partial class RGB : ContentPage
{
    public RGB()
    {
        InitializeComponent();


    }

    // This method should only update the current slider's value, not recursively call itself
    private void SetColor(object values, ValueChangedEventArgs e)
    {
        Slider slider = values as Slider;
        int value = (int)e.NewValue;

        if (values == sliderRed)
        {
            lblRedValue.Text = value.ToString();
        }
        else if (values == sliderGreen)
        {
            lblGreenValue.Text = value.ToString();
        }
        else if (values == sliderBlue)
        {
            lblBlueValue.Text = value.ToString();
        }
        else if (values == roundSlider)
        {
            lblRoundValue.Text = value.ToString();
            SetSwatchCornerRadius(value);
        }

        sliderRed.ValueChanged += SetColor;
        sliderGreen.ValueChanged += SetColor;
        sliderBlue.ValueChanged += SetColor;

        // Update the swatch color after setting values
        UpdateSwatch();
    }

    private int GetColorValue(Label label)
    {
        return int.Parse(label.Text);
    }

    private void UpdateSwatch()
    {
        int r = GetColorValue(lblRedValue);
        int g = GetColorValue(lblGreenValue);
        int b = GetColorValue(lblBlueValue);



        // Apply the RGB color to the swatch
        borderSwatch.BackgroundColor = Color.FromRgb(r, g, b);

        // Update the hex label to display the color
        lblHexColor.Text = $"#{r:X2}{g:X2}{b:X2}";
    }

    // This method sets the corner radius of the border based on the roundSlider's value
    private void SetSwatchCornerRadius(int value)
    {
        borderSwatch.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(value)
        };
    }
}
