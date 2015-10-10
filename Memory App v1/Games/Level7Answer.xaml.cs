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
    public sealed partial class Level7Answer : Page
    {
        bool advanceToB3 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Level7Answer()
        {
            this.InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            if (tbxTopLeft.Text == Level7.UnitsShowns[0])
            {
                tbkResult.Text += "\nTop left number: Correct  ";
                tbxTopLeft.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nTop left number: Incorrect || Correct Answer: " + Level7.UnitsShowns[0];
                tbxTopLeft.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }


            if (tbxTopRight.Text == Level7.UnitsShowns[1])
            {
                tbkResult.Text += "\nTop right number: Correct ";
                tbxTopRight.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nTop right number: Incorrect || Correct Answer: " + Level7.UnitsShowns[1];
                tbxTopRight.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            if (tbxBottomLeft.Text == Level7.UnitsShowns[2])
            {
                tbkResult.Text += "\nBottom left number: Correct ";
                tbxBottomLeft.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nBottom left number: Incorrect || Correct Answer: " + Level7.UnitsShowns[2];
                tbxBottomLeft.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            if (tbxBottomRight.Text == Level7.UnitsShowns[3])
            {
                tbkResult.Text += "\nBottom right number: Correct ";
                tbxBottomRight.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nBottom right number: Incorrect || Correct Answer: " + Level7.UnitsShowns[3];
                tbxBottomRight.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            tbkResult.Text += "\n";
//textboxes
            if (textBox1.Text == Level7.UnitsShowns[4])
            {
                tbkResult.Text += "\nLetter 1: Correct ";
                textBox1.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 1: Incorrect || Correct Answer: " + Level7.UnitsShowns[4];
                textBox1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            //
            if (textBox2.Text == Level7.UnitsShowns[5])
            {
                tbkResult.Text += "\nLetter 2: Correct ";
                textBox2.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 2: Incorrect || Correct Answer: " + Level7.UnitsShowns[5];
                textBox2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            if (textBox3.Text == Level7.UnitsShowns[6])
            {
                tbkResult.Text += "\nLetter 3: Correct ";
                textBox3.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 3: Incorrect || Correct Answer: " + Level7.UnitsShowns[6];
                textBox3.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            //
            if (textBox4.Text == Level7.UnitsShowns[7])
            {
                tbkResult.Text += "\nLetter 4: Correct ";
                textBox4.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 4: Incorrect || Correct Answer: " + Level7.UnitsShowns[7];
                textBox4.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            //
            if (textBox5.Text == Level7.UnitsShowns[8])
            {
                tbkResult.Text += "\nLetter 5: Correct ";
                textBox5.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 5: Incorrect || Correct Answer: " + Level7.UnitsShowns[8];
                textBox5.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            //
            if (textBox6.Text == Level7.UnitsShowns[9])
            {
                tbkResult.Text += "\nLetter 6: Correct ";
                textBox6.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tbkResult.Text += "\nLetter 6: Incorrect || Correct Answer: " + Level7.UnitsShowns[9];
                textBox6.Foreground = new SolidColorBrush(Colors.Red);
                advanceToB3 = false;
            }

            if (advanceToB3)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["B3"] = 1;
            }

        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level7));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level8));
        }

        //focus states
        private void tbxTopLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxTopLeft.Text.Length == 2)
            {
                tbxTopRight.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxTopRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxTopRight.Text.Length == 2)
            {
                tbxBottomRight.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxBottomRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBottomRight.Text.Length == 2)
            {
                tbxBottomLeft.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxBottomLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBottomLeft.Text.Length == 2)
            {
                textBox1.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text.Length == 1)
            {
            textBox2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox2.Text.Length == 1)
            textBox3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox3.Text.Length == 1)
            textBox4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox4.Text.Length == 1)
            textBox5.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }

        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox5.Text.Length == 1)
            textBox6.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }
    }
}
