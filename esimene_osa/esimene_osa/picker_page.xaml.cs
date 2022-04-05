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
        //string[] lehed = new string[4] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.google.com" };
        List<string> lehed = new List<string> { "https://tahvel.edu.ee/", "https://moodle.edu.ee/", "https://www.tthk.ee/", "https://www.google.com/" };
        Frame button;
        ImageButton home, back, next;
        Button url;
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
            home.Clicked += Home_Clicked;
            back = new ImageButton
            {
                Source = "back.png",
            };
            back.Clicked += Back_Clicked;
            next = new ImageButton
            {
                Source = "next.jpg"
            };
            next.Clicked += Next_Clicked;

            StackLayout buttons = new StackLayout 
            { 
                Children = {back, home, next},
                Orientation = StackOrientation.Horizontal,
            };

            url = new Button
            {
                Text = "Uus webilehed",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };
            url.Clicked += Url_Clicked;

            button = new Frame
            {
                Content = buttons,
                BorderColor = Color.Black,
                CornerRadius = 30,
                HeightRequest = 50,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            button.GestureRecognizers.Add(swipe);
            st = new StackLayout { Children = { url, button, picker } };
            //st.GestureRecognizers.Add(swipe);
            //picker.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private async void Url_Clicked(object sender, EventArgs e)
        {
            string site = await DisplayPromptAsync("Uus veebileht?", "Sisesta URL", initialValue: "https://", keyboard: Keyboard.Text);
            lehed.Add(site);
            //string site2 = await DisplayPromptAsync("Uus veebileht?", "Sisesta URL", initialValue: "", keyboard: Keyboard.Text);
            //picker.Items.Add(site2);
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = site },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new picker_page());
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