using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace topwtuka
{
    public partial class MainPage : ContentPage
    {
        private bool ButtonSisseClicked = false;
        private bool ButtonVäljaClicked = false;
        public MainPage()
        {
            InitializeComponent();
            punaneFrame.BackgroundColor = Color.LightGray;
            kollaneFrame.BackgroundColor = Color.LightGray;
            rohelineFrame.BackgroundColor = Color.LightGray;

            punaneFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Viga", "Esiteks lülitada valgusfoor", "Ok");
                        return;
                    }
                    punaneFrame.BackgroundColor = Color.Red;
                    punaneLabel.Text = "Stop";
                    punaneLabel.FontSize = 15;
                    punaneLabel.TextColor = Color.Black;
                })
            });

            kollaneFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Viga", "Esiteks lülitada valgusfoor", "Ok");
                        return;
                    }
                    kollaneFrame.BackgroundColor = Color.Yellow;
                    kollaneLabel.Text = "Oota";
                    kollaneLabel.FontSize = 15;
                    kollaneLabel.TextColor = Color.Black;
                })
            });

            rohelineFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonSisseClicked)
                    {
                        DisplayAlert("Viga", "Esiteks lülitada valgusfoor", "Ok");
                        return;
                    }
                    rohelineFrame.BackgroundColor = Color.Green;
                    rohelineLabel.Text = "Sõida";
                    rohelineLabel.FontSize = 15;
                    rohelineLabel.TextColor = Color.Black;
                })
            });

            ButtonSisse.Clicked += OnButtonSisseClicked;

            ButtonVälja.Clicked += OnButtonVäljaClicked;

            ButtonTagasi.Clicked += OnButtonTagasiClicked;
        }

        private async void OnButtonTagasiClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void OnButtonSisseClicked(object sender, EventArgs e)
        {
            ButtonSisseClicked = true;

            punaneFrame.BackgroundColor = Color.Red;
            kollaneFrame.BackgroundColor = Color.Yellow;
            rohelineFrame.BackgroundColor = Color.Green;
        }

        private void OnButtonVäljaClicked(object sender, EventArgs e)
        {
            ButtonVäljaClicked = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Foori väljalülitamine", "Kas tahaksite foori välja lülitada?", "Jah", "Ei");

                if (answer == true)
                {
                    ButtonSisseClicked = false;

                    ButtonSisse.BackgroundColor = Color.LightGray;

                    punaneFrame.BackgroundColor = Color.LightGray;
                    kollaneFrame.BackgroundColor = Color.LightGray;
                    rohelineFrame.BackgroundColor = Color.LightGray;

                    punaneLabel.Text = "punane";
                    punaneLabel.FontSize = 15;
                    kollaneLabel.Text = "kollane";
                    kollaneLabel.FontSize = 15;
                    rohelineLabel.Text = "roheline";
                    rohelineLabel.FontSize = 15;

                    lbl3.Text = "Lülitage valgusfoor sisse";
                }
                else
                {
                    ButtonVäljaClicked = false;
                    ButtonSisseClicked = true;

                }
            });
        }
    }
}
