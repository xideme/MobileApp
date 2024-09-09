namespace DateTimeProject;

public partial class StepperSlider_Page : ContentPage
{
    AbsoluteLayout abs;
    Label lbl;

    public StepperSlider_Page()
	{
        lbl = new Label
        {
            Text = "...",
            BackgroundColor=Color.FromRgb(120, 144, 133) 
        };

        Slider sl = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 30,
            MinimumTrackColor = Color.FromRgb(55, 55, 55),
            MaximumTrackColor = Color.FromRgb(0, 0, 0),
            ThumbColor = Color.FromRgb(155, 155, 155)
        };

        sl.ValueChanged += Sl_ValueChanged;

        Stepper stp = new Stepper
        {
            Minimum = 0,
            Maximum = 100,
            Increment = 1,
            HorizontalOptions = LayoutOptions.Center,
        };

        abs = new AbsoluteLayout { Children = {lbl, sl, stp} };
        AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 100, 300, 50));
        AbsoluteLayout.SetLayoutBounds(sl, new Rect(10, 300, 300, 50));
        AbsoluteLayout.SetLayoutBounds(stp, new Rect(10, 100, 300, 50));
        Content = abs;
    }

    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        lbl.Text = string.Format("{0:F1}", e.NewValue);
        lbl.FontSize=e.NewValue;
        lbl.Rotation=e.NewValue;
    }
}