using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PanoramaApp2
{
    public partial class PivotPage2 : PhoneApplicationPage
    {
        public PivotPage2()
        {
            InitializeComponent();
            #region EFFECTS SETTINGS
            NavigationInTransition navigateInTransition = new NavigationInTransition();

            navigateInTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeIn };
            navigateInTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeIn };

            NavigationOutTransition navigateOutTransition = new NavigationOutTransition();

            navigateOutTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeOut };
            navigateOutTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeOut };

            TransitionService.SetNavigationInTransition(this, navigateInTransition);
            TransitionService.SetNavigationOutTransition(this, navigateOutTransition);
            #endregion


            string koç = "KOÇ 21 Mart-19 Nisan";
            string boga = "BOGA 20 Nisan-20 Mayıs";
            string ikizler = "IKIZLER 21 Mayıs-21 Haziran";
            string yengec = "YENGEC 22 Haziran-22 Temmuz";
            string aslan = "ASLAN 23 Temmuz-22 Ağustos";
            string basak = "BASAK 23 Ağustos-22 Eylül";
            string terazi = "TERAZI 23 Eylül-22 Ekim";
            string akrep = "AKREP 23 Ekim-21 Kasım";
            string yay = "YAY 22 Kasım-21 Aralık";
            string oglak = "OGLAK 22 Aralık-19 Ocak";
            string kova = "KOVA 20 Ocak-18 Şubat";
            string balık = "BALIK 19 Şubat-20 Mart";

            listPicker.ItemsSource = new List<string>() { koç, boga, ikizler, yengec, aslan, basak, terazi, akrep, yay, oglak, kova, balık };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int burc = listPicker.SelectedIndex + 1;
            PhoneApplicationService.Current.State["burc"] = burc; 
            NavigationService.GoBack();
            
        }
    }
}