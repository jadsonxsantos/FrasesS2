using FrasesS2.Models;
using FrasesS2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrasesS2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mural : ContentPage
	{
        readonly FirebaseCRUD Fb_Crud = new FirebaseCRUD();
        UserMural itemPix = new UserMural();
		public Mural()
        {
			InitializeComponent ();
			FetchAllPersons();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FetchAllPersons();
        }

        private async void FetchAllPersons()
        {
            var allPersons = await Fb_Crud.GetAllPersons();
            RefreshControl.IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(2));
          
            LstPersons.ItemsSource = allPersons.Where(x => x.Disponivel == true);
           
            RefreshControl.IsRefreshing = false;
         

        }

        private async void LstPersons_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = (ListView)sender;

            if (e.Item == null)
            {
                return;
            }


            itemPix = (UserMural)e.Item;


            await Clipboard.SetTextAsync(itemPix.Descricao);
            await DisplayAlert("Copiado!", itemPix.Descricao , "OK");

        }

        private async void Swipe_OpenLinkExterno_Invoked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://chat.whatsapp.com/CIpiAtei5h27auOA672J6V", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private async void Swipe_CopiarChavePix_Invoked(object sender, EventArgs e)
        {
        //    await Clipboard.SetTextAsync(itemPix.Chave);
        //    await DisplayAlert("Chave Pix Copiada!", "Que tal enviar um PIX LOVE para : " + itemPix.Nome + ", Abra seu banco e faça uma PIX de qualquer valor!", "OK");

        //}
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnviarFrase());
        }
    }
}