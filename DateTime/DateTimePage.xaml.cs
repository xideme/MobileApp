namespace DateTime;
using Microsoft.Maui.Layouts;

public partial class DateTimePage : ContentPage
{
    Label lbl;
    DatePicker dp;
    TimePicker tp;
    AbsoluteLayout abs;
    public DateTimePage(int k)
    {
        lbl = new Label
        {
            BackgroundColor = Color.FromRgb(12, 44, 135),
            Text = "Vali mingi kuupäaev või aeg"
        };
        dp = new DatePicker
        {
            MinimumDate = DateTime.Now.AddDays(-10),
            MaximumDate = DateTime.Now.AddDays(10),
            Format = "D"
        };
        tp = new TimePicker
        {
            Time = new TimeSpan(12, 0, 0)
        };
        abs = new AbsoluteLayout { Children = { lbl, dp, tp } };
        AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 10, 100, 50));
        AbsoluteLayout.SetLayoutBounds(dp, new Rect(0.1, 0.2, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
        Content = abs;
    }
}