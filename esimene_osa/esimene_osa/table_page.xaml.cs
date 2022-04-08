using Plugin.Messaging;
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
    public partial class table_page : ContentPage
    {
        TableView tabelview;
        EntryCell nimi, telefon, email;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        ViewCell vc, vc1;
        Entry tel_nr_email, text;
        Button call, sms, mail;
        public table_page()
        {
            tel_nr_email = new Entry { Placeholder = "Kirjuta siia telefoninumber"};
            text = new Entry { Placeholder = "Kirjuta text siia"};
            
            call = new Button { Text = "Helista"};
            call.Clicked += Call_Clicked;
            sms = new Button { Text = "Saada sms"};
            sms.Clicked += Sms_Clicked;
            mail = new Button { Text = "Saada kirja"};
            mail.Clicked += Mail_Clicked;

            StackLayout btn = new StackLayout { Children = { call, sms, mail }, Orientation = StackOrientation.Horizontal};
            StackLayout ent = new StackLayout { Children = { tel_nr_email, text }, Orientation = StackOrientation.Horizontal };
            vc = new ViewCell();
            vc.View = btn;
            vc1 = new ViewCell();
            vc1.View = ent;

            sc = new SwitchCell { Text = "Rohkem..." };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("rgb_triangle.png"),
                Text = "Foto nimetus",
                Detail = "Foto kirjeldus",
            };

            nimi = new EntryCell
            {
                Label = "Nimi:",
                Placeholder = "Sisesta kontakti nimi",
                Keyboard = Keyboard.Default
            };
            telefon = new EntryCell
            {
                Label = "Telefon:",
                Placeholder = "Sisesta kontakti number",
                Keyboard = Keyboard.Telephone
            };
            email = new EntryCell
            {
                Label = "Email:",
                Placeholder = "Sisesta kontakti email",
                Keyboard = Keyboard.Email
            };
            fotosection = new TableSection();

            tabelview = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        nimi
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        telefon,
                        email,
                        sc
                    },
                    fotosection
                }
            };
            Content = tabelview;
        }

        private void Mail_Clicked(object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(tel_nr_email.Text, "Tervitus!", text.Text);
            }
        }

        private void Sms_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr_email.Text, text.Text);
            }
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel_nr_email.Text);
            }
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto:";
                fotosection.Add(ic);
                fotosection.Add(vc1);
                fotosection.Add(vc);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(vc1);
                fotosection.Remove(ic);
                fotosection.Remove(vc);
                sc.Text = "Rohkem...";
            }
        }
    }
}