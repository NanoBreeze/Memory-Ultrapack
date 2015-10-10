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
    public sealed partial class Level2Answer : Page
    {
        bool advanceToA3 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Level2Answer()
        {
            this.InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            if (tbxNumber1.Text == Level2.UnitsShowns[0])
            {
                tbkResult.Text += "\nDigit 1: Correct ";
                tbxNumber1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 1: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[0];
                tbxNumber1.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxNumber2.Text == Level2.UnitsShowns[1])
            {
                tbkResult.Text += "\nDigit 2: Correct ";
                tbxNumber2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 2: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[1]; ;
                tbxNumber2.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxNumber3.Text == Level2.UnitsShowns[2])
            {
                tbkResult.Text += "\nDigit 3: Correct ";
                tbxNumber3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 3: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[2]; ;
                tbxNumber3.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxNumber4.Text == Level2.UnitsShowns[3])
            {
                tbkResult.Text += "\nDigit 4: Correct ";
                tbxNumber4.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 4: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[3]; ;
                tbxNumber4.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxNumber5.Text == Level2.UnitsShowns[4])
            {
                tbkResult.Text += "\nDigit 5: Correct ";
                tbxNumber5.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 5: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[4]; ;
                tbxNumber5.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxNumber6.Text == Level2.UnitsShowns[5])
            {
                tbkResult.Text += "\nDigit 6: Correct ";
                tbxNumber6.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 6: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[5]; ;
                tbxNumber6.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //==tbxLetter
            if (tbxLetter1.Text == Level2.UnitsShowns[6])
            {
                tbkResult.Text += "\n\nLetter 1: Correct ";
                tbxLetter1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 1: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[6]; ;
                tbxLetter1.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxLetter2.Text == Level2.UnitsShowns[7])
            {
                tbkResult.Text += "\nLetter 2: Correct ";
                tbxLetter2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 2: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[7]; ;
                tbxLetter2.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxLetter3.Text == Level2.UnitsShowns[8])
            {
                tbkResult.Text += "\nLetter 3: Correct ";
                tbxLetter3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 2: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[8]; ;
                tbxLetter3.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //==tbxSymbol

            //
            if (tbxSymbol1.Text == Level2.UnitsShowns[9])
            {
                tbkResult.Text += "\n\nSymbol 1: Correct ";
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 1: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[9]; ;
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            //
            if (tbxSymbol2.Text == Level2.UnitsShowns[10])
            {
                tbkResult.Text += "\nSymbol 2: Correct ";
                tbxSymbol2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 2: Incorrect" + " || Correct Answer: " + Level2.UnitsShowns[10]; ;
                tbxSymbol2.Foreground = new SolidColorBrush(Colors.Red);
                 advanceToA3 = false;
            }

            if (advanceToA3)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["A3"] = 1;
            }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level2));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level3));
        }

        private void tbxNumber1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber1.Text.Length == 1)
            tbxNumber2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxNumber2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber2.Text.Length == 1)
            tbxNumber3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxNumber3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber3.Text.Length == 1)
            tbxNumber4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxNumber4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber4.Text.Length == 1)
            tbxNumber5.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxNumber5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber5.Text.Length == 1)
            tbxNumber6.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxNumber6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber6.Text.Length == 1)
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
            tbxSymbol1.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol1.Text.Length == 1)
            tbxSymbol2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }
    }
}
