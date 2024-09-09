using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace NewValgusfoor
{
    public partial class MainPage : ContentPage
    {
        private bool TrafficLightOn = false;

        public MainPage()
        {
            InitializeComponent();
        }

        // Sisse Button
        private void SisseButtonClicked(object sender, EventArgs e)
        {
            if (TrafficLightOn== false)
            {
                TrafficLightOn = true;
                ResetLights();
            }
        }

        // Valja Button
        private void ValjaButtonClicked(object sender, EventArgs e)
        {
            TrafficLightOn = false;
            ResetLights();
        }

        // Manually set the color on tap
        private void OnRedLightTapped(object sender, EventArgs e)
        {
            if (TrafficLightOn == true)
            {
                SetLightState(Colors.Red, Colors.Gray, Colors.Gray);
                RedLabel.Text = "Стой";
            }
            else
            {
                RedLabel.Text = "Сначала включи светофор";
            }
        }

        private void OnYellowLightTapped(object sender, EventArgs e)
        {
            if (TrafficLightOn == true)
            {
                SetLightState(Colors.Gray, Colors.Yellow, Colors.Gray);
                YellowLabel.Text = "Внимание";
            }
            else
            {
                YellowLabel.Text = "Сначала включи светофор";
            }
        }

        private void OnGreenLightTapped(object sender, EventArgs e)
        {
            if (TrafficLightOn == true)
            {
                SetLightState(Colors.Gray, Colors.Gray, Colors.Green);
                GreenLabel.Text = "Иди";
            }
            else
            {
                GreenLabel.Text = "Сначала включи светофор";
            }
        }

        // Set the light states for each color
        private void SetLightState(Color red, Color yellow, Color green)
        {
            RedLight.BackgroundColor = red;
            YellowLight.BackgroundColor = yellow;
            GreenLight.BackgroundColor = green;
        }

        // Reset lights to initial state
        private void ResetLights()
        {
            SetLightState(Colors.Gray, Colors.Gray, Colors.Gray);
            RedLabel.Text = "";
            YellowLabel.Text = "";
            GreenLabel.Text = "";
        }
    }
}
