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
    public partial class PivotPage7 : PhoneApplicationPage
    {
        public PivotPage7()
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

            listPicker.ItemsSource = new List<string>() { "Pop", "Rock", "Rap" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int muzik = listPicker.SelectedIndex + 1;
            PhoneApplicationService.Current.State["muzik"] = muzik;
            NavigationService.GoBack();
        }
    }
}