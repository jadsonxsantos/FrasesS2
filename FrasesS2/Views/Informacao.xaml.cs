using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrasesS2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informacao : ContentPage
    {
        public Informacao()
        {
            InitializeComponent();
        }

        private async void Telegram_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://t.me/frasess2", BrowserLaunchMode.SystemPreferred);
        }

        private async void Instagram_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://instagram.com/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
        }
    }
}