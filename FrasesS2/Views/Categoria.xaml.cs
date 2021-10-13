using FrasesS2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrasesS2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categoria : ContentPage
    {
        private const string Url = "https://frasess2-e34c0-default-rtdb.firebaseio.com/.json";
        private readonly HttpClient _client = new HttpClient();
        public Categoria()
        {
            InitializeComponent();
            CarregarCategoria();
        }

        private async void NavegarToCategoria(string categoria)
        {
            try
            {
                string rescontent = await _client.GetStringAsync(Url);

                List<CategoriaFrase> categoriasFrase = JsonConvert.DeserializeObject<List<CategoriaFrase>>(rescontent);

                // Selecionar o objeto no Json. 
                CategoriaFrase categoriaFrase = categoriasFrase.FirstOrDefault(cf => cf.Categoria.Equals(categoria));

                // Abre tela e envia os parâmetros.    
                if (categoriaFrase != null)
                {
                    //if (MyAdsCode.ShowNewADS)
                    //{
                    //    await DependencyService.Get<IAdmobInterstitialAds>().Display(MyAdsCode.InterstitialAdId);
                    //}

                    await Navigation.PushAsync(new Views.Visualizar(categoriaFrase));
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Você esta sem internet!", "Em breve teremos frases em modo Offline, Aguarde!" + " ", "OK");

            }
        }
        private void CarregarCategoria()
        {
            List<CategoriaFrase> Lt_Ctg_Android = new List<CategoriaFrase>();
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Amizade", ImageCateg = "Inicio_amizade_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Amor", ImageCateg = "Inicio_amor_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Aniversario", ImageCateg = "Inicio_aniversario_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Ano Novo", ImageCateg = "Inicio_ano_novo_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Boa Noite", ImageCateg = "Inicio_boa_noite_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Boa Tarde", ImageCateg = "Inicio_boa_tarde_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Bom Dia", ImageCateg = "Inicio_bom_dia_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Ciumes", ImageCateg = "Inicio_ciumes_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Decepcao", ImageCateg = "Inicio_decepcao_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Desculpas", ImageCateg = "Inicio_desculpas_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Deus", ImageCateg = "Inicio_deus_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Dia das Maes", ImageCateg = "Inicio_dia_das_maes_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Dia dos Pais", ImageCateg = "Inicio_dia_dos_pais_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Engracadas", ImageCateg = "Inicio_engracadas_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Feliz Natal", ImageCateg = "Inicio_feliz_natal_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Filmes", ImageCateg = "Inicio_filmes_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Geek", ImageCateg = "Inicio_geek_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Indiretas", ImageCateg = "Inicio_indiretas_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Livros", ImageCateg = "Inicio_livros_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Motivacao", ImageCateg = "Inicio_motivacao_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Musicas", ImageCateg = "Inicio_musica_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Namoro", ImageCateg = "Inicio_namoro_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Reflexao", ImageCateg = "Inicio_reflexao_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Saudades", ImageCateg = "Inicio_saudades_bloco.jpg" });
            Lt_Ctg_Android.Add(new CategoriaFrase { TituloCateg = "Tristeza", ImageCateg = "Inicio_tristeza_bloco.jpg" });
            Lista_Categorias.ItemsSource = Lt_Ctg_Android;
        }

        private void Lista_Categorias_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = (ListView)sender;

            if (e.Item == null)
            {
                return;
            }


            var item = (CategoriaFrase)e.Item;
            switch (item.TituloCateg.ToString())
            {
                case "Amizade":
                    NavegarToCategoria("Mensagens de Amizade");
                    break;

                case "Amor":
                    NavegarToCategoria("Mensagens de Amor");
                    break;

                case "Aniversario":
                    NavegarToCategoria("Mensagens de Aniversário");
                    break;

                case "Ano Novo":
                    NavegarToCategoria("Mensagens de Ano Novo");
                    break;

                case "Boa Noite":
                    NavegarToCategoria("Mensagens de Boa Noite");
                    break;

                case "Boa Tarde":
                    NavegarToCategoria("Mensagens de Boa Tarde");
                    break;

                case "Bom Dia":
                    NavegarToCategoria("Mensagens de Bom Dia");
                    break;

                case "Ciumes":
                    NavegarToCategoria("Mensagens de Ciúmes");
                    break;

                case "Decepcao":
                    NavegarToCategoria("Mensagens de Decepção");
                    break;

                case "Desculpas":
                    NavegarToCategoria("Mensagens de Desculpas");
                    break;

                case "Deus":
                    NavegarToCategoria("Mensagens de Deus");
                    break;

                case "Dia das Maes":
                    NavegarToCategoria("Mensagens de Dia das Mães");
                    break;

                case "Dia dos Pais":
                    NavegarToCategoria("Mensagens de Dia dos Pais");
                    break;

                case "Engracadas":
                    NavegarToCategoria("Mensagens Engraçadas");
                    break;

                case "Feliz Natal":
                    NavegarToCategoria("Mensagens de Natal");
                    break;

                case "Filmes":
                    NavegarToCategoria("Mensagens de Filmes");
                    break;

                case "Geek":
                    NavegarToCategoria("Mensagens de Geeks");
                    break;

                case "Indiretas":
                    NavegarToCategoria("Mensagens de Indiretas");
                    break;

                case "Livros":
                    NavegarToCategoria("Mensagens de Livros");
                    break;

                case "Motivacao":
                    NavegarToCategoria("Mensagens de Motivação");
                    break;

                case "Musicas":
                    NavegarToCategoria("Mensagens de Músicas");
                    break;

                case "Namoro":
                    NavegarToCategoria("Mensagens de Namoro");
                    break;

                case "Reflexao":
                    NavegarToCategoria("Mensagens de Reflexão");
                    break;

                case "Saudades":
                    NavegarToCategoria("Mensagens de Saudades");
                    break;

                case "Tristeza":
                    NavegarToCategoria("Mensagens de Tristeza");
                    break;
            }
            lv.SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}