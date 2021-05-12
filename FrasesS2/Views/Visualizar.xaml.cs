using FrasesS2.Models;
using FrasesS2.Services;
using Plugin.Messaging;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrasesS2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visualizar : ContentPage
    {
        int index = 1;
        int TotaldeFrases;
        string NomeCategoria, frase, autor;
        CategoriaFrase cfdata;
        public Visualizar(CategoriaFrase cf)
        {
            InitializeComponent();
            cfdata = new CategoriaFrase();
            cfdata = cf;
            Title = cfdata.Categoria.ToString();
            ExibirFrase(index);
            ImagemDestaque();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnAppearing();
        }

        private void ExibirFrase(int index)
        {            
                frase = cfdata.Frases[index].Frase;
                autor = cfdata.Frases[index].Autor;
                NomeCategoria = cfdata.Categoria;
                TotaldeFrases = cfdata.Frases.Count - 1;
                //atribuindo os dados aos Componentes da Tela!         
                Frase.Text = frase;
                Autor.Text = autor;
                TotalFrases.Text = string.Format("{0} • {1}", index, TotaldeFrases.ToString());                       
        }

        private void AvancarClicked(Object sender, EventArgs args)
        {
            avancar();
        }

        private void VoltarClicked(Object sender, EventArgs args)
        {
            retroceder();
        }

        private async void avancar()
        {
            try
            {
                if (index < cfdata.Frases.Count - 1)
                {
                    index++;
                }

                else
                {
                    index = 1;
                }
                ExibirFrase(index);
                TotalFrases.Text = string.Format("{0} • {1}", index, TotaldeFrases.ToString());
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Algo de errado não esta certo!" + " ", "OK");
            }
            
        }

        private async void IBtn_Copiar_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(Frase.Text + Environment.NewLine + "(" + Autor.Text + ")" + Environment.NewLine + "ℹ #FrasesS2" +
                  Environment.NewLine +
                  Environment.NewLine + " ⚠ BAIXAR FRASES S2 ⚠  " +
                  Environment.NewLine + "https://linktr.ee/FrasesS2");

            DependencyService.Get<IMessage>().LongAlert("A frase foi copiada.");
        }

        private async void IBtn_Compartilhar_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = Frase.Text + Environment.NewLine + "(" + Autor.Text + ")",
                Uri = Environment.NewLine + "ℹ #FrasesS2" +
                   Environment.NewLine +
                   Environment.NewLine + " ⚠ BAIXAR FRASES S2 ⚠  " +
                   Environment.NewLine + "https://linktr.ee/FrasesS2",
                Title = "Frases S2"
            });
        }

        private async void IBtn_Corrigir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert(Frase.Text, "Algum problema com a frase? ", "Ortografia", "Repetição");
            if (resp)
            {

                var emailMessagner = CrossMessaging.Current.EmailMessenger;
                if (emailMessagner.CanSendEmail)
                {
                    var email = new EmailMessageBuilder()
                  .To("jadson0102@live.com")
                  .Subject("Frases S2 - CORRIGIR ORTOGRÁFIA")
                  .Body(NomeCategoria = cfdata.Categoria + ": " + TotalFrases.Text + Environment.NewLine + Frase.Text + Environment.NewLine + "(" + Autor.Text + ")" + Environment.NewLine + "#FS2Android")
                  .Build();
                    emailMessagner.SendEmail(email);
                }
            }
            else
            {
                var emailMessagner = CrossMessaging.Current.EmailMessenger;
                if (emailMessagner.CanSendEmail)
                {
                    var email = new EmailMessageBuilder()
                   .To("jadson0102@live.com")
                   .Subject("Frases S2 - CORRIGIR REPETIÇÃO")
                   .Body(NomeCategoria = cfdata.Categoria + ": " + TotalFrases.Text + Environment.NewLine + Frase.Text + Environment.NewLine + "(" + Autor.Text + ")" + Environment.NewLine + "#FS2Android")
                   .Build();
                    emailMessagner.SendEmail(email);
                }
            }

        }

        private async void retroceder()
        {
            try
            {
                if (index == 1)
                {
                    index = cfdata.Frases.Count - 1;
                }
                else
                {
                    index--;

                }
                ExibirFrase(index);
                TotalFrases.Text = string.Format("{0} • {1}", index, TotaldeFrases.ToString());
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Algo de errado não esta certo!" + " ", "OK");
            }
          
        }

        private void ImagemDestaque()
        {
            // ao clicar na categoria, identifica o nome dela e exibirar uma mensagem correspondente a categoria
            if (NomeCategoria.Contains("Mensagens de Amizade"))
            {
                ImageCategoria.Source = "amizade.jpg";
            }
            if (NomeCategoria.Contains("Mensagens de Amor"))
            {
                ImageCategoria.Source = "amor.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Aniversário"))
            {
                ImageCategoria.Source = "aniversario.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Ano Novo"))
            {
                ImageCategoria.Source = "Ano_novo.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Boa Noite"))
            {
                ImageCategoria.Source = "boa_noite.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Boa Tarde"))
            {
                ImageCategoria.Source = "boa_tarde.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Bom Dia"))
            {
                ImageCategoria.Source = "bom_dia.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Ciúmes"))
            {
                ImageCategoria.Source = "ciumes.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Decepção"))
            {
                ImageCategoria.Source = "decepcao.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Desculpas"))
            {
                ImageCategoria.Source = "desculpas.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Deus"))
            {
                ImageCategoria.Source = "deus.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Dia das Mães"))
            {
                ImageCategoria.Source = "dia_das_maes.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Dia dos Pais"))
            {
                ImageCategoria.Source = "dia_dos_pais.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens Engraçadas"))
            {
                ImageCategoria.Source = "engracado.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Natal"))
            {
                ImageCategoria.Source = "feliz_natal.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Filmes"))
            {
                ImageCategoria.Source = "Filmes.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Geeks"))
            {
                ImageCategoria.Source = "geek.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Indiretas"))
            {
                ImageCategoria.Source = "indiretas.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Livros"))
            {
                ImageCategoria.Source = "Livros.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Motivação"))
            {
                ImageCategoria.Source = "motivacao.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Músicas"))
            {
                ImageCategoria.Source = "musicas.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Namoro"))
            {
                ImageCategoria.Source = "namoro.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Reflexão"))
            {
                ImageCategoria.Source = "Reflexao.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Saudades"))
            {
                ImageCategoria.Source = "saudades.jpg";
            }
            else if (NomeCategoria.Contains("Mensagens de Tristeza"))
            {
                ImageCategoria.Source = "tristeza.jpg";
            }
        }
    }
}