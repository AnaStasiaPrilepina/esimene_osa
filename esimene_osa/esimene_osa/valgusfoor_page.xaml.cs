using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esimene_osa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class valgusfoor_page : ContentPage
    {
        Label lbl;
        Button sisse, valja;
        Frame red_fr, yellow_fr, green_fr;
        public valgusfoor_page()
        {
            lbl = new Label
            {
                Text = "Valgusfoor",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                TextColor = Color.DarkBlue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            sisse = new Button
            {
                Text = "Turn on",
                WidthRequest = 100,
                HeightRequest = 50,
                BackgroundColor = Color.LightBlue,
                BorderColor = Color.Black,
                BorderWidth = 1.5
            };
            valja = new Button
            {
                Text = "Turn off",
                WidthRequest = 100,
                HeightRequest = 50,
                BackgroundColor = Color.LightBlue,
                BorderColor = Color.Black,
                BorderWidth = 1.5
            };
            sisse.Clicked += Sisse_Clicked;
            valja.Clicked += Valja_Clicked;

            red_fr = new Frame
            {
                Content = new Label { Text = "Stop", FontAttributes = FontAttributes.Bold, FontSize = 24, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center },
                BorderColor = Color.Red,
                CornerRadius = 100,
                WidthRequest = 100,
                HeightRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            yellow_fr = new Frame
            {
                Content = new Label { Text = "Ready", FontAttributes = FontAttributes.Bold, FontSize = 24, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center },
                BorderColor = Color.Yellow,
                CornerRadius = 100,
                WidthRequest = 100,
                HeightRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            green_fr = new Frame
            {
                Content = new Label { Text = "Go", FontAttributes = FontAttributes.Bold, FontSize = 24, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center },
                BorderColor = Color.Green,
                CornerRadius = 100,
                WidthRequest = 100,
                HeightRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { lbl, sisse, valja, red_fr, yellow_fr, green_fr }
            };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.5, 0, 100, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(sisse, new Rectangle(0.1, 0.09, 150, 50));
            AbsoluteLayout.SetLayoutFlags(sisse, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(valja, new Rectangle(0.9, 0.09, 150, 50));
            AbsoluteLayout.SetLayoutFlags(valja, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(red_fr, new Rectangle(0.5, 0.3, 150, 150));
            AbsoluteLayout.SetLayoutFlags(red_fr, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(yellow_fr, new Rectangle(0.5, 0.6, 150, 150));
            AbsoluteLayout.SetLayoutFlags(yellow_fr, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(green_fr, new Rectangle(0.5, 0.9, 150, 150));
            AbsoluteLayout.SetLayoutFlags(green_fr, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
            abs.BackgroundColor = Color.LightBlue;

        }

        bool IsAlive = true;

        private void Valja_Clicked(object sender, EventArgs e)
        {
            IsAlive = false;
            red_fr.BackgroundColor = Color.White;
            yellow_fr.BackgroundColor = Color.White;
            green_fr.BackgroundColor = Color.White;
        }

        private void Sisse_Clicked(object sender, EventArgs e)
        {
            IsAlive = true;
            red_fr.BackgroundColor = Color.Silver;
            yellow_fr.BackgroundColor = Color.Silver;
            green_fr.BackgroundColor = Color.Silver;
            TapGestureRecognizer color = new TapGestureRecognizer();
            color.Tapped += Color_Tapped;
            red_fr.GestureRecognizers.Add(color);
            yellow_fr.GestureRecognizers.Add(color);
            green_fr.GestureRecognizers.Add(color);
        }

        private void Color_Tapped(object sender, EventArgs e)
        {
            if (IsAlive)
            {
                if (sender == red_fr)
                {
                    red_fr.BackgroundColor = Color.Red;
                    yellow_fr.BackgroundColor = Color.Silver;
                    green_fr.BackgroundColor = Color.Silver;
                }
                else if (sender == yellow_fr)
                {
                    red_fr.BackgroundColor = Color.Silver;
                    yellow_fr.BackgroundColor = Color.Yellow;
                    green_fr.BackgroundColor = Color.Silver;
                }
                else if (sender == green_fr)
                {
                    red_fr.BackgroundColor = Color.Silver;
                    yellow_fr.BackgroundColor = Color.Silver;
                    green_fr.BackgroundColor = Color.Green;
                }
            }
        }
    }
}