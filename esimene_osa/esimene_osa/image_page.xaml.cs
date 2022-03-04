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
    public partial class image_page : ContentPage
    {
        Switch sw;
        Image img;
        public image_page()
        {
            img = new Image { Source = "rgb_cube.png" };
            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            tap2.Tapped += Tap2_Tapped;
            tap2.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap2);

            sw = new Switch
            {
                IsToggled = true,          //pozicija vidgeta - on / off
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center,
            };
            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = {sw,img}};
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
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

        int taps;
        private void Tap2_Tapped(object sender, EventArgs e)
        {
            taps++;
            var imgsender = (Image)sender;
            //if (taps % 2 == 0);
            //{
            //    img.Source = "rgb_circle.png";
            //}
            if (taps % 2 != 0) ;
            {
                img.Source = "rgb_triangle.png";
            }
        }
    }
}