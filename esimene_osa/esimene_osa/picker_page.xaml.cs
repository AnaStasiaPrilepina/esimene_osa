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
        List<string> lehed = new List<string> { "https://tahvel.edu.ee/", "https://moodle.edu.ee/", "https://www.tthk.ee/", "https://www.google.com/"};
        Frame button;
        ImageButton home, back, next;
        Button url;
        Entry lisa;
        public picker_page()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };
            
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            //picker.Items.Add("Google");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;

            home = new ImageButton
            {
                Source = "home.png"
            };
            home.Clicked += Buttons_Clicked;
            back = new ImageButton
            {
                Source = "back.png"
            };
            back.Clicked += Buttons_Clicked;
            next = new ImageButton
            {
                Source = "next.jpg"
            };
            next.Clicked += Buttons_Clicked;

            url = new Button
            {
                Text = "+",
                HeightRequest = 20,
                WidthRequest = 40,
            };
            url.Clicked += Buttons_Clicked;
            //url.Clicked += Url_Clicked;
            lisa = new Entry
            {
                Placeholder = "Uus veebileht",
            };
            lisa.Completed += Lisa_Completed;

            StackLayout buttons = new StackLayout 
            { 
                Children = {lisa, url, back, home, next},
                Orientation = StackOrientation.Horizontal,
            };

            button = new Frame
            {
                Content = buttons,
                HeightRequest = 50,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            
            //button.GestureRecognizers.Add(swipe);
            st = new StackLayout { Children = { button, picker } };
            Content = st;
        }

        private void Lisa_Completed(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = "https://" + lisa.Text,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        private async void Buttons_Clicked(object sender, EventArgs e)
        {
            if (sender == url)
            {
                if (lisa.Text != "")
                {
                    lehed.Add("https://" + lisa.Text);
                    picker.Items.Add(lisa.Text);
                    await DisplayAlert("Uus veebileht", "Uus veebiaadress oli lisatud!", "OK");
                }
            }
            else if (sender == next)
            {
                if (webView.CanGoForward)
                {
                    webView.GoForward();
                }
            }
            else if (sender == back)
            {
                if (webView.CanGoBack)
                {
                    webView.GoBack();
                }
            }
            else if (sender == home)
            {
                webView.Source = new UrlWebViewSource { Url = lehed[3] };
            }
        }

        //private async void Url_Clicked(object sender, EventArgs e)
        //{
        //    string site = await DisplayPromptAsync("Uus veebileht?", "Sisesta URL", initialValue: "", keyboard: Keyboard.Text);
        //    lehed.Add(site);
        //    //string site2 = await DisplayPromptAsync("Uus veebileht?", "Sisesta URL", initialValue: "", keyboard: Keyboard.Text);
        //    picker.Items.Add(site);
        //    if (webView != null)
        //    {
        //        st.Children.Remove(webView);
        //    }
        //    webView = new WebView
        //    {
        //        Source = new UrlWebViewSource { Url = site },
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //    };
        //    st.Children.Add(webView);
        //}

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[3] };
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