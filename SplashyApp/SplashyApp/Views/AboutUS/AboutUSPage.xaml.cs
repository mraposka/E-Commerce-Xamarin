using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashyApp.Views.Yiyecek_ve_İçecekler;
using SplashyApp.Views.SebzeMeyve;
using SplashyApp.Views.TemizlikUrunleri;
using SplashyApp.Views.IcecekUrunleri;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SplashyApp.Views.AboutUS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutUSPage : ContentPage
	{
		public AboutUSPage ()
		{
			InitializeComponent ();
		}

        private void Yiyecek_ve_İçecekler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Yiyecek_ve_İçeceklerPage());
        }
        private void TemizlikUrunleri(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TemizlikUrunleriPage());
        }
        private void SebzeMeyveUrunleri(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SebzeMeyvePage());
        }
        private void IcecekUrunleri(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IcecekUrunleriPage());
        }
    }
}