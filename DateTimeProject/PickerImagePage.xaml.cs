
namespace DateTimeProject;

public partial class PickerImagePage : ContentPage
{
	Grid gr4x1, gr3x3;
	Picker picker;
	Image img;
	Switch s_pilt, s_grid;
	public PickerImagePage(int k)
	{
		gr4x1 = new Grid
		{
            RowDefinitions =
			{
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
			},
			ColumnDefinitions =
			{
				new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star) }
            }
		};
		picker = new Picker();
		{
			Title = "Pildid";
		};
		picker.Items.Add("1. Pilt");
		picker.Items.Add("2. Pilt");
		picker.Items.Add("3. Pilt");
		picker.SelectedIndexChanged += Piltide_Valik;
		s_pilt.Toggled += Kuva_Peida_pilt;
		img = new Image
		{
			Source = "dotnet_bot.png"
		};
		s_pilt = new Switch
		{
			IsToggled = true,
			IsEnabled = true
		};
		s_grid = new Switch
		{
			IsToggled= true,
			IsEnabled = true
		};

		gr4x1.Add(picker, 0, 0);
		gr4x1.Add(img, 0, 1);
		gr4x1.Add(s_pilt, 0, 3);
		gr4x1.Add(s_grid, 1, 3);

		Content = gr4x1;
	}

    private void Kuva_Peida_pilt(object? sender, ToggledEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Piltide_Valik(object? sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}