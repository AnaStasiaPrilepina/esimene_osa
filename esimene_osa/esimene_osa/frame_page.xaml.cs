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
    public partial class frame_page : ContentPage
    {
        Frame Frame;
        Label lbl;
        Grid grid;
        public frame_page()
        {
            lbl = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Title,typeof(Label))
            };
            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },        // int top = 0
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },        // int top = 1
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }         // int top = 2
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(2,GridUnitType.Star) },       // int left = 0
                    new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star) }        // int left = 0
                }
            };
            grid.Children.Add(new BoxView { Color = Color.Red }, 0, 0);                //grid.Children.Add( BoxView{color} , int left , int top);
            grid.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.Blue }, 0, 1);
            grid.Children.Add(new BoxView { Color = Color.Yellow }, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.Pink }, 0, 2);
            grid.Children.Add(new BoxView { Color = Color.Beige }, 1, 2);

            Frame = new Frame
            {
                Content = grid,
                BorderColor = Color.BlanchedAlmond,
                CornerRadius = 30,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { lbl, Frame }
            };
            Content = st;
            //Content = grid;
        }
    }
}