using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Reflection;
using System.Collections.ObjectModel;

namespace PanoramaApp2
{
    public partial class PivotPage4 : PhoneApplicationPage
    {
      
        public PivotPage4()
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

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int color = listPickerColor.SelectedIndex + 1;
             PhoneApplicationService.Current.State["color"] = color;
            NavigationService.GoBack();
        }
     

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var colors = new List<ColorSelectModel>();
            var accentColor = (Color)Resources["PhoneAccentColor"];
            colors.Add(new ColorSelectModel("Accent Color", accentColor));
            colors.AddRange(
                    typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public)
                        .Where(p => p.PropertyType == typeof(Color))
                        .Where(p => p.Name != "Transperant" && p.Name != "Black")
                        .Select(p => new ColorSelectModel(p.Name, (Color)p.GetValue(typeof(Colors), null))));
            listPickerColor.ItemsSource = listPickerColor.ItemsSource ?? new ObservableCollection<ColorSelectModel>(colors);
        }
    }

    public class ColorSelectModel
    {
        public ColorSelectModel(string text, Color color)
        {
            this.Text = text;
            this.Color = color;
            this.ColorBrush = new SolidColorBrush(color);
        }
        public string Text { get; set; }
        public Color Color { get; set; }
        public SolidColorBrush ColorBrush { get; set; }
    }
    
       
  }
