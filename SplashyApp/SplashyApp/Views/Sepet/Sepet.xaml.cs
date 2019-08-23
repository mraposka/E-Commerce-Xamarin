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
using SplashyApp.Views.Urun_Detay;
using SplashyApp.Views.Odeme;
namespace SplashyApp.Views.Sepet
{
    class CATEGORY
    {
        [JsonProperty(PropertyName = "cat_name")]
        public string cat_name { get; set; }
    }
    class JsonService
    {
        [JsonProperty(PropertyName = "p_id")]
        public string p_id { get; set; }

        [JsonProperty(PropertyName = "p_name")]
        public string p_name { get; set; }

        [JsonProperty(PropertyName = "p_cat")]
        public string p_cat { get; set; }

        [JsonProperty(PropertyName = "p_price")]
        public string p_price { get; set; }

        [JsonProperty(PropertyName = "p_imgsrc")]
        public string p_imgsrc { get; set; }

        [JsonProperty(PropertyName = "p_descript")]
        public string p_desc { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SepetPage : ContentPage
    {
        public SepetPage()
        {
            InitializeComponent();
            Main();
        }

        public static int rowNumber = 0;
        private void Main()
        {
            int font = 0;
            if (DeviceDisplay.MainDisplayInfo.Width < 1080)//Timer çak
                font = 18;
            else
                font = 22;
            Grid grid = new Grid();
            grid.RowSpacing = 10;
            grid.ColumnSpacing = 10;

            bool _continue = false; ;
            for (int i = 0; i < urunDetayID.Length; i++)
            {
                if (urunDetayID[i] != " " || urunDetayID[i] != null)
                {
                    _continue = true; Console.WriteLine("asd" + i.ToString() + "-" + urunDetayID[i]);
                }
            }
            if (_continue)
            {
                for (int i = 0; i < urunDetayID.Length; i++)
                {
                    if (urunDetayID[i] != "")
                    { rowNumber++; }
                }

                for (int i = 0; i != rowNumber; i++)
                    grid.RowDefinitions.Add(new RowDefinition { Height = 100 });

                grid.ColumnDefinitions.Add(new ColumnDefinition { });
                grid.ColumnDefinitions.Add(new ColumnDefinition { });
                grid.ColumnDefinitions.Add(new ColumnDefinition { });

                var odeBtn = new Button { Text = "Ödemeye Git", FontAttributes = FontAttributes.Bold,
                    TextColor = Color.White, BackgroundColor = Color.Green, FontSize = 22 };
                odeBtn.Command = new Command(() => { Navigation.PushAsync(new OdemePage()); });
                grid.Children.Add(odeBtn);
                Grid.SetColumnSpan(odeBtn, 6);
                for (int i = 0; i <
                    rowNumber; i++)
                {

                    var imgBtn = new ImageButton { WidthRequest = 128, HeightRequest = 128, BorderColor = Color.Transparent, HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent, Source = "http://littlep.xyz/" + imgsrc[i] };
                    var label = new Label { Text = name[i] + Environment.NewLine + desc[i], FontSize = font, HorizontalTextAlignment = TextAlignment.Start
                        , VerticalTextAlignment = TextAlignment.Center };
                    var btn = new Button { ClassId = i.ToString(), StyleId = i.ToString(), Text = price[i] + " TL", FontSize = font, HorizontalOptions = LayoutOptions.End,
                        VerticalOptions = LayoutOptions.End/* HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.End*/};
                    btn.Command = new Command(() =>
                    {
                    });

                    if (btn.Text != " TL")
                    {
                        //                       col,row
                        grid.Children.Add(imgBtn, 0, i + 1);
                        grid.Children.Add(label, 1, i + 1);
                        grid.Children.Add(btn, 2, i + 1);
                        Grid.SetColumnSpan(label, 4);
                        Grid.SetColumnSpan(btn, 4);
                        ScrollView scv = new ScrollView { Content = grid };
                        Content = scv;
                    }

                }
                rowNumber = 0;
            }
            else { Navigation.PushAsync(new MainPage()); }
        }

        private void getProductsToArray(string[] arr)
        {

        }

        public static string[] urunDetayID = new string[100];
        public static string[] name = new string[100];
        public static string[] desc = new string[100];
        public static string[] category = new string[100];
        public static string[] imgsrc = new string[100];
        public static string[] price = new string[100];

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}