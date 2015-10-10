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
    public sealed partial class Level4Answer : Page
    {

        bool advanceToA5 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Level4Answer()
        {
            this.InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            if (tbxSymbol1.Text == Level4.UnitsShowns[3])
            {
                tbkResult.Text += "\nSymbol 1: Correct ";
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 1: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[3];
                tbxSymbol1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            //
            if (tbxSymbol2.Text == Level4.UnitsShowns[2])
            {
                tbkResult.Text += "\nSymbol 2: Correct ";
                tbxSymbol2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 2: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[2];
                tbxSymbol2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            //
            if (tbxSymbol3.Text == Level4.UnitsShowns[1])
            {
                tbkResult.Text += "\nSymbol 3: Correct ";
                tbxSymbol3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 3: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[1];
                tbxSymbol3.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            if (tbxSymbol4.Text == Level4.UnitsShowns[0])
            {
                tbkResult.Text += "\nSymbol 4: Correct ";
                tbxSymbol4.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 4: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[0];
                tbxSymbol4.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            tbkResult.Text += "\n";

            //
            if (tbxSymbol5.Text == Level4.UnitsShowns[7])
            {
                tbkResult.Text += "\nSymbol 5: Correct ";
                tbxSymbol5.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 5: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[7];
                tbxSymbol5.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            //
            if (tbxSymbol6.Text == Level4.UnitsShowns[6])
            {
                tbkResult.Text += "\nSymbol 6: Correct ";
                tbxSymbol6.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 6: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[6];
                tbxSymbol6.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            //
            if (tbxSymbol7.Text == Level4.UnitsShowns[5])
            {
                tbkResult.Text += "\nSymbol 7: Correct ";
                tbxSymbol7.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 7: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[5];
                tbxSymbol7.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            //
            if (tbxSymbol8.Text == Level4.UnitsShowns[4])
            {
                tbkResult.Text += "\nSymbol 8: Correct ";
                tbxSymbol8.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nSymbol 8: Incorrect" + " || Correct Answer: " + Level4.UnitsShowns[4];
                tbxSymbol8.Foreground = new SolidColorBrush(Colors.Red);
                advanceToA5 = false;
            }

            if (advanceToA5)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();

                settings.Values["A5"] = 1;
            }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level4));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level5));
        }


        //focus states
        private void tbxSymbol1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol1.Text.Length == 1)
            tbxSymbol2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol2.Text.Length == 1)
            tbxSymbol3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol3.Text.Length == 1)
            tbxSymbol4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol4.Text.Length == 1)
            tbxSymbol5.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol5.Text.Length == 1)
            tbxSymbol6.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol6.Text.Length == 1)
            tbxSymbol7.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void tbxSymbol7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxSymbol7.Text.Length == 1)
            tbxSymbol8.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }
    }
}
