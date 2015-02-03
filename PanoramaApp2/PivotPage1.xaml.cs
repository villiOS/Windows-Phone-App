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
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public PivotPage1()
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

            
            //string[] cinsiyet = { "Bayan", "Erkek" };
            //List<Items> source = new List<Items>();
            //source.Add(new Items() { Name = "Bayan" });
            //source.Add(new Items() { Name = "Erkek" });
            //source.Add(new Items() { Name = "Bayan" });
            
            //listPicker.ItemsSource = source;

            listPicker.ItemsSource = new List<string>() { "Kadın","Erkek" };
            
            
            
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            int cinsiyet = listPicker.SelectedIndex + 1;
            PhoneApplicationService.Current.State["cinsiyet"] = cinsiyet; //diğer sayfalara veri gönderilirken kullanılıyor
            NavigationService.GoBack();
        }

        

        
    }
}