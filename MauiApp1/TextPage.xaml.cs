namespace MauiApp1;

public partial class TextPage: ContentPage
{
	Label lbl;
	Editor editor;
	Button btn_back, btn_next, btn_home;
	HorizontalStackLayout hsl;
    List<string> btns = new List<string> { "BACK", "HOME", "NEXT" };
    public TextPage()
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor = Color.FromRgb(200, 0, 0),
			FontFamily = "OpenSans Semibold"
		};
		editor = new Editor
		{
			Placeholder = "Vihje: Sisesta siia tekst",
			PlaceholderColor = Color.FromRgb(50, 100, 100),
			TextColor = Color.FromRgb(10, 50, 200),
		};

		hsl = new HorizontalStackLayout { };
        for (int i = 0; i < 3; i++)
        {
            Button b = new Button
            {
                Text = btns[i],
                ZIndex = i
            };
			hsl.Add(b);
            b.Clicked += Btn_Clicked;
        }

        VerticalStackLayout vst = new VerticalStackLayout
        {
            Children = { lbl, editor, hsl }
        };
		Content = vst;

    }

    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        btn_back = (Button)sender;
    }

}