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
using SplashyApp.Views.Urun_Detay;

namespace SplashyApp.Views.Home
{
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
    public partial class HomePage : ContentPage
    {
        static int rowNumber = urunSayisi();
        string[] p_id = new string[rowNumber];
        string[] p_name = new string[rowNumber];
        string[] p_cat = new string[rowNumber];
        string[] p_price = new string[rowNumber];
        string[] p_imgsrc = new string[rowNumber];
        string[] p_desc = new string[rowNumber];

        public HomePage()
        {
            InitializeComponent();
            UrunCek();
        }

        public void UrunGetir(int rowNumber)
        {
            int i = 0, j = 1;
            bool ok = true;

            while (ok)
            {
                Console.WriteLine("Row:" + i + " J:" + j);
                string macUrl = "http://littlep.xyz/pc/getProducts/" + j.ToString();
                HttpWebRequest request = WebRequest.Create(macUrl) as HttpWebRequest;
                request.ContentType = "application/json";
                request.Method = "GET";
                string jsonVerisi = "";
                var httpResponse1 = (HttpWebResponse)request.GetResponse();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader okuyucu = new StreamReader(response.GetResponseStream());
                    jsonVerisi = okuyucu.ReadToEnd();
                    Console.WriteLine(macUrl+"---"+ jsonVerisi.ToString());
                    if (jsonVerisi == "null")
                    {
                        j++;
                    }
                    else
                    {
                        j++;
                        JsonService app = JsonConvert.DeserializeObject<JsonService>(jsonVerisi);
                        p_id[i] = app.p_id;
                        p_name[i] = app.p_name;
                        p_cat[i] = app.p_cat;
                        p_price[i] = app.p_price.ToString();
                        p_imgsrc[i] = app.p_imgsrc;
                        p_desc[i] = app.p_desc;
                        Console.WriteLine("Dizi:"+p_price[i]);
                        Console.WriteLine("Json:"+app.p_price);
                        i++;
                    }
                    if (i == rowNumber) { ok = false; }
                }
            }
        }
        string urunDetayID = "";
        string name = "";
        string desc = "";
        string category = "";
        string imgsrc = "";
        string price = "";
        public static int urunSayisi()
        {
            int rowNumber = 0;
            string macUrl = "http://littlep.xyz/pc/getRowNumber/";
            HttpWebRequest request = WebRequest.Create(macUrl) as HttpWebRequest;
            //request.ContentType = "application/json";
            request.Method = "GET";
            string jsonVerisi = "";
            var httpResponse1 = (HttpWebResponse)request.GetResponse();
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader okuyucu = new StreamReader(response.GetResponseStream());
                jsonVerisi = okuyucu.ReadToEnd();
                rowNumber = Int16.Parse(jsonVerisi);
            }
            return rowNumber;
        }

        public void UrunCek()
        {
            urunSayisi();
            UrunGetir(rowNumber);
            Grid grid = new Grid();
            grid.RowSpacing = 10;
            grid.ColumnSpacing = 10;
            int font = 0;
            if (DeviceDisplay.MainDisplayInfo.Width < 1080)//Timer çak
                font = 18;
            else
                font = 22;

            for (int i = 0; i != rowNumber; i++)
                grid.RowDefinitions.Add(new RowDefinition { Height = 100 });

            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });

            for (int i = 0; i != rowNumber; i++)
            {
                p_price[i] = p_price[i].Replace('.', ',');
                
                var imgBtn = new ImageButton { WidthRequest= 128,HeightRequest=128, BorderColor = Color.Transparent, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent, Source = "http://littlep.xyz/" + p_imgsrc[i] };
                var label = new Label { Text = p_name[i]+Environment.NewLine+p_desc[i], FontSize = font, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
                var btn = new Button { ClassId = i.ToString(), StyleId=i.ToString(), Text = p_price[i]+" TL", FontSize = font,HorizontalOptions=LayoutOptions.End,VerticalOptions=LayoutOptions.End/* HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.End*/};
                btn.Command = new Command(() =>
                {
                    urunDetayID = p_id[Int16.Parse(btn.ClassId)];
                    name = p_name[Int16.Parse(btn.ClassId)];
                    desc = p_desc[Int16.Parse(btn.ClassId)];
                    imgsrc = p_imgsrc[Int16.Parse(btn.ClassId)];
                    price = p_price[Int16.Parse(btn.ClassId)];
                    category = p_cat[Int16.Parse(btn.ClassId)];
                    Navigation.PushAsync(new Urun_DetayPage(urunDetayID, name, price, desc, imgsrc, category));
                });
                //                       col,row
                grid.Children.Add(imgBtn, 0, i);
                grid.Children.Add(label, 1, i);
                grid.Children.Add(btn, 2,i);
                Grid.SetColumnSpan(label, 4);
                Grid.SetColumnSpan(btn, 4);

            }

            ScrollView scv = new ScrollView() { Content = grid };
            Content = scv;


        }

        

        public void UrunBas(string id)
        {
            DisplayAlert("Title1", id + "Message", "Cancel");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Title", "Message", "Cancel");
            UrunCek();
        }
    }
}