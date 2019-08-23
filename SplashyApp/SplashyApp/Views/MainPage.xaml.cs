using SplashyApp.Models;
using SplashyApp.Views.AboutUS;
using SplashyApp.Views.Sepet;
using SplashyApp.Views.Configuration;
using SplashyApp.Views.Home;
using SplashyApp.Views.Profile_Settings;
using SplashyApp.Views.Odeme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplashyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            //Fot Android / IOS icons
            var page1 = new MasterPageItem() { id = 1, Title = "Anasayfa", Icon = "Home.png" };
            var page2 = new MasterPageItem() { id = 2, Title = "Ürünler", Icon = "Configuration.png" };
            var page6 = new MasterPageItem() { id = 6, Title = "Üye Girişi", Icon = "ProfileSetting.png" };
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page6);
            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }
        private void SepetGoruntule(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SepetPage());
        }

        async private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {


            var myselecteditem = e.Item as MasterPageItem;

            switch (myselecteditem.id)
            {

                case 1:
                    await Navigation.PushAsync(new HomePage()); 
                    break;
                case 2:
                    await Navigation.PushAsync(new AboutUSPage());

                    break;
                case 6:
                    await Navigation.PushAsync(new ConfigurationPage());
                    break;


            }
            ((ListView)sender).SelectedItem = null;
            IsPresented = false;


        }
        int rowNumber = 0;
        private void Ode(object sender, EventArgs e)
        {
            for (int i = 0; i < SepetPage.urunDetayID.Length; i++)
            {
                if (SepetPage.urunDetayID[i] != null)
                { rowNumber++; }
            }
            if (rowNumber != 0)
                Navigation.PushAsync(new OdemePage());
        }
    }
}
