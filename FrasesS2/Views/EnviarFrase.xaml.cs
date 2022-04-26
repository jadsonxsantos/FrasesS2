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
                    await Fb_Crud.AddPerson(txtNome.Text, txtDescricao.Text);
                    //Mensagem informando que está tudo correto! e que foi enviado ao DB
                    await DisplayAlert("Tudo certo!", "Seu depoimento foi enviado e está aguardando a aprovação dos nossos moderadores. Agilize a verificação seguindo os passos do aviso.", "OK");
                    //Limpando a Descrição do campo
                    txtDescricao.Text = string.Empty;
                }
                else
                {
                    //Informando que é preciso preencher o campo de Nome
                    await DisplayAlert("Ops", "Digite seu Nome ou @ do seu Instagram", "OK");   
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
    }
}