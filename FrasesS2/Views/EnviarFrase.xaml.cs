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
    public partial class EnviarFrase : ContentPage
    {
        readonly FirebaseCRUD Fb_Crud = new FirebaseCRUD();
        bool Visibilidade;

        public EnviarFrase()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                //Verificando se o campo é diferente de vazio ou nullo
                if (!String.IsNullOrEmpty(txtNome.Text))
                {
                    //Passando as informações para o DB
                    await Fb_Crud.AddPerson(txtNome.Text, txtDescricao.Text, Visibilidade);
                    //Mensagem informando que está tudo correto! e que foi enviado ao DB
                    await DisplayAlert("Tudo certo!", "Aviso enviado com sucesso!", "OK");
                    //Limpando a Descrição do campo
                    txtDescricao.Text = string.Empty;
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                {
                    //Informando que é preciso preencher o campo de Nome
                    await DisplayAlert("Ops", "Preencha os campos por favor!", "OK");   
                }
               
            }
            catch (Exception)
            {
                return;
            }
       
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
           await Browser.OpenAsync("https://instagram.com/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Visibilidade = e.Value;
        }
    }
}