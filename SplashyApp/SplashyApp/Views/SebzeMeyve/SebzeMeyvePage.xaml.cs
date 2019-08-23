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

namespace SplashyApp.Views.SebzeMeyve
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
    public partial class SebzeMeyvePage : ContentPage
    {
        public SebzeMeyvePage()
        {
            InitializeComponent();
            getCategories();
        }
        bool isCategoryFound = false;
        private void Main(string[] cats)
        {
            string categories = "";
            foreach (string q in cats)
            {
                categories += q;
            }
            int catID = 0;

            for (int i = 1; i <= cats.Length; i++)
            {
                catID = categoryControl(i);
                if (catID == 0)
                { isCategoryFound = false; catID = 0; }
                else
                    isCategoryFound = true;
                if (isCategoryFound) i = cats.Length;

                Console.WriteLine("CATID:" + catID.ToString() + " isCategoryFound:" + isCategoryFound.ToString());
            }
            if (isCategoryFound)
            {
                string macUrl = "http://littlep.xyz/pc/GetProducts/0/" + catID.ToString();
                HttpWebRequest request = WebRequest.Create(macUrl) as HttpWebRequest;
                request.ContentType = "application/json";
                request.Method = "GET";
                string jsonVerisi = "";
                var httpResponse1 = (HttpWebResponse)request.GetResponse();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader okuyucu = new StreamReader(response.GetResponseStream());
                    jsonVerisi = okuyucu.ReadToEnd();
                    //JsonService app = JsonConvert.DeserializeObject<JsonService>(jsonVerisi);
                    //json verisi /n ile parçalanıp diziye atılcak. Her dizi değeri jsonconvert yapılıp
                    //listeye eklenecek
                    string[] jsonProducts = jsonVerisi.Split('-');
                    int urunSayisi = ((jsonProducts.Length) - 1);
                    Console.WriteLine(urunSayisi.ToString());
                    urunGoruntule(urunSayisi, jsonProducts);
                }



            }
        }

        private void urunGoruntule(int rowNumber, string[] jsonProducts)
        {
            string[] p_id = new string[rowNumber];
            string[] p_name = new string[rowNumber];
            string[] p_cat = new string[rowNumber];
            string[] p_price = new string[rowNumber];
            string[] p_imgsrc = new string[rowNumber];
            string[] p_desc = new string[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                JsonService app = JsonConvert.DeserializeObject<JsonService>(jsonProducts[i]);
                Console.WriteLine(i.ToString());
                p_id[i] = app.p_id;
                p_name[i] = app.p_name;
                p_cat[i] = app.p_cat;
                p_price[i] = app.p_price.ToString();
                p_imgsrc[i] = app.p_imgsrc;
                p_desc[i] = app.p_desc;
            }
            Console.WriteLine("Last:" + p_id.Last().ToString());

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
                var imgBtn = new ImageButton { WidthRequest = 128, HeightRequest = 128, BorderColor = Color.Transparent, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent, Source = "http://littlep.xyz/" + p_imgsrc[i] };
                var label = new Label { Text = p_name[i] + Environment.NewLine + p_desc[i], FontSize = font, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
                var btn = new Button { ClassId = i.ToString(), StyleId = i.ToString(), Text = p_price[i] + " TL", FontSize = font, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.End/* HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.End*/};
                btn.Command = new Command(() =>
                {
                    DisplayAlert(p_name[Int16.Parse(btn.ClassId)], p_desc[Int16.Parse(btn.ClassId)], p_price[Int16.Parse(btn.ClassId)].ToString());
                });
                //                       col,row
                grid.Children.Add(imgBtn, 0, i);
                grid.Children.Add(label, 1, i);
                grid.Children.Add(btn, 2, i);
                Grid.SetColumnSpan(label, 4);
                Grid.SetColumnSpan(btn, 4);

            }

            ScrollView scv = new ScrollView() { Content = grid };
            Content = scv;


        }

        string categoryName = "";
        private int categoryControl(int i)
        {
            Console.WriteLine(i.ToString());
            string macUrl = "http://littlep.xyz/pc/getCategoryName/" + i.ToString();
            Console.WriteLine("Link:" + macUrl);
            HttpWebRequest request = WebRequest.Create(macUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            string jsonVerisi = "";
            var httpResponse1 = (HttpWebResponse)request.GetResponse();
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader okuyucu = new StreamReader(response.GetResponseStream());
                jsonVerisi = okuyucu.ReadToEnd();
                CATEGORY app = JsonConvert.DeserializeObject<CATEGORY>(jsonVerisi);
                string pageName = this.GetType().Name.ToString();
                pageName = pageName.Remove(pageName.Length - 1);
                pageName = pageName.Remove(pageName.Length - 1);
                pageName = pageName.Remove(pageName.Length - 1);
                pageName = pageName.Remove(pageName.Length - 1);
                Console.WriteLine("CatName:" + categoryName + " App.CatName:" + app.cat_name + " Name:" + pageName);

                if (app.cat_name == pageName)
                {
                    categoryName = app.cat_name;
                    return i;
                }
                else
                    return 0;
            }
        }

        private string[] catts;
        private void getCategories()
        {

            string macUrl = "http://littlep.xyz/pc/getCats/";
            HttpWebRequest request = WebRequest.Create(macUrl) as HttpWebRequest;
            //request.ContentType = "application/json";
            request.Method = "GET";
            string jsonVerisi = "";
            var httpResponse1 = (HttpWebResponse)request.GetResponse();
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader okuyucu = new StreamReader(response.GetResponseStream());
                jsonVerisi = okuyucu.ReadToEnd();
                jsonVerisi = jsonVerisi.Substring(0, Math.Max(jsonVerisi.Length - 1, 0));
                string[] cats = jsonVerisi.Split('-');
                Main(cats);
            }
        }

    }
}