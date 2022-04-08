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
        public table_page()
        {
            tabelview = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label = "Nimi:",
                            Placeholder = "Sisesta kontakti nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label = "Telefon:",
                            Placeholder = "Sisesta kontakti number",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label = "Email:",
                            Placeholder = "Sisesta kontakti email",
                            Keyboard = Keyboard.Email
                        },
                    },
                }
            };
            Content = tabelview;
        }
    }
}