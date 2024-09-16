
namespace DateTimeProject;

public partial class PickerImagePage : ContentPage
{
    Grid gr4x1, gr3x3;
    Picker picker;
    Image img;
    Switch s_img, s_grid;
    public PickerImagePage(int k)
    {

        gr4x1 = new Grid
        {
            RowDefinitions =
                {
                    new RowDefinition { Height=new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition { Height=new GridLength(3, GridUnitType.Star) },
                    new RowDefinition { Height=new GridLength(1, GridUnitType.Star) },
                },
            ColumnDefinitions =
                {
                    new ColumnDefinition {Width=new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition {Width=new GridLength (1, GridUnitType.Star) },
                },
        };
        picker = new Picker
        {
            Title = "Images"
        };

        picker.Items.Add("First image");
        picker.Items.Add("Second image");
        picker.Items.Add("Third image");
        picker.SelectedIndexChanged += ImageSelection;

        img = new Image
        {
            Source = "dornet_bot.png"
        };

        s_img = new Switch
        {
            IsToggled = true,
            IsEnabled = true,
            HorizontalOptions = LayoutOptions.Center,
        };
        s_img.Toggled += S_img_Toggled;

        s_grid = new Switch
        {
            IsToggled = false,
            IsEnabled = false,
            HorizontalOptions = LayoutOptions.Center,
        };

        gr4x1.Add(picker, 0, 0);
        gr4x1.Add(img, 0, 1);
        gr4x1.Add(s_img, 0, 3);
        gr4x1.Add(s_grid, 1, 3);

        Content = gr4x1;
    }



    private void S_img_Toggled(object? sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            img.IsVisible = true;
        }
        else
        {
            img.IsVisible = false;
        }
    }

    private void ImageSelection(object? sender, EventArgs e)
        {

        }
    }
