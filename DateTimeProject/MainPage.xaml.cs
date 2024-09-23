namespace DateTimeProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnDateTimePageButtonClicked(object sender, EventArgs e)
        {
            // Navigate to DateTimePage using absolute routing
            await Shell.Current.GoToAsync("///DateTimePage");
        }

        private async void OnStepperSliderPageButtonClicked(object sender, EventArgs e)
        {
            // Navigate to StepperSlider_Page using absolute routing
            await Shell.Current.GoToAsync("///StepperSlider_Page");
        }
        private async void OnImagePickerButtonClicked(object sender, EventArgs e)
        {
            // Navigate to StepperSlider_Page using absolute routing
            await Shell.Current.GoToAsync("///PickerImagePage");
        }

        private async void OnRGbSliderButtonClicked(object sender, EventArgs e)
        {
            // Navigate to StepperSlider_Page using absolute routing
            await Shell.Current.GoToAsync("///RGB");
        }


        private async void OnPhoneDialerButtonClicked(object sender, EventArgs e)
        {
            // Navigate to StepperSlider_Page using absolute routing
            await Shell.Current.GoToAsync("///PhoneDialerApp");
        }
    }
}
