///////////////////////////////////////////////////////////////////////////////
///pivotlardaki butona değil de geri tuşuna basılsa bile listpickerın ilk//////
///elemanı seçilmiş gibi oluyor.Geri tuşu ile tamam butonu aynı işlevde////////
///////////////////////////////////////////////////////////////////////////////




using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Media;
using Microsoft.Xna.Framework.GamerServices;

namespace PanoramaApp2
{
    public partial class MainPage : PhoneApplicationPage
    {

        int sayac1 = 0;
        int sayac2 = 0;
        int sayac3 = 0;
        int sayac4 = 0;
        int sayac5 = 0;
        int sayac6 = 0;
        int sayac7 = 0;
        int sayac8 = 0;
        int sayac9 = 0;
        int toplam;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

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




        }







        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }


        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));

            // string a = PhoneApplicationService.Current.State["cinsiyet"].ToString();
            sayac1 = 1;
        }

        private void img_burc_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage2.xaml", UriKind.Relative));
            sayac2 = 1;
        }

        private void img_yas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage3.xaml", UriKind.Relative));
            sayac3 = 1;
        }

        private void img_color_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage4.xaml", UriKind.Relative));
            sayac4 = 1;
        }

        private void img_kutlama_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage5.xaml", UriKind.Relative));
            sayac5 = 1;
        }

        private void img_futbol_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage6.xaml", UriKind.Relative));
            sayac6 = 1;
        }

        private void img_music_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage7.xaml", UriKind.Relative));
            sayac7 = 1;
        }

        private void img_hobby_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage8.xaml", UriKind.Relative));
            sayac8 = 1;
        }

        private void img_pets_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage9.xaml", UriKind.Relative));
            sayac9 = 1;
        }

        private void img_pusula_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            toplam = sayac1 + sayac2 + sayac3 + sayac4 + sayac5 + sayac6 + sayac7 + sayac8 + sayac9;

            if (toplam > 4)
            {
                NavigationService.Navigate(new Uri("/PivotPage10.xaml", UriKind.Relative));
            }
            else
            {
                Guide.BeginShowMessageBox("Eksik Bilgi?", "Bazı bilgileri alamadık. Daha iyi sonuç için daha fazla özellik gerekli.", new string[] { "Geri Dön", "Tamam Anladım" }, 0, MessageBoxIcon.None, null, null);
                //NavigationService.Navigate(new Uri("/PivotPage11.xaml",UriKind.Relative));
            }


        }




    }
}