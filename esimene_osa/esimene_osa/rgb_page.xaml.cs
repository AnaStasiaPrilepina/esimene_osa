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
    public partial class rgb_page : ContentPage
    {
        Label lbl;
        BoxView rgb_box;
        Slider sld, redSlider, greenSlider, blueSlider;
        public rgb_page()
        {
            lbl = new Label
            {
                Text = "RGB color sliders",
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                TextColor = Color.DarkBlue,
                HorizontalOptions = LayoutOptions.Center,
            };

            rgb_box = new BoxView
            {
                CornerRadius = 10,
                WidthRequest = 300, HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            
            sld = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                MinimumTrackColor = Color.Wheat,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
            };
            sld.ValueChanged += Sld_ValueChanged;

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Red,
                ThumbColor = Color.White,
            };
            redSlider.ValueChanged += Sld_ValueChanged;
            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Green,
                ThumbColor = Color.White,
            };
            greenSlider.ValueChanged += Sld_ValueChanged;
            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Blue,
                ThumbColor = Color.White,
            };
            blueSlider.ValueChanged += Sld_ValueChanged;

            StackLayout st = new StackLayout
            { Children = { lbl, rgb_box, redSlider, greenSlider, blueSlider } };
            Content = st;
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //if (sender == redSlider)
            //{
            //    /*redLabel.Text = String.Format("Red = {0:X2}", (int)args.NewValue)*/;
            //}
            //else if (sender == greenSlider)
            //{
            //    /*greenLabel.Text = String.Format("Green = {0:X2}", (int)args.NewValue)*/;
            //}
            //else if (sender == blueSlider)
            //{
            //    /*blueLabel.Text = String.Format("Blue = {0:X2}", (int)args.NewValue)*/;
            //}
            rgb_box.BackgroundColor = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);
        }
    }
}