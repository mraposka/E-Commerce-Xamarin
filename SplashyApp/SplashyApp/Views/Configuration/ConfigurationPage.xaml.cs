using Newtonsoft.Json;
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
using SplashyApp.Views.Siparisler;

namespace SplashyApp.Views.Configuration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    class JsonService
    {
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
    }

        public partial class ConfigurationPage : ContentPage
	{
		public ConfigurationPage ()
		{
            Label header = new Label
            {
                Text = "Adres Bilgileri",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            InitializeComponent();
            Main(header);
        }
        public static string uye = "";
        private void Main(Label header)
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
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            Entry email = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "E-Posta Adresinizi Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            Entry sifre = new Entry
            {
                Keyboard = Keyboard.Telephone,
                Placeholder = "Şifrenizi Girin",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 32
            };
            grid.Children.Add(header, 0, 0);
            Grid.SetColumnSpan(header, 5);

            grid.Children.Add(email, 0, 1);
            Grid.SetColumnSpan(email, 5);

            grid.Children.Add(sifre, 0, 2);
            Grid.SetColumnSpan(sifre, 5);


            var grsBtn = new Button { Text = "Giriş", FontAttributes = FontAttributes.Bold, TextColor = Color.White, BackgroundColor = Color.Green, FontSize = 22 };
            grsBtn.Command = new Command(() =>
            {
                if (email.Text == "" || email.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else if (sifre.Text == "" || sifre.Text == null)
                    DisplayAlert("Uyarı!", "Boş alanları doldurunuz!", "Tamam");
                else
                {
                    string macUrl = "http://littlep.xyz/pc/uyegiris/"+email.Text+"/"+sifre.Text;
                    HttpWebRequest request = WebRequest.Create(macUrl) as HttpWebRequest;
                    request.ContentType = "application/json";
                    request.Method = "GET";
                    string jsonVerisi = "";
                    var httpResponse1 = (HttpWebResponse)request.GetResponse();
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader okuyucu = new StreamReader(response.GetResponseStream());
                        jsonVerisi = okuyucu.ReadToEnd();
                        if (jsonVerisi != "null") { 
                        JsonService app = JsonConvert.DeserializeObject<JsonService>(jsonVerisi);
                        uye = app.email;
                        }
                        else { uye = "null"; }
                    }
                    if (uye != "null") { 
                    Navigation.PushAsync(new SiparislerPage());
                    DisplayAlert("Başarılı!", "Giriş başarılı. Siparişlerinizi görebilirsiniz!", "Tamam");
                    }
                    else { Navigation.PushAsync(new ConfigurationPage());
                        DisplayAlert("Başarılı!", "Giriş başarısız! Tekrar deneyiniz.", "Tamam");
                    }
                }

            });
            grid.Children.Add(grsBtn, 0, 9);
            Grid.SetColumnSpan(grsBtn, 5);
            ScrollView scv = new ScrollView { Content = grid };

            Content = scv;



        }

    }
}