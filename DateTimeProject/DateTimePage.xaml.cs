using Microsoft.Maui.Layouts;

namespace DateTimeProject;

public partial class DateTimePage : ContentPage
{
    Label lbl;
    DatePicker dp;
    TimePicker tp;
    AbsoluteLayout abs;

    public DateTimePage() : this(0) // Default to 0 or another value for 'k'
    {
    }

    public DateTimePage(int k)
    {
        lbl = new Label
        {
            BackgroundColor = Color.FromRgb(120, 44, 133),
            Text = "Vali mingi kuup�ev v�i aeg"
        };

        dp = new DatePicker
        {
            MinimumDate = DateTime.Now.AddDays(-10),
            MaximumDate = DateTime.Now.AddDays(10),
            Format = "D"
        };

        dp.DateSelected += Kuupaeva_valik;

        tp = new TimePicker
        {
            Time = new TimeSpan(12, 0, 0)
        };

        tp.PropertyChanged += Aega_valik;

        abs = new AbsoluteLayout { Children = { lbl, dp, tp } };

        AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 10, 200, 50));
        AbsoluteLayout.SetLayoutBounds(dp, new Rect(0.2, 0.2, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(tp, new Rect(0.2, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);

        Content = abs;
    }

    private void Aega_valik(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        lbl.Text = "Oli valitud aeg: " + tp.Time.ToString();
    }

    private void Kuupaeva_valik(object? sender, DateChangedEventArgs e)
    {
        lbl.Text = "Oli valitud kuup�ev: " + e.NewDate.ToString("F");
    }

}
