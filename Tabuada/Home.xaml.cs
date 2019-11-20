using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Windows.Phone.Speech.VoiceCommands;
using traducao = Tabuada.Resources;


namespace Tabuada
{
    public partial class Home : PhoneApplicationPage
    {
        public Home()
        {
            InitializeComponent();

            setupVoiceCommands();

            AppSettings settings = new AppSettings();
            
            tblock_NumTabua.Text = traducao.AppResources.HomeNumTabua;
            tblock_num_ate_onde.Text = traducao.AppResources.HomeNumAteOnde;
            bt_tabuar.Content = traducao.AppResources.Tabua;


            ApplicationBarIconButton AppBarBt_Configuraoes = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            AppBarBt_Configuraoes.Text = traducao.AppResources.BotaoConfiguracoes;
        }

        async void setupVoiceCommands()
        {
            await VoiceCommandService.InstallCommandSetsFromFileAsync(
            new Uri("ms-appx:///VoiceCommands/VCDCommands.xml", UriKind.RelativeOrAbsolute));
        }
        
        private void bt_tabuar_Click(object sender, RoutedEventArgs e)
        {
            if (tb_num_tabuar.Text != "")
            {
                if (tb_qnts_vezes.Text != "")
                {
                    double Ate = System.Convert.ToDouble(tb_qnts_vezes.Text.Trim());

                    if (Ate > 1000)
                    {
                        MessageBox.Show(traducao.AppResources.AvisoTabuaNumMaior1000);
                    }

                    NavigationService.Navigate(new Uri("/results.xaml?num_tabuar=" + tb_num_tabuar.Text.Trim() + "&num_ate_onde=" + tb_qnts_vezes.Text.Trim(), UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show(traducao.AppResources.ErroFaltandoNumAteOndeTabua);
                }
            }
            else
            {
                MessageBox.Show(traducao.AppResources.ErroFaltandoNumTabua);
            }
        }

        private void bt_config_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btAprender_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ComoTabuarPor.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}