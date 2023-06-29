
using FrasesS2.Models;
using FrasesS2.Services;
using Plugin.StoreReview;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrasesS2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informacao : ContentPage
    {
        readonly FirebaseCRUD Fb_Crud = new FirebaseCRUD();

        readonly string currentVersion = VersionTracking.CurrentVersion;
        int lblValue = 0;
        public Informacao()
        {
            InitializeComponent();
            InfoApp.Text = "FRASES S2 " + currentVersion;
            FetchAllPersons();
            //CrossStoreReview.Current.RequestReview(false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
            FetchAllPersons();
        }

        private async void FetchAllPersons()
        {
            var allPersons = await Fb_Crud.GetAllPersons();
            
            LstPersons.ItemsSource = allPersons.Where(x => x.Disponivel == true).OrderByDescending(d => d.Data);
           

        }

        private async void InfoApp_Clicked(object sender, EventArgs e)
        {
            lblValue++;

            if (lblValue >= 20)
                await Navigation.PushAsync(new EnviarFrase());
            else
                lblValue++;

                //CrossStoreReview.Current.OpenStoreListing("com.companyname.FrasesS2");
                //await Navigation.PushAsync(new Admin());
                //await Browser.OpenAsync("https://instagram.com/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.instagram.com/jlds_projetos", BrowserLaunchMode.SystemPreferred);
        }

        private async void AvaliarAPP_Clicked(object sender, EventArgs e)
        {
            await CrossStoreReview.Current.RequestReview(false);
            CrossStoreReview.Current.OpenStoreListing("com.companyname.FrasesS2");
        }

        private void LstPersons_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            LstPersons.SelectedItem = null;
        }
    }
}