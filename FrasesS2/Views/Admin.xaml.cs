using FrasesS2.Models;
using FrasesS2.Services;
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
    public partial class Admin : ContentPage
    {
        readonly FirebaseCRUD Fb_Crud = new FirebaseCRUD();
        UserMural itemPix = new UserMural();
        public Admin()
        {
            InitializeComponent();
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


            await Clipboard.SetTextAsync(itemPix.UserMuralId.ToString());
            await DisplayAlert("Copiado!", itemPix.UserMuralId.ToString(), "OK");

        }

        private async void Swipe_OpenLinkExterno_Invoked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync(itemPix.Link, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private async void Swipe_Aprovar_Invoked(object sender, EventArgs e)
        {
            var allPersons = await Fb_Crud.GetAllPersons();
            await Fb_Crud.Update(itemPix.UserMuralId, true);
         
            await DisplayAlert("Sucesso", "Pokemon Atualizado", "OK");
           
            LstPersons.ItemsSource = allPersons.Where(x => x.Disponivel == true);
           

        }
    }
}