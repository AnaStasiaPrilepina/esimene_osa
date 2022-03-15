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
        Frame gr_fr;
        Button on, off;
        BoxView red_box, yellow_box, green_box;
        Label red_lbl, yellow_lbl, green_lbl;
        Grid gr;
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

            on = new Button
            {
                Text = "On",
                WidthRequest = 50,
                HeightRequest = 50,
                BackgroundColor = Color.Silver
            };
            off = new Button
            {
                Text = "Off",
                WidthRequest = 50,
                HeightRequest = 50,
                BackgroundColor = Color.Silver
            };
            on.Clicked += On_Clicked;
            off.Clicked += On_Clicked;

            gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { },      // int top = 0
                    new RowDefinition { },      // int top = 1
                    new RowDefinition { },      // int top = 2
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { },        // int left = 0
                }
            };

            gr.Children.Add(red_box = new BoxView
            {
                Color = Color.LightGray,
                CornerRadius = 100,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 0);
            gr.Children.Add(red_lbl = new Label
            {
                Text = "red",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            }, 0, 0);

            gr.Children.Add(yellow_box = new BoxView
            {
                Color = Color.LightGray,
                CornerRadius = 100,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 1);
            gr.Children.Add(yellow_lbl = new Label
            {
                Text = "yellow",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            }, 0, 1);

            gr.Children.Add(green_box = new BoxView
            {
                Color = Color.LightGray,
                CornerRadius = 100,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }, 0, 2);
            gr.Children.Add(green_lbl = new Label
            {
                Text = "green",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            }, 0, 2);

            gr_fr = new Frame
            {
                Content = gr,
                BorderColor = Color.Black,
                CornerRadius = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Wheat
            };

            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { lbl, on, off, gr_fr },
            };
            Content = abs;

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.5, 0, 100, 75));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(on, new Rectangle(0.1, 0.05, 75, 75));
            AbsoluteLayout.SetLayoutFlags(on, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(off, new Rectangle(0.9, 0.05, 75, 75));
            AbsoluteLayout.SetLayoutFlags(off, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(gr_fr, new Rectangle(0.5, 1.5, 300, 700));
            AbsoluteLayout.SetLayoutFlags(gr_fr, AbsoluteLayoutFlags.PositionProportional);
        }

        bool onoff = false;
        bool IsAlive = false;
        private async void showtime()
        {
            TapGestureRecognizer color = new TapGestureRecognizer();
            color.Tapped += Color_Tapped;
            red_box.GestureRecognizers.Add(color);
            yellow_box.GestureRecognizers.Add(color);
            green_box.GestureRecognizers.Add(color);

            while (onoff == true)
            {
                red_box.Color = Color.Red;
                await Task.Delay(500);
                red_box.Color = Color.LightGray;
                await Task.Delay(500);
                if (onoff == false)
                {
                    color.Tapped -= Color_Tapped;
                    break;
                }
                yellow_box.Color = Color.Yellow;
                await Task.Delay(500);
                yellow_box.Color = Color.LightGray;
                await Task.Delay(500);
                if (onoff == false)
                {
                    //color.Tapped -= Color_Tapped;
                    break;
                }
                green_box.Color = Color.Green;
                await Task.Delay(500);
                green_box.Color = Color.LightGray;
                await Task.Delay(500);
                if (onoff == false)
                {
                    //color.Tapped -= Color_Tapped;
                    break;
                }
            }
        }

        private void On_Clicked(object sender, EventArgs e)
        {
            if (sender == on)
            {
                onoff = true;
                IsAlive = true;
                showtime();
            }
            else if (sender == off)
            {
                onoff = false;
                IsAlive = false;
                red_lbl.Text = "red";
                red_box.Color = Color.LightGray;
                yellow_lbl.Text = "yellow";
                yellow_box.Color = Color.LightGray;
                green_lbl.Text = "green";
                green_box.Color = Color.LightGray;
            }
        }

        private void Color_Tapped(object sender, EventArgs e)
        {
            if (IsAlive == true)
            {
                onoff = false;
                red_lbl.Text = "STOP";
                yellow_lbl.Text = "READY";
                green_lbl.Text = "GO";

                if (sender == red_box)
                {
                    red_box.Color = Color.Red;
                    yellow_box.Color = Color.LightGray;
                    green_box.Color = Color.LightGray;
                }
                else if (sender == yellow_box)
                {
                    red_box.Color = Color.LightGray;
                    yellow_box.Color = Color.Yellow;
                    green_box.Color = Color.LightGray;
                }
                else if (sender == green_box)
                {
                    red_box.Color = Color.LightGray;
                    yellow_box.Color = Color.LightGray;
                    green_box.Color = Color.Green;
                }
            }
        }
    }
}