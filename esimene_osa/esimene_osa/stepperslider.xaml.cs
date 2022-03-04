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
    public partial class stepperslider : ContentPage
    {
        Label lbl;
        Slider sld;
        Stepper stp;
        public stepperslider()
        {
            lbl = new Label
            {
                Text = "...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            sld = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                MinimumTrackColor = Color.Blue,
                MaximumTrackColor = Color.Green,
                ThumbColor = Color.Red,
            };
            sld.ValueChanged += Sld_ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stp.ValueChanged += Stp_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { sld, lbl, stp }
            };
            Content = st;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue;
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue;
        }
    }
}