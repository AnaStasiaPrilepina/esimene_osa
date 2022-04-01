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
    public partial class picker_page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        string[] lehed = new string[4] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.google.com" };
        Frame frame;
        ImageButton home, back, next;
        public picker_page()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Google");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            //webView.GestureRecognizers.Add(swipe);

            home = new ImageButton
            {
                Source = "home.png",
            };
            back = new ImageButton
            {
                Source = "back.png",
            };
            next = new ImageButton
            {
                Source = "next.jpg"
            };
            StackLayout buttons = new StackLayout 
            { 
                Children = {back, home, next},
                Orientation = StackOrientation.Horizontal,
            };

            frame = new Frame
            {
                Content = buttons,
                BorderColor = Color.Black,
                CornerRadius = 30,
                HeightRequest = 50,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            frame.GestureRecognizers.Add(swipe);
            st = new StackLayout { Children = { frame, picker } };
            //st.GestureRecognizers.Add(swipe);
            //picker.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] } ;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex]},
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }
    }
}