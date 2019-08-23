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
using SplashyApp.Views.Sepet;
using SplashyApp.Views.Home;
using SplashyApp.Views.Urun_Detay;
namespace SplashyApp.Views.Odeme
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
    public partial class OdemePage : ContentPage
    {
        public OdemePage()
        {
            Label header = new Label
            {
                Text = "Adres Bilgileri",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            Label headerQ = new Label
            {
                Text = "Ödeme Bilgileri",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            InitializeComponent();
            Main(header, headerQ);

        }


        int rowNumber = 0;
        private void Main(Label header, Label headerQ)
        {

            int font = 0;
            if (DeviceDisplay.MainDisplayInfo.Width < 1080)//Timer çak
                font = 18;
            else
                font = 22;
            Grid grid = new Grid();
            grid.RowSpacing = 10;
            grid.ColumnSpacing = 10;
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            Entry email = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "E-Posta Adresinizi Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry adresBasligi = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Adres Başlığınızı Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry adres = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Adresinizi Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry sehir = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Sehirinizi Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry AdSoyad = new Entry
            {
                Keyboard = Keyboard.Default,
                Placeholder = "Adınızı ve Soyadınızı Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry kartNo = new Entry
            {
                Keyboard = Keyboard.Telephone,
                Placeholder = "Kredi Kartı Numarası",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry sonKullanma = new Entry
            {
                Keyboard = Keyboard.Telephone,
                Placeholder = "Son Kullanma Tarihi",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry cvc = new Entry
            {
                Keyboard = Keyboard.Telephone,
                Placeholder = "CVV/CVC",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            grid.Children.Add(header, 0, 0);
            Grid.SetColumnSpan(header, 5);

            grid.Children.Add(email, 0, 1);
            Grid.SetColumnSpan(email, 5);

            grid.Children.Add(adresBasligi, 0, 2);
            Grid.SetColumnSpan(adresBasligi, 5);

            grid.Children.Add(adres, 0, 3);
            Grid.SetColumnSpan(adres, 5);

            grid.Children.Add(sehir, 0, 4);
            Grid.SetColumnSpan(sehir, 5);

            grid.Children.Add(headerQ, 0, 5);
            Grid.SetColumnSpan(headerQ, 5);

            grid.Children.Add(AdSoyad, 0, 6);
            Grid.SetColumnSpan(AdSoyad, 5);

            grid.Children.Add(kartNo, 0, 7);
            Grid.SetColumnSpan(kartNo, 5);

            grid.Children.Add(sonKullanma, 0, 8);
            Grid.SetColumnSpan(sonKullanma, 2);

            grid.Children.Add(cvc, 0, 8);
            Grid.SetColumn(cvc, 3);
            Grid.SetColumnSpan(cvc, 2);

            var odeBtn = new Button { Text = "Öde", FontAttributes = FontAttributes.Bold, TextColor = Color.White, BackgroundColor = Color.Green, FontSize = 22 };
            odeBtn.Command = new Command(() =>
            {
                if (email.Text == "" || email.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (adresBasligi.Text == "" || adresBasligi.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (adres.Text == "" || adres.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (sehir.Text == "" || sehir.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (AdSoyad.Text == "" || AdSoyad.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (kartNo.Text == "" || kartNo.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (sonKullanma.Text == "" || sonKullanma.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (cvc.Text == "" || cvc.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else
                {
                    ode(email.Text, adresBasligi.Text, adres.Text, sehir.Text, AdSoyad.Text, kartNo.Text, sonKullanma.Text, cvc.Text);
                    Navigation.PushAsync(new MainPage());
                    DisplayAlert("Başarılı!", "Ödeme Başarılı. Teşekkürler!", "Tamam");
                }

            });
            grid.Children.Add(odeBtn, 0, 9);
            Grid.SetColumnSpan(odeBtn, 5);
            ScrollView scv = new ScrollView { Content = grid };

            Content = scv;



        }

        private void ode(string email, string adresBasligi, string adres, string sehir, string AdSoyad, string kartNo, string sonKullanma, string cvc)
        {
            string urunId = "";
            for (int i = 0; i < 100; i++)
            {
                if (urunDetayID[i] != "" && urunDetayID[i] != null)
                { urunId += urunDetayID[i] + "."; }
            }


            string url = "https://littlep.xyz/pc/Odeme/" + email + "/" + adresBasligi + "/" + adres + "/" + sehir + "/" + AdSoyad + "/" + kartNo + "/" + sonKullanma + "/" + cvc+"/"+urunId;
            Console.WriteLine("TEST:"+url);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                //  Console.WriteLine("Kapatıldı");
            }


        }

        public static string[] urunDetayID = SepetPage.urunDetayID;
        public static string[] name = SepetPage.name;
        public static string[] desc = SepetPage.desc;
        public static string[] category = SepetPage.category;
        public static string[] imgsrc = SepetPage.imgsrc;
        public static string[] price = SepetPage.price;

    }
}