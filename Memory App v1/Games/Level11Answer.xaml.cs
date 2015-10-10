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
    public sealed partial class Level11Answer : Page
    {

        bool advanceToC2 = false;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
        
        public Level11Answer()
        {
            this.InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {

            int letter1AllRight = 1;
            int letter2AllRight = 1;
            int symbol1AllRight = 1;        //1 is right, 0 is wrong, 2 is missed
            int symbol2AllRight = 1;


            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            //==checking numbers
            if (tbxNumbersChanging1.Text == Level11.UnitsShowns[0])
            {
                tbkResult.Text += "First flashing number: Correct ";
                tbxNumbersChanging1.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (tbxNumbersChanging1.Text == "")
            {
                tbkResult.Text += "First flashing number: Missed || Correct Answer: " + Level11.UnitsShowns[0];
                advanceToC2 = false;
            }
            else
            {
                tbkResult.Text += "First flashing number: Incorrect || Correct Answer: " + Level11.UnitsShowns[0];
                tbxNumbersChanging1.Foreground = new SolidColorBrush(Colors.Red);
                advanceToC2 = false;
            }


            //
            if (tbxNumbersChanging2.Text == Level11.UnitsShowns[1])
            {
                tbkResult.Text += "\nSecond flashing number: Correct ";
                tbxNumbersChanging2.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (tbxNumbersChanging2.Text == "")
            {
                tbkResult.Text += "Second flashing number: Missed || Correct Answer: " + Level11.UnitsShowns[1];
                advanceToC2 = false;
            }
            else
            {
                tbkResult.Text += "\nSecond flashing number: Incorrect || Correct Answer: " + Level11.UnitsShowns[1];
                tbxNumbersChanging2.Foreground = new SolidColorBrush(Colors.Red);
                advanceToC2 = false;
            }


            //
            if (tbxNumbersChanging3.Text == Level11.UnitsShowns[2])
            {
                tbkResult.Text += "\nThird flashing number: Correct ";
                tbxNumbersChanging3.Foreground = new SolidColorBrush(Colors.Green);
            }
             if (tbxNumbersChanging3.Text == "")
             {
                 tbkResult.Text += "\nThird flashing number: Incorrect || Correct Answer: " + Level11.UnitsShowns[2];
                 advanceToC2 = false;
             }
            else
            {
                tbkResult.Text += "\nThird flashing number: Incorrect || Correct Answer: " + Level11.UnitsShowns[2];
                tbxNumbersChanging3.Foreground = new SolidColorBrush(Colors.Red);
                advanceToC2 = false;
            }


            //
            if (tbxNumbersChanging4.Text == Level11.UnitsShowns[3])
            {
                tbkResult.Text += "\nFourth flashing number: Correct ";
                tbxNumbersChanging4.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (tbxNumbersChanging4.Text == "")
            {
                tbkResult.Text += "\nFourth flashing number: Incorrect || Correct Answer: " + Level11.UnitsShowns[3];
                advanceToC2 = false;
            }
            else
            {
                tbkResult.Text += "\nFourth flashing number: Incorrect || Correct Answer: " + Level11.UnitsShowns[3];
                tbxNumbersChanging4.Foreground = new SolidColorBrush(Colors.Red);
                advanceToC2 = false;
            }


            //==checking letters

            //we set maxlength to prevent overflow
        
            for (int i = 0; i < tbxUnitsShown1.Text.Length; i++)
            {
                if (tbxUnitsShown1.Text[i].ToString() == Level11.UnitsShowns[i+4])
                {
                  //  tbkResult.Text += "Correct ";
                }
                else
                {
                   // tbkResult.Text += "Incorrect ";
                    letter1AllRight = 0;
                    advanceToC2 = false;
                }
            }

            if (tbxUnitsShown1.Text == "")
            {
               // tbkResult.Text += "Missed ";
                letter1AllRight = 2;
                advanceToC2 = false;
            }


    
            for (int i = 0; i < tbxUnitsShown2.Text.Length; i++)
            {
                if (tbxUnitsShown2.Text[i].ToString() == Level11.UnitsShowns[i + 8])
                {
                   // tbkResult.Text += "Correct ";
                }
                else
                {
                  //  tbkResult.Text += "Incorrect ";
                    letter2AllRight = 0;
                    advanceToC2 = false;
                }
            }

            if (tbxUnitsShown2.Text == "")
            {
               // tbkResult.Text += "Missed ";
                letter2AllRight = 2;
                advanceToC2 = false;
            }

            //==checking symbols

           
            for (int i = 0; i < tbxUnitsShown3.Text.Length; i++)
            {
                if (tbxUnitsShown3.Text[i].ToString() == Level11.UnitsShowns[i + 12])
                {
                  //  tbkResult.Text += "Correct ";
                }
                else
                {
                  //  tbkResult.Text += "Incorrect ";
                    symbol1AllRight = 0;
                    advanceToC2 = false;
                }
            }

            if (tbxUnitsShown3.Text == "")
            {
                //tbkResult.Text += "Missed ";
                symbol1AllRight = 2;
                advanceToC2 = false;
            }

           
            for (int i = 0; i < tbxUnitsShown4.Text.Length; i++)
            {
                if (tbxUnitsShown4.Text[i].ToString() == Level11.UnitsShowns[i + 18])
                {
                    //tbkResult.Text += "Correct ";
                }
                else
                {
                    //tbkResult.Text += "Incorrect ";
                    symbol2AllRight = 0;
                    advanceToC2 = false;
                }
            }

            if (tbxUnitsShown4.Text == "")
            {
                //tbkResult.Text += "Missed ";
                symbol2AllRight = 2;
                advanceToC2 = false;
            }

            tbkResult.Text += "\n";
            //show results and colours
            if (letter1AllRight == 1)
            {
                tbkResult.Text += "\nFirst group of letters: Correct";
                tbxUnitsShown1.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (letter1AllRight == 0)
            {
                tbkResult.Text += "\nFirst group of letters: Incorrect || Correct Answer: " + Level11.UnitsShowns[4] + Level11.UnitsShowns[5] + Level11.UnitsShowns[6]
                    + Level11.UnitsShowns[7];
                tbxUnitsShown1.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (letter1AllRight == 2)
            {
                tbkResult.Text += "\nFirst group of letters: Missed || Correct Answer: " + Level11.UnitsShowns[4] + Level11.UnitsShowns[5] + Level11.UnitsShowns[6]
                    + Level11.UnitsShowns[7];
            }


            if (letter2AllRight == 1)
            {
                tbkResult.Text += "\nSecond group of letters: Correct";
                tbxUnitsShown2.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (letter2AllRight == 0)
            {
                tbkResult.Text += "\nSecond group of letters: Incorrect || Correct Answer: " + Level11.UnitsShowns[8] + Level11.UnitsShowns[9] + Level11.UnitsShowns[10]
                    + Level11.UnitsShowns[11];
                tbxUnitsShown2.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (letter2AllRight == 2)
            {
                tbkResult.Text += "\nSecond group of letters: Missed || Correct Answer: " + Level11.UnitsShowns[8] + Level11.UnitsShowns[9] + Level11.UnitsShowns[10]
                    + Level11.UnitsShowns[11];
            }



            if (symbol1AllRight == 1)
            {
                tbkResult.Text += "\nFirst group of symbols: Correct";
                tbxUnitsShown2.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (symbol1AllRight == 0)
            {
                tbkResult.Text += "\nFirst group of symbols: Incorrect || Correct Answer: " + Level11.UnitsShowns[12] + Level11.UnitsShowns[13] + Level11.UnitsShowns[14]
                    + Level11.UnitsShowns[15] + Level11.UnitsShowns[16] + Level11.UnitsShowns[17];
                tbxUnitsShown2.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (symbol1AllRight == 2)
            {
                tbkResult.Text += "\nFirst group of symbols: Missed || Correct Answer: " + Level11.UnitsShowns[12] + Level11.UnitsShowns[13] + Level11.UnitsShowns[14]
                    + Level11.UnitsShowns[15] + Level11.UnitsShowns[16] + Level11.UnitsShowns[17];
            }



            if (symbol2AllRight == 1)
            {
                tbkResult.Text += "\nSecond group of symbols: Correct";
                tbxUnitsShown2.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (symbol2AllRight == 0)
            {
                tbkResult.Text += "\nSecond group of symbols: Incorrect || Correct Answer: " + Level11.UnitsShowns[18] + Level11.UnitsShowns[19] + Level11.UnitsShowns[20]
                    + Level11.UnitsShowns[21] + Level11.UnitsShowns[22] + Level11.UnitsShowns[23];
                tbxUnitsShown2.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (symbol2AllRight == 2)
            {
                tbkResult.Text += "\nSecond group of symbols: Missed || Correct Answer: " + Level11.UnitsShowns[18] + Level11.UnitsShowns[19] + Level11.UnitsShowns[20]
                    + Level11.UnitsShowns[21] + Level11.UnitsShowns[22] + Level11.UnitsShowns[23];
            }



            if (advanceToC2)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["C2"] = 1;
            }







        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level11));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level2));
        }

        private void tbxNumbersChanging1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumbersChanging1.Text.Length == 3)
            {
                tbxNumbersChanging2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumbersChanging2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumbersChanging2.Text.Length == 3)
            {
                tbxNumbersChanging3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumbersChanging3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumbersChanging3.Text.Length == 3)
            {
                tbxNumbersChanging4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxNumbersChanging4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxNumbersChanging4.Text.Length == 3)
            {
                tbxUnitsShown1.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxUnitsShown1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnitsShown1.Text.Length == 4)
            {
                tbxUnitsShown2.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxUnitsShown2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnitsShown2.Text.Length == 4)
            {
                tbxUnitsShown3.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxUnitsShown3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnitsShown3.Text.Length == 6)
            {
                tbxUnitsShown4.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }
    }
}
