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
    public sealed partial class Level5Answer : Page
    {

        bool advanceToB1 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Level5Answer()
        {
            this.InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            if (tbxNumber1.Text == Level5.UnitsShowns[0])
            {
                tbkResult.Text += "\nNumber 1: Correct ";
                tbxNumber1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nNumber 1: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[0];
                tbxNumber1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxNumber2.Text == Level5.UnitsShowns[1])
            {
                tbkResult.Text += "\nNumber 2: Correct ";
                tbxNumber2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nNumber 2: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[1];
                tbxNumber2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxNumber3.Text == Level5.UnitsShowns[2])
            {
                tbkResult.Text += "\nNumber 3: Correct ";
                tbxNumber3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nNumber 3: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[2];
                tbxNumber3.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxNumber4.Text == Level5.UnitsShowns[3])
            {
                tbkResult.Text += "\nNumber 4: Correct ";
                tbxNumber4.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nNumber 4: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[3];
                tbxNumber4.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxNumber5.Text == Level5.UnitsShowns[4])
            {
                tbkResult.Text += "\nNumber 5: Correct ";
                tbxNumber5.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nNumber 5: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[4];
                tbxNumber5.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            tbkResult.Text += "\n";

            //
            if (tbxLetter1.Text == Level5.UnitsShowns[7])
            {
                tbkResult.Text += "\nLetter 1: Correct ";
                tbxLetter1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 1: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[7];
                tbxLetter1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxLetter2.Text == Level5.UnitsShowns[6])
            {
                tbkResult.Text += "\nLetter 2: Correct ";
                tbxLetter2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 2: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[6];
                tbxLetter2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxLetter3.Text == Level5.UnitsShowns[5])
            {
                tbkResult.Text += "\nLetter 3: Correct ";
                tbxLetter3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 3: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[5];
                tbxLetter3.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            tbkResult.Text += "\nSymbols: ";

            //
            if (tbxSymbol1.Text == Level5.UnitsShowns[8])
            {
                tbkResult.Text += "\nSymbol 1: Correct ";
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 1: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[8];
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            //
            if (tbxSymbol2.Text == Level5.UnitsShowns[9])
            {
                tbkResult.Text += "\nSymbol 2: Correct ";
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 2: Incorrect" + " || Correct Answer: " + Level5.UnitsShowns[9];
                tbxSymbol2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB1 = false;
            }

            if (advanceToB1)
            {
                settings.Values["B1"] = 1;
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
            }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level5));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level6));
        }

        private void tbxNumber1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber1.Text.Length == 2)
            {
                tbxNumber2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumber2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber2.Text.Length == 2)
            {
                tbxNumber3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumber3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber3.Text.Length == 2)
            {
                tbxNumber4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumber4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber4.Text.Length == 2)
            {
                tbxNumber5.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumber5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumber5.Text.Length == 2)
            {
                tbxLetter1.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
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
