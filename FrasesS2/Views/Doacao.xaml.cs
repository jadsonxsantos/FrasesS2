using FrasesS2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrasesS2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Doacao : ContentPage
    {
        string Chave_pix_Aleatoria = "46a7e52c-d0f4-47e0-b212-2b7bb1714055";
        private const string Url = "https://fs2-doacoes-default-rtdb.firebaseio.com/.json";
        private readonly HttpClient _client = new HttpClient();
        Doacoes categoriasFrase;
        public Doacao()
        { 
            InitializeComponent();
            CarregarDoacoes();
        }

        private async void CarregarDoacoes()
        {        
            try
            {
                string rescontent = await _client.GetStringAsync(Url);

                categoriasFrase = JsonConvert.DeserializeObject<Doacoes>(rescontent);
                Lista_Doacoes.ItemsSource = categoriasFrase.doacao.Where(v => v.Visivel == true).ToList();
                //Lista_Doacoes.ItemsSource = categoriasFrase.doacao.ToList();
            }
            catch (Exception)
            {
                stLayoutdoadores.IsVisible = false;
            }
           
        }

        private async void Copiar_Pix_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(Chave_pix_Aleatoria);
            await DisplayAlert("Chave Aleatória Copiada!", "Pix copiado: " + Chave_pix_Aleatoria, "OK");

        }

        private async void PicPay_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://picpay.me/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private async void Lista_Doacoes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = (ListView)sender;

            if (e.Item == null)
            {
                return;
            }
          
            string link = categoriasFrase.doacao[0].Link.ToString();        
            await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
            lv.SelectedItem = null;
        }
    }
}