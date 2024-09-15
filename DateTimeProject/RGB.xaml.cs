using Microsoft.Maui.Controls.Shapes;

namespace DateTimeProject;

public partial class RGB : ContentPage
{
    public RGB()
    {
        InitializeComponent();
    }

    private void SetColor(object triger, ValueChangedEventArgs args)
    {
        Slider target = triger as Slider; //identify the specific slider that triggered the event 
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
        else if (target == roundSlider) //adjust the corner radius
        {
            lblRoundValue.Text = value.ToString();
            SetSwatchCornerRadius(value); //update corner radius based on the slider value
        }

        UpdateSwatch();
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

    private int GetColorValue(Label label)
    {
        // Return the parsed integer value or 0
        return int.TryParse(label.Text, out int value) ? value : 0; //If true, the method returns the integer value (value).
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
