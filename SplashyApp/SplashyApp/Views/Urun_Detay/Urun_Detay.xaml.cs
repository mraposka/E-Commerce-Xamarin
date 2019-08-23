using Newtonsoft.Json;
using SplashyApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SplashyApp.Views.Home;
using SplashyApp.Views.Yiyecek_ve_İçecekler;
using SplashyApp.Views.Sepet;

namespace SplashyApp.Views.Urun_Detay
{
    public partial class Urun_DetayPage : ContentPage
    {
        public Urun_DetayPage(string id, string name, string price, string desc, string imgsrc, string category)
        {
            InitializeComponent();
            Main(id, name, price, desc, imgsrc, category);
        }

        public void Main(string id, string name, string price, string desc, string imgsrc, string category)
        {
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = 400 });
            grid.RowDefinitions.Add(new RowDefinition { });
            grid.RowDefinitions.Add(new RowDefinition { });
            grid.RowDefinitions.Add(new RowDefinition { });
            grid.RowDefinitions.Add(new RowDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            var label = new Label { Text = name, FontSize = 22, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };
            bool SepeteEklendi = false;
            var imgBtn = new ImageButton { WidthRequest = 512, HeightRequest = 512, BorderColor = Color.Transparent, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent, Source = "http://littlep.xyz/" + imgsrc };
            imgBtn.Command = new Command(() => { });
            grid.Children.Add(imgBtn, 0, 0);
            grid.Children.Add(new Label { BackgroundColor = Color.Orange, TextColor = Color.White, Text = name, FontAttributes = FontAttributes.Bold, FontSize = 22, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 0, 1);
            grid.Children.Add(new Label { BackgroundColor = Color.Orange, TextColor = Color.White, Text = desc, FontAttributes = FontAttributes.Bold, FontSize = 22, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 0, 2);
            grid.Children.Add(new Label { BackgroundColor = Color.Orange, TextColor = Color.White, Text = price + " TL", FontAttributes = FontAttributes.Bold, FontSize = 22, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 0, 3);
            var btn = new Button { Text = "Sepete Ekle", FontAttributes = FontAttributes.Bold, TextColor = Color.White, BackgroundColor = Color.Green, FontSize = 22 };
            btn.Command = new Command(() =>
            {
                if (!SepeteEklendi) { 
                ArrayPush(SepetPage.urunDetayID,id);  
                ArrayPush(SepetPage.name,name);  
                ArrayPush(SepetPage.desc,desc);  
                ArrayPush(SepetPage.category,category);  
                ArrayPush(SepetPage.price,price);  
                ArrayPush(SepetPage.imgsrc,imgsrc);
                SepeteEklendi = true;
                }
            });
            grid.Children.Add(btn, 0, 4);
            Content = grid;
        }

        private void ArrayPush(string[] myArray,string newValue)
        {
            int index = Array.IndexOf(myArray, null);

            if (index != -1)
            {
                myArray[index] = newValue;
            }
        }
    }
}