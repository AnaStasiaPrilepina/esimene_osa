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
        //List<string> lehed = new List<string> {"leht1", "leht2", "leht3" };
        Frame button;
        Grid gr;
        Editor ed;
        Label lb;
        Button save;
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

            ed = new Editor
            {
                Placeholder = "Sisesta siia teksti",
                BackgroundColor = Color.White,
                TextColor = Color.Red
            };
            ed.TextChanged += Ed_TextChanged;
            lb = new Label
            {
                Text = "Mingi tekst",
                TextColor = Color.DarkBlue
            };
            save = new Button
            {
                Text = "enter"
            };
            //save.Clicked += Save_Clicked;
            gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { },
                    new RowDefinition { }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { },
                    new ColumnDefinition { }
                }
            };
            gr.Children.Add(ed, 0, 0);
            gr.Children.Add(lb, 0, 1);
            gr.Children.Add(save, 1, 0);

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
            st = new StackLayout { Children = { button, gr, picker } };
            //st.GestureRecognizers.Add(swipe);
            //picker.GestureRecognizers.Add(swipe);
            Content = st;
        }
        
        //private void Save_Clicked(object sender, EventArgs e) { }

        int i = 0;
        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if (key == 'A')
            {
                i++;
                lb.Text = key.ToString() + ": " + i;
            }
            ed.TextChanged += Ed_TextChanged;
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