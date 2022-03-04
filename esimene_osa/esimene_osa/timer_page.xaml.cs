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
    public partial class timer_page : ContentPage
    {
        public timer_page()
        {
            InitializeComponent();
        }
        bool onoff = true;
        private async void ShowTime()
        {
            while (onoff)
            {
                timer_btn.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void timer_btn_Clicked(object sender, EventArgs e)
        {
            if (onoff)
            { onoff = false; }
            else
            { onoff = true; 
            ShowTime();}
        }
    }
    //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    //{
    //    lbl.Text = "Vajutatud";
    //}
}