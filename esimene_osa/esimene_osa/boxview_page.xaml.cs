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
    public partial class boxview_page : ContentPage
    {
        BoxView box;
        public boxview_page()
        {
            InitializeComponent();

            int r = 0; 
            int g = 0; 
            int b = 0;
            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 10,
                WidthRequest = 200, HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout { Children = { box} };
            Content = st;
        }
        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0,255), rnd.Next(0,255), rnd.Next(0,255));
        }
    }
}