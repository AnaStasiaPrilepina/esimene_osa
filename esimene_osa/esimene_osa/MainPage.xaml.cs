using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace esimene_osa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Button ent_btn, timer_btn, boxview_btn, datetime_btn, stepslider_btn, rgb_btn, frame_btn, image_btn, valgusfoor_btn, picker_btn;
            InitializeComponent();
            ent_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.White,
            };
            timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.White,
            };
            boxview_btn = new Button
            {
                Text = "BoxView",
                BackgroundColor = Color.White,
            };
            datetime_btn = new Button
            {
                Text = "DateTime",
                BackgroundColor = Color.White,
            };
            stepslider_btn = new Button
            {
                Text = "StepperSlider",
                BackgroundColor = Color.White,
            };
            rgb_btn = new Button
            {
                Text = "RGB task",
                BackgroundColor = Color.Wheat,
            };
            frame_btn = new Button
            {
                Text = "Frame/Grid",
                BackgroundColor= Color.White,
            };
            image_btn = new Button
            {
                Text = "Image Page",
                BackgroundColor = Color.White,
            };
            valgusfoor_btn = new Button
            {
                Text = "Valgusfoor task",
                BackgroundColor = Color.Wheat,
            };
            picker_btn = new Button
            {
                Text = "Picker Page",
                BackgroundColor = Color.White,
            };

            StackLayout st = new StackLayout
            {
                Children = { ent_btn, timer_btn, boxview_btn, datetime_btn, stepslider_btn, rgb_btn, frame_btn, image_btn, valgusfoor_btn, picker_btn }
            };
            st.BackgroundColor = Color.LightBlue;
            Content = st;
            
            ent_btn.Clicked += Ent_btn_Clicked;
            timer_btn.Clicked += Timer_btn_Clicked;
            boxview_btn.Clicked += Boxview_btn_Clicked;
            datetime_btn.Clicked += Datetime_btn_Clicked;
            stepslider_btn.Clicked += Stepslide_btn_Clicked;
            rgb_btn.Clicked += Rgb_btn_Clicked;
            frame_btn.Clicked += Frame_btn_Clicked;
            image_btn.Clicked += Image_btn_Clicked;
            valgusfoor_btn.Clicked += Valgusfoor_btn_Clicked;
            picker_btn.Clicked += Picker_btn_Clicked;
        }

        private async void Picker_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new picker_page());
        }

        private async void Valgusfoor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new valgusfoor_page());
        }

        private async void Image_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new image_page());
        }

        private async void Frame_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new frame_page());
        }

        private async void Rgb_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new rgb_page());
        }

        private async void Stepslide_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new stepperslider());
        }

        private async void Datetime_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new datetime_page());
        }

        private async void Boxview_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new boxview_page());
        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new timer_page());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new entry_page());
        }
    }
}
