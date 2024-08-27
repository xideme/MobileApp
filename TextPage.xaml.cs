
namespace MobileApp1;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor ed;
	Button btn_back, btn_forward, btn_home;
	HorizontalStackLayout hsl;
	List<string> buttons=new List<string> { "Tagasi", "Avaleht", "Edasi"};

    public TextPage()
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor = Color.FromRgb(200, 0, 0),
			FontFamily = "BungeeTint Regular"
		};
		ed = new Editor
		{
			Placeholder = "Sisesta Siis tekst",
			PlaceholderColor = Color.FromRgb(50,100,100),
			TextColor = new Color(255,255,255),
			BackgroundColor= Color.FromRgb(10,50,10),


		};
		hsl = new HorizontalStackLayout { };
		for (int i = 0; i < 3; i++)
		{
			Button b = new Button
			{
				Text = buttons[i],
			};
			hsl.Add(b);
		}

		VerticalStackLayout vst = new VerticalStackLayout
		{
			Children = { lbl, ed, hsl },

		};
	}
}