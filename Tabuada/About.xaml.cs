using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using traducao = Tabuada.Resources;

namespace Tabuada
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            AboutAppTitle.Text = traducao.AppResources.AppTitle.ToUpper();
            TextBlock_version.Text = traducao.AppResources.Versao + " 1.5.2";
            AboutPageTitle.Text = traducao.AppResources.Sobre;
            DesenvolvidoPor.Text = traducao.AppResources.DesenvolvidoPor;
        }

        private void BtEmail_Click(object sender, EventArgs e)
        {
            EmailComposeTask mail = new EmailComposeTask();
            mail.To = "DouglasNunesdeMattos@outlook.com";
            mail.Show();
        }
    }
}