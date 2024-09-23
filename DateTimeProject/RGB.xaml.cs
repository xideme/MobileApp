using Microsoft.Maui.Controls.Shapes;

namespace DateTimeProject;

public partial class RGB : ContentPage
{
    public RGB()
    {
        InitializeComponent();

        // attach the SetColor as the event handler for ValueChanged event 

        sliderRed.ValueChanged += SetColor;
        sliderGreen.ValueChanged += SetColor;
        sliderBlue.ValueChanged += SetColor;
        roundSlider.ValueChanged += SetColor;


    }

    // method should only update the current slider value
    private void SetColor(object values, ValueChangedEventArgs e)
    {
        Slider slider = (Slider)values;
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

        // update the swatch color after setting values
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



        //apply the RGB color to the swatch
        borderSwatch.BackgroundColor = Color.FromRgb(r, g, b);

        //update the hex label
        lblHexColor.Text = $"#{r:X2}{g:X2}{b:X2}";
    }

    //sets the corner radius of the border based on the roundSlider's value
    private void SetSwatchCornerRadius(int value)
    {
        borderSwatch.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(value)
        };
    }
}
