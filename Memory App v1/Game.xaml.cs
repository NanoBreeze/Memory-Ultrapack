using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Game()
        {
            this.InitializeComponent();

            //reads app settings and adjusts accordingly
            if ((int)settings.Values["A1"] == 1)
            {
                btnGoToLevel1.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                throw new ArgumentException("A1 is zero");
            }


            if ((int) settings.Values["A2"] == 1)
            {
                btnGoToLevel2.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel2.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["A3"] == 1)
            {
                btnGoToLevel3.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel3.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["A4"] == 1)
            {
                btnGoToLevel4.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel4.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["A5"] == 1)
            {
                btnGoToLevel5.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel5.Background = new SolidColorBrush(Colors.DarkGray);
            }

            //B section
            if ((int)settings.Values["B1"] == 1)
            {
                btnGoToLevel6.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel6.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["B2"] == 1)
            {
                btnGoToLevel7.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel7.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["B3"] == 1)
            {
                btnGoToLevel8.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel8.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["B4"] == 1)
            {
                btnGoToLevel9.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel9.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["B5"] == 1)
            {
                btnGoToLevel10.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel10.Background = new SolidColorBrush(Colors.DarkGray);
            }

            //C section
            if ((int)settings.Values["C1"] == 1)
            {
                btnGoToLevel11.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel11.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["C2"] == 1)
            {
                btnGoToLevel12.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel12.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["C3"] == 1)
            {
                btnGoToLevel13.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel13.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["C4"] == 1)
            {
                btnGoToLevel14.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel14.Background = new SolidColorBrush(Colors.DarkGray);
            }

            if ((int)settings.Values["C5"] == 1)
            {
                btnGoToLevel15.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                btnGoToLevel15.Background = new SolidColorBrush(Colors.DarkGray);
            }
            
        }

        private void btnGoToLevel1_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["A1"] == 1)
            {
                Frame.Navigate(typeof(Games.Level1));
            }
        }

        private void btnGoToLevel2_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["A2"] == 1)
            {
                Frame.Navigate(typeof(Games.Level2));
            }
        }

        private void btnGoToLevel3_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["A3"] == 1)
            Frame.Navigate(typeof(Games.Level3));
        }

        private void btnGoToLevel4_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["A4"] == 1)
            Frame.Navigate(typeof(Games.Level4));
        }

        private void btnGoToLevel5_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["A5"] == 1)
            Frame.Navigate(typeof(Games.Level5));
        }

        private void btnGoToLevel6_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["B1"] == 1)
            Frame.Navigate(typeof(Games.Level6));
        }
        

        private void btnGoToLevel7_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["B2"] == 1)
            Frame.Navigate(typeof(Games.Level7));
        }

        private void btnGoToLevel8_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["B3"] == 1)
                Frame.Navigate(typeof(Games.Level8));
        }

        private void btnGoToLevel9_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["B4"] == 1)
                Frame.Navigate(typeof(Games.Level9));
        }

        private void btnGoToLevel10_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["B5"] == 1)
                Frame.Navigate(typeof(Games.Level10));
        }

        private void btnGoToLevel11_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["C1"] == 1)
                Frame.Navigate(typeof(Games.Level11));
        }
        private void btnGoToLevel12_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["C2"] == 1)
                Frame.Navigate(typeof(Games.Level12));
        }

        private void btnGoToLevel13_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["C3"] == 1)
                Frame.Navigate(typeof(Games.Level13));
        }

        private void btnGoToLevel14_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["C4"] == 1)
                Frame.Navigate(typeof(Games.Level14));
        }

        private void btnGoToLevel15_Click(object sender, RoutedEventArgs e)
        {
            if ((int)settings.Values["C5"] == 1)
                Frame.Navigate(typeof(Games.Level15));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void appbarbuttonMainPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

    }
}
