using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ValgusfoorApp
{
    public partial class Content : ContentPage
    {
        private bool isTrafficLightOn = false;
        private int currentLight = 0; // 0 - red, 1 - yellow, 2 - green

        public Content()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private async void OnSisseButtonClicked(object sender, EventArgs e)
        {
            if (!isTrafficLightOn)
            {
                isTrafficLightOn = true;
                await RunTrafficLight();
            }
        }

        private void OnValjaButtonClicked(object sender, EventArgs e)
        {
            isTrafficLightOn = false;
            ResetLights();
        }

        private async Task RunTrafficLight()
        {
            while (isTrafficLightOn)
            {
                switch (currentLight)
                {
                    case 0: // Red
                        SetLightState(Colors.Red, Colors.Gray, Colors.Gray);
                        await Task.Delay(3000); // 3 seconds
                        break;
                    case 1: // Yellow
                        SetLightState(Colors.Gray, Colors.Yellow, Colors.Gray);
                        await Task.Delay(2000); // 2 seconds
                        break;
                    case 2: // Green
                        SetLightState(Colors.Gray, Colors.Gray, Colors.Green);
                        await Task.Delay(4000); // 4 seconds
                        break;
                }

                currentLight = (currentLight + 1) % 3; // Move to the next light
            }
        }

        private void SetLightState(Color red, Color yellow, Color green)
        {
            RedLight.BackgroundColor = red;
            YellowLight.BackgroundColor = yellow;
            GreenLight.BackgroundColor = green;
        }

        private void ResetLights()
        {
            SetLightState(Colors.Gray, Colors.Gray, Colors.Gray);
            currentLight = 0;
        }

        // Обработчики нажатий на световые секции
        private void OnRedLightTapped(object sender, EventArgs e)
        {
            if (isTrafficLightOn)
            {
                RedLabel.Text = "Стой";
            }
            else
            {
                RedLabel.Text = "Сначала включи светофор";
            }
        }

        private void OnYellowLightTapped(object sender, EventArgs e)
        {
            if (isTrafficLightOn)
            {
                YellowLabel.Text = "Внимание";
            }
            else
            {
                YellowLabel.Text = "Сначала включи светофор";
            }
        }

        private void OnGreenLightTapped(object sender, EventArgs e)
        {
            if (isTrafficLightOn)
            {
                GreenLabel.Text = "Иди";
            }
            else
            {
                GreenLabel.Text = "Сначала включи светофор";
            }
        }
    }
}