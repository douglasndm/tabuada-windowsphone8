using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using traducao = Tabuada.Resources;

namespace Tabuada
{
    public partial class settings : PhoneApplicationPage
    {
        AppSettings Settings;

        public settings()
        {
            InitializeComponent();

            Settings = new AppSettings();

            //TRADUÇÂO
            AppTitle.Text = traducao.AppResources.AppTitle.ToUpper();
            PageTitle.Text = traducao.AppResources.PageTitleSettings;            
            TextBlock_UpdateLiveTiles.Text = traducao.AppResources.UpdateLiveTiles;
            TextBlock_UpdateContLiveTiles.Text = traducao.AppResources.UpdateContLiveTiles;
            bt_zerarCont.Content = traducao.AppResources.bt_zerarCont;

            //TRADUÇÃO APPBAR
            ApplicationBarIconButton SavaSettings = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            SavaSettings.Text = traducao.AppResources.Salvar;

            ToggleSwitch_UpdateLiveTiles.IsChecked = Settings.UpdateTile;
            ToggleSwitch_UpdateContLiveTiles.IsChecked = Settings.updateContLiveTiles;
            Tb_cont.Text = Settings.ContLiveTile.ToString() + " " + traducao.AppResources.SettingsContasFeitas;

            if (Settings.UpdateTile == false)
            {
                ToggleSwitch_UpdateContLiveTiles.IsEnabled = false;
                OcultarOpcoesdoContador();
            }
            else
            {
                ToggleSwitch_UpdateContLiveTiles.IsEnabled = true;
                MostrarOpcoesdoContador();
            }

            if (Settings.updateContLiveTiles == false)
            {
                OcultarOpcoesdoContador();
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void SavaSettings_Click(object sender, EventArgs e)
        {
            Settings.UpdateTile = ToggleSwitch_UpdateLiveTiles.IsChecked.Value;
            Settings.updateContLiveTiles = ToggleSwitch_UpdateContLiveTiles.IsChecked.Value;

            if (ToggleSwitch_UpdateLiveTiles.IsChecked == false)
            {
                ShellTile tile = ShellTile.ActiveTiles.First(); //Recupera a tile da aplicação

                StandardTileData std = new StandardTileData //Cria uma tila standard
                {
                    Count = 0, //Número que aparece junto a parte da frente da tile
                    BackContent = "", //Texto que aparece atrás da tile
                    BackTitle = "", //Título da aplicação de que aparece atrás da tile
                    //BackBackgroundImage = new Uri("/Imagens/backImagemTile.png", UriKind.Relative), //Imagem de fundo da parte de trás da tile
                    //BackgroundImage = new Uri("/Imagens/imagemTile.png", UriKind.Relative),  //Imagem de fundo da parte da frente da tile
                    //Title = "Texto texto..." //Título da parte da frente da tile
                };
                tile.Update(std); //Faz o update da tile da aplicação
            }
            else if (ToggleSwitch_UpdateContLiveTiles.IsChecked == false)
            {
                Settings.ContLiveTile = 0;
                ShellTile tile = ShellTile.ActiveTiles.First();
                StandardTileData std = new StandardTileData
                {
                    Count = 0,
                };
                tile.Update(std);
            }

            NavigationService.Navigate(new Uri("/home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void bt_zerarCont_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Settings.ContLiveTile = 0;
            Tb_cont.Text = 0 + " " + traducao.AppResources.SettingsContasFeitas;

            ShellTile tile = ShellTile.ActiveTiles.First(); 
            StandardTileData std = new StandardTileData
            {
                Count = 0,
            };
            tile.Update(std);
        }


        private void ToggleSwitch_UpdateContLiveTiles_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            MostrarOpcoesdoContador();
        }
        private void ToggleSwitch_UpdateContLiveTiles_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            OcultarOpcoesdoContador();
        }

        public void OcultarOpcoesdoContador()
        {
            Tb_cont.Opacity = 0;
            bt_zerarCont.Opacity = 0;
            bt_zerarCont.IsEnabled = false;
        }

        public void MostrarOpcoesdoContador()
        {
            Tb_cont.Opacity = 100;
            bt_zerarCont.Opacity = 100;
            bt_zerarCont.IsEnabled = true;
        }

        private void ToggleSwitch_UpdateLiveTiles_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleSwitch_UpdateContLiveTiles.IsEnabled = true;

            if (ToggleSwitch_UpdateContLiveTiles.IsChecked == true)
            {
                MostrarOpcoesdoContador();
            }
            else
            {
                OcultarOpcoesdoContador();
            }

        }

        private void ToggleSwitch_UpdateLiveTiles_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleSwitch_UpdateContLiveTiles.IsEnabled = false;
            OcultarOpcoesdoContador();
        }

        /*
        private void Theme_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(Theme.Header =="Preto")
            {
                MessageBox.Show("Cor Preto");
            }
            else if (Theme.Header == "Azul")
            {
                MessageBox.Show("Cor Azul");
            }
        }*/
    }
}