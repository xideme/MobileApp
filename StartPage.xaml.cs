namespace MobileApp1;

public partial class StartPage : ContentPage
{
	List<ContentPage> lehed = new List<ContentPage>() { new TextPage(), new Figures()};
	List<string> tekstid=new List<string> { "Tee lahti TextPage", "Tee lahti Figures" };
	ScrollView sv;
	VerticalStackLayout vst;

	public StartPage()
	{
		//InitializeComponent();
		vst = new VerticalStackLayout { BackgroundColor=Color.FromRgb(180,120,20)};
		for (int i=0;  i < tekstid.Count; i++) 
		{
			Button nupp = new Button
			{
				Text = tekstid[i],
				BackgroundColor = Color.FromRgb(50, 200, 10),
				TextColor = Color.FromRgb(40, 155, 124),
				FontFamily = "Bungee Tint Regular",
				BorderWidth = 10,
				ZIndex= i
			};
			vst.Add(nupp);
            nupp.Clicked += Nupp_Clicked;
		}
		sv = new ScrollView { Content = vst };
		Content= sv;
	}

    private async void Nupp_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
		await Navigation.PushAsync(lehed[btn.ZIndex]);
    }
}