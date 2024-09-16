using Microsoft.Maui.Controls.Shapes;

namespace DateTimeProject;

public partial class RGB : ContentPage
{
    public RGB()
    {
        InitializeComponent();
    }

    private void SetColor(Slider values, double newValue)
    {
        int value = (int)newValue;  // Convert the slider value to an integer

        // Check which slider is being updated
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
        else if (values == roundSlider) // Update the corner radius
        {
            lblRoundValue.Text = value.ToString();
            SetSwatchCornerRadius(value);  // Set the corner radius based on the slider value
        }

        UpdateSwatch();  // Update the swatch color based on the new slider values
    }

    private int GetColorValue(Label label)
    {

        return int.Parse(label.Text); //the method returns the integer value (value).
    }

    private void UpdateSwatch()
    {
        int r = GetColorValue(lblRedValue);
        int g = GetColorValue(lblGreenValue);
        int b = GetColorValue(lblBlueValue);

        
        borderSwatch.BackgroundColor = Color.FromRgb(r, g, b); //apply the color

        //update the hex label
        lblHexColor.Text = $"#{r:X2}{g:X2}{b:X2}"; //format specifier. X converts the integer to a hexadecimal string,
                                                   //and 2 specifies that the result should be at least two digits long
    }


    //method to set the StrokeShape's CornerRadius of borderSwatch
    private void SetSwatchCornerRadius(int value)
    {
        //Specifies that the border should be a rounded rectangle.
        borderSwatch.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(value)
        };
    }
}
