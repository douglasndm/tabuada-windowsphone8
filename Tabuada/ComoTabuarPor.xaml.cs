using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.Speech.Synthesis;
using traducao = Tabuada.Resources;

namespace Tabuada
{
    public partial class ComoTabuarPor : PhoneApplicationPage
    {
        public ComoTabuarPor()
        {
            InitializeComponent();

            pano2.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 2";
            pano3.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 3";
            pano4.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 4";
            pano5.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 5";
            pano6.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 6";
            pano8.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 8";
            pano9.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 9";
            pano10.Header = traducao.AppResources.ComoTabuarTitle + " " + traducao.AppResources.PorComoTabuarPage + " 10";

            ComoTabuarPor2.Text = traducao.AppResources.ComoTabuarPor2;
            ComoTabuarPor3.Text = traducao.AppResources.ComoTabuarPor3;
            ComoTabuarPor4.Text = traducao.AppResources.ComoTabuarPor4;
            ComoTabuarPor5.Text = traducao.AppResources.ComoTabuarPor5;
            ComoTabuarPor6.Text = traducao.AppResources.ComoTabuarPor6;
            ComoTabuarPor8.Text = traducao.AppResources.ComoTabuarPor8;
            ComoTabuarPor9.Text = traducao.AppResources.ComoTabuarPor9;
            ComoTabuarPor10.Text = traducao.AppResources.ComoTabuarPor10;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string panorama;

            if (NavigationContext.QueryString.TryGetValue("num", out panorama))
            {
                if (panorama == "3")
                {
                    ComoTabuar.DefaultItem = pano3;
                }
                else if (panorama == "4")
                {
                    ComoTabuar.DefaultItem = pano4;
                }
                else if (panorama == "5")
                {
                    ComoTabuar.DefaultItem = pano5;
                }
                else if (panorama == "6")
                {
                    ComoTabuar.DefaultItem = pano6;
                }
                else if (panorama == "8")
                {
                    ComoTabuar.DefaultItem = pano8;
                }
                else if (panorama == "9")
                {
                    ComoTabuar.DefaultItem = pano9;
                }
                else if (panorama == "10")
                {
                    ComoTabuar.DefaultItem = pano10;
                }
                else
                {
                    ComoTabuar.DefaultItem = pano2;
                }
            }
        }
    }
}