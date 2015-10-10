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
    public sealed partial class Level1Answer : Page
    {
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
        bool levelPassed = true;

        public Level1Answer()
        {
            this.InitializeComponent();
        }


        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;
            if (tbxUnit1.Text == Level1.UnitsDisplayeds[0])
            {
                tbkResult.Text += "\nDigit 1: Correct";
                tbxUnit1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 1: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[0];
                tbxUnit1.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            //
            if (tbxUnit2.Text == Level1.UnitsDisplayeds[1])
            {
                tbkResult.Text += "\nDigit 2: Correct";
                tbxUnit2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 2: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[1];
                tbxUnit2.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            //
            if (tbxUnit3.Text == Level1.UnitsDisplayeds[2])
            {
                tbkResult.Text += "\nDigit 3: Correct";
                tbxUnit3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 3: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[2];
                tbxUnit3.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            //
            if (tbxUnit4.Text == Level1.UnitsDisplayeds[3])
            {
                tbkResult.Text += "\nDigit 4: Correct";
                tbxUnit4.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 4: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[3];
                tbxUnit4.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            //
            if (tbxUnit5.Text == Level1.UnitsDisplayeds[4])
            {
                tbkResult.Text += "\nDigit 5: Correct";
                tbxUnit5.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nDigit 5: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[4];
                tbxUnit5.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            //
            if (tbxUnit6.Text == Level1.UnitsDisplayeds[5])
            {
                tbkResult.Text += "\n\nLetter 1: Correct";
                tbxUnit6.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\n\nLetter 1: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[5];
                tbxUnit6.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            //
            if (tbxUnit7.Text == Level1.UnitsDisplayeds[6])
            {
                tbkResult.Text += "\nLetter 2: Correct";
                tbxUnit7.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 2: Incorrect" + " || Correct Answer: " + Level1.UnitsDisplayeds[6];
                tbxUnit7.Foreground = new SolidColorBrush(Colors.Red);
                levelPassed = false;
            }

            if (levelPassed)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["A2"] = 1;
            }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level1));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level2));
        }


        //getting focus
        private void tbxUnit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnit1.Text.Length == 1)
            tbxUnit2.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        private void tbxUnit2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnit2.Text.Length == 1)
            tbxUnit3.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        private void tbxUnit3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnit3.Text.Length == 1)
                tbxUnit4.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        private void tbxUnit4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnit4.Text.Length == 1)
                tbxUnit5.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        private void tbxUnit5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnit5.Text.Length == 1)
                tbxUnit6.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        private void tbxUnit6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnit6.Text.Length == 1)
                tbxUnit7.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }
    }
}
