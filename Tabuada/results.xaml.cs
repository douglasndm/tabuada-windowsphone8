using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Shell;
using Windows.Phone.Speech.Synthesis;
using traducao = Tabuada.Resources;
using System.Windows.Media;
using System.Collections.Generic;

namespace Tabuada
{
    public partial class results : PhoneApplicationPage
    {
        AppSettings settings;

        public results()
        {
            InitializeComponent();

            settings = new AppSettings();

            Somando.Header = traducao.AppResources.PanoramaSomandoTitle;
            Subtraindo.Header = traducao.AppResources.PanoramaSubtraindoTitle;
            Multiplicando.Header = traducao.AppResources.PanoramaMultiplicandoTitle;
            Dividindo.Header = traducao.AppResources.PanoramaDividindoTitle;

            //AppBar();
        }

        public void AppBar()
        {
            ApplicationBar = new ApplicationBar();            

            ApplicationBarMenuItem ClassificarApp = new ApplicationBarMenuItem();

            ApplicationBar.BackgroundColor = Color.FromArgb(100, 19, 159, 240);
            //ApplicationBar.BackgroundColor = Colors.Blue;//("FF139FF0");
            ApplicationBar.ForegroundColor = Colors.White;
            

            // Criação dos botões APPBAR
            ApplicationBarIconButton btAppBar_classificar = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.refresh.rest.png", UriKind.Relative));
            btAppBar_classificar.Text = traducao.AppResources.Classificar;
            ApplicationBar.Buttons.Add(btAppBar_classificar);
            btAppBar_classificar.Click += btAppBar_classificar_Click;

            ApplicationBarIconButton btAppBar_ler = new ApplicationBarIconButton(new Uri("/Assets/AppBar/transport.play.png", UriKind.Relative));
            btAppBar_ler.Text = traducao.AppResources.Ler;
            ApplicationBar.Buttons.Add(btAppBar_ler);
            btAppBar_ler.Click += LerResultados;

        }

        public string SomandoSpeak, SubtraindoSpeak, MultiplicandoSpeak, DividindoSpeak;

        private async void LerResultados(object sender, EventArgs e)
        {
            double Num_tabuar = System.Convert.ToDouble(tb_num_tabuar.Text);
            int Num_ate_onde = System.Convert.ToInt32(tb_ate_onde.Text);

            try
            {

                SpeechSynthesizer synth = new SpeechSynthesizer();

                SpeakContar(Num_ate_onde, Num_tabuar, tb_classificar.Text, "somando");
                SpeakContar(Num_ate_onde, Num_tabuar, tb_classificar.Text, "subtraindo");
                SpeakContar(Num_ate_onde, Num_tabuar, tb_classificar.Text, "multiplicando");
                SpeakContar(Num_ate_onde, Num_tabuar, tb_classificar.Text, "dividindo");

                await synth.SpeakTextAsync(traducao.AppResources.PanoramaSomandoTitle + SomandoSpeak);
                await synth.SpeakTextAsync(traducao.AppResources.PanoramaSubtraindoTitle + SubtraindoSpeak);
                await synth.SpeakTextAsync(traducao.AppResources.PanoramaMultiplicandoTitle + MultiplicandoSpeak);
                await synth.SpeakTextAsync(traducao.AppResources.PanoramaDividindoTitle + DividindoSpeak);
            }
            catch (Exception err)
            {

            }
        }

        private void SpeakContar(int ate_onde, double numero, string classificar, string Operacao)
        {
            if (classificar == "321")
            {
            }
            else
            {
                for (int i = 0; i <= ate_onde; i++)
                {
                    double temp;

                    if (Operacao == "somando")
                    {
                        temp = numero + i;
                        if (i != 0)
                        {
                            SomandoSpeak += numero + " " + traducao.AppResources.SomandoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                        }
                        else
                        {
                            SomandoSpeak = numero + " " + traducao.AppResources.SomandoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                        }
                    }
                    else if (Operacao == "subtraindo")
                    {
                        temp = numero - i;
                        if (i != 0)
                        {
                            SubtraindoSpeak += numero + " " + traducao.AppResources.SubtraindoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                        }
                        else
                        {
                            SubtraindoSpeak = numero + " " + traducao.AppResources.SubtraindoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                        }
                    }
                    else if (Operacao == "multiplicando")
                    {
                        temp = numero * i;
                        if (i != 0)
                        {
                            MultiplicandoSpeak += numero + " " + traducao.AppResources.MultiplicandoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                        }
                        else
                        {
                            MultiplicandoSpeak = numero + " " + traducao.AppResources.MultiplicandoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                        }
                    }
                    else
                    {
                        if (i != 0)
                        {
                            temp = numero / i;
                            if (i != 1)
                            {
                                DividindoSpeak += numero + " " + traducao.AppResources.DividindoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                            }
                            else
                            {
                                DividindoSpeak = numero + " " + traducao.AppResources.DividindoSpeak + " " + i + " " + traducao.AppResources.EigualSpeak + " " + temp + "\n";
                            }
                        }
                    }
                }
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        public void contar(int ate_onde, double numero, string classificar)
        {
            if (classificar == "123")
            {
                for (int i = 0; i <= ate_onde; i++)
                {
                    double temp = numero + i;
                    if (i != 0)
                    {
                        tb_somando.Text += numero + " + " + i + " = " + temp + "\n";
                    }
                    else
                    {
                        tb_somando.Text = numero + " + " + i + " = " + temp + "\n";
                    }

                    temp = numero - i;
                    if (i != 0)
                    {
                        tb_subtraindo.Text += numero + " - " + i + " = " + temp + "\n";
                    }
                    else
                    {
                        tb_subtraindo.Text = numero + " - " + i + " = " + temp + "\n";
                    }
                    

                    temp = numero * i;
                    if (i != 0)
                    {
                        tb_multiplicando.Text += numero + " X " + i + " = " + temp + "\n";
                    }
                    else
                    {
                        tb_multiplicando.Text = numero + " X " + i + " = " + temp + "\n";
                    }
                    

                    if (i != 0)
                    {
                        temp = numero / i;
                        if (i != 1)
                        {
                            tb_dividindo.Text += numero + " / " + i + " = " + temp + "\n";
                        }
                        else
                        {
                            tb_dividindo.Text = numero + " / " + i + " = " + temp + "\n";
                        }
                    }
                }
            }
            else
            {
                for (int i = ate_onde; i >= 0; i--)
                {
                    double temp = numero + i;
                    if (i != ate_onde)
                    {
                        tb_somando.Text += numero + " + " + i + " = " + temp + "\n";
                    }
                    else
                    {
                        tb_somando.Text = numero + " + " + i + " = " + temp + "\n";
                    }

                    temp = numero - i;
                    if (i != ate_onde)
                    {
                        tb_subtraindo.Text += numero + " - " + i + " = " + temp + "\n";
                    }
                    else
                    {
                        tb_subtraindo.Text = numero + " - " + i + " = " + temp + "\n";
                    }

                    temp = numero * i;
                    if (i != ate_onde)
                    {
                        tb_multiplicando.Text += numero + " X " + i + " = " + temp + "\n";
                    }
                    else
                    {
                        tb_multiplicando.Text = numero + " X " + i + " = " + temp + "\n";
                    }

                    if (i != 0)
                    {
                        temp = numero / i;
                        if (i != ate_onde)
                        {
                            tb_dividindo.Text += numero + " / " + i + " = " + temp + "\n";
                        }
                        else
                        {
                            tb_dividindo.Text = numero + " / " + i + " = " + temp + "\n";
                        }
                    }
                }
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string num_tabuar_string, ate_onde_tabuar_string, classificar;
            double num_tabuar;
            int ate_onde_tabuar;

            if(NavigationContext.QueryString.TryGetValue("num_tabuar", out num_tabuar_string))
            {
                if (NavigationContext.QueryString.TryGetValue("num_ate_onde", out ate_onde_tabuar_string))
                {
                    num_tabuar = System.Convert.ToDouble(num_tabuar_string);
                    ate_onde_tabuar = System.Convert.ToInt32(ate_onde_tabuar_string);

                    tb_num_tabuar.Text = num_tabuar_string;
                    tb_ate_onde.Text = ate_onde_tabuar_string;                    

                    if (settings.UpdateTile == true)
                    {
                        ShellTile tile = ShellTile.ActiveTiles.First(); //Recupera a tile da aplicação

                        if(settings.updateContLiveTiles == true)
                        {
                            settings.ContLiveTile += 1;
                        }
 
                        StandardTileData std = new StandardTileData //Cria uma tila standard
                        {
                            BackContent = traducao.AppResources.LiveTileTabuando + " " + num_tabuar + ", " + ate_onde_tabuar + " " + traducao.AppResources.LiveTileVezesTabuando, //Texto que aparece atrás da tile                            
                            BackTitle = traducao.AppResources.AppTitle, //Título da aplicação de que aparece atrás da tile
                            //BackBackgroundImage = new Uri("/Imagens/backImagemTile.png", UriKind.Relative), //Imagem de fundo da parte de trás da tile
                            //BackgroundImage = new Uri("/Imagens/imagemTile.png", UriKind.Relative), //Imagem de fundo da parte da frente da tile                            
                            //Title = "Texto texto..." /Título da parte da frente da tile
                        };

                        tile.Update(std); //Faz o update da tile da aplicação                       
                    }

                    if (NavigationContext.QueryString.TryGetValue("classificar", out classificar))
                    {
                        if (classificar != "123")
                        {
                            ApplicationBarIconButton btAppBar_ler = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                            btAppBar_ler.IsEnabled = false;
                        }
                        else
                        {
                            ApplicationBarIconButton btAppBar_ler = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                            btAppBar_ler.IsEnabled = true;
                        }

                        tb_classificar.Text = classificar;
                        contar(ate_onde_tabuar, num_tabuar, classificar);
                    }
                    else
                    {                        
                        tb_classificar.Text = "123";
                        contar(ate_onde_tabuar, num_tabuar, "123");
                    }
                }
                else
                {
                    MessageBox.Show(traducao.AppResources.MgsAlgoDeuErrado);
                    NavigationService.GoBack();
                }
            }
            else
            {
                MessageBox.Show(traducao.AppResources.MgsAlgoDeuErrado);
                NavigationService.GoBack();
            }
        }

        private void btAppBar_classificar_Click(object sender, EventArgs e)
        {
            if (tb_classificar.Text == "123")
            {
                NavigationService.Navigate(new Uri("/results.xaml?classificar=321&num_tabuar=" + tb_num_tabuar.Text + "&num_ate_onde=" + tb_ate_onde.Text, UriKind.RelativeOrAbsolute));
            }
            else
            {
                NavigationService.Navigate(new Uri("/results.xaml?classificar=123&num_tabuar=" + tb_num_tabuar.Text + "&num_ate_onde=" + tb_ate_onde.Text, UriKind.RelativeOrAbsolute));
            }
        }        
    }
}