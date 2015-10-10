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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level3Answer : Page
    {
        bool advanceToA4 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Level3Answer()
        {
            this.InitializeComponent();
        }
         private void btnCheck_Click(object sender, RoutedEventArgs e)
         {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            if (tbxNumberOfCapitalNumber.Text == Level3.NumberOfCapitalNumber.ToString())
            {
                tbkResult.Text += "Q1 is right";
            }
            else
            {
                tbkResult.Text += "Q1 is Incorrect || There were " + Level3.NumberOfCapitalNumber.ToString() + " capital numbers.";
                advanceToA4 = false;
            }

            tbkResult.Text += "\n";

            //
            if (tbxLetter1.Text == Level3.UnitsShowns[5])
            {
                tbkResult.Text += "\nLetter 1: Correct ";
                tbxLetter1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 1: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[5];
                tbxLetter1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            //
            if (tbxLetter2.Text == Level3.UnitsShowns[6])
            {
                tbkResult.Text += "\nLetter 2: Correct ";
                tbxLetter2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 2: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[6];
                tbxLetter2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            //
            if (tbxLetter3.Text == Level3.UnitsShowns[7])
            {
                tbkResult.Text += "\nLetter 3: Correct ";
                tbxLetter3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 3: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[7];
                tbxLetter3.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            //
            if (tbxLetter4.Text == Level3.UnitsShowns[8])
            {
                tbkResult.Text += "\nLetter 4: Correct ";
                tbxLetter4.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 4: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[8];
                tbxLetter4.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            //
            if (tbxLetter5.Text == Level3.UnitsShowns[9])
            {
                tbkResult.Text += "\nLetter 5: Correct ";
                tbxLetter5.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 5: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[9];
                tbxLetter5.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            //
            if (tbxLetter6.Text == Level3.UnitsShowns[10])
            {
                tbkResult.Text += "\nLetter 6: Correct ";
                tbxLetter6.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 6: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[10];
                tbxLetter6.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            //
            if (tbxLetter7.Text == Level3.UnitsShowns[11])
            {
                tbkResult.Text += "\nLetter 7: Correct ";
                tbxLetter7.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 7: Incorrect" + " || Correct Answer: " + Level3.UnitsShowns[11];
                tbxLetter7.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA4 = false;
            }

            if (advanceToA4)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["A4"] = 1;
            }
         }

         private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
         {
             Frame.Navigate(typeof(Game));
         }

         private void AppBarButton_Click(object sender, RoutedEventArgs e)
         {
             Frame.Navigate(typeof(Level3));
         }

         private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
         {
             Frame.Navigate(typeof(MainPage));
         }

         private void btnNextLevel_Click(object sender, RoutedEventArgs e)
         {
             Frame.Navigate(typeof(Level4));
         }

        //focus states
         private void tbxNumberOfCapitalNumber_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxNumberOfCapitalNumber.Text.Length == 1)
             tbxLetter1.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }

         private void tbxLetter1_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxLetter1.Text.Length == 1)
             tbxLetter2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }

         private void tbxLetter2_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxLetter2.Text.Length == 1)
             tbxLetter3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }

         private void tbxLetter3_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxLetter3.Text.Length == 1)
             tbxLetter4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }

         private void tbxLetter4_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxLetter4.Text.Length == 1)
             tbxLetter5.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }

         private void tbxLetter5_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxLetter5.Text.Length == 1)
             tbxLetter6.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }

         private void tbxLetter6_TextChanged(object sender, TextChangedEventArgs e)
         {
             if (tbxLetter6.Text.Length == 1)
             tbxLetter7.Focus(Windows.UI.Xaml.FocusState.Programmatic);
         }
    }
}
