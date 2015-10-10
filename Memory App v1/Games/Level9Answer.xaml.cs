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
    public sealed partial class Level9Answer : Page
    {
        bool advanceToB5 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Level9Answer()
        {
            this.InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {

            int letter1allRight = 1;     //0 if wrong; 1 is right; 2 is missed
            int letter2allRight = 1;
            int letter3allRight = 1;
            int letter4allRight = 1;
            int unitsShowingAllright = 1;

            tbkResult.Text = "";
            tbkResult.FontSize = Frame.ActualHeight / 30;

            //tbxLetter1_Answer
            for (int i = 0; i < tbxLetter1_Answer.Text.Length; i++)
            {
                if (tbxLetter1_Answer.Text[i].ToString() == Level9.UnitsShowns[i])
                {
                 //   tbkResult.Text += "Correct ";
                }
                else
                {
                 //   tbkResult.Text += "Incorrect ";
                    letter1allRight = 0;
                    advanceToB5 = false;
                }
            }

            if (tbxLetter1_Answer.Text == "")
            {
                letter1allRight = 2;
                advanceToB5 = false;
            }


            //tbxLetter2_Answer, note that i = 0 
            for (int i = 0; i < tbxLetter1_Answer.Text.Length; i++)
            {
                if (tbxLetter1_Answer.Text[i].ToString() == Level9.UnitsShowns[i+3])
                {
              //      tbkResult.Text += "Correct ";
                }
                else
                {
              //      tbkResult.Text += "Incorrect ";
                    letter2allRight = 0;
                    advanceToB5 = false;
                }
            }

            if (tbxLetter2_Answer.Text == "")
            {
                letter2allRight = 2;
                advanceToB5 = false;
            }


            //tbxLetter3_Answer,  note that i = 0 
            for (int i = 0; i < tbxLetter1_Answer.Text.Length; i++)
            {
                if (tbxLetter1_Answer.Text[i].ToString() == Level9.UnitsShowns[i+6])
                {
                   // tbkResult.Text += "Correct ";
                }
                else
                {
                 //   tbkResult.Text += "Incorrect ";
                    letter3allRight = 0;
                    advanceToB5 = false;
                }
            }


            if (tbxLetter3_Answer.Text == "")
            {
                letter3allRight = 2;
                advanceToB5 = false;
            }

     


            //tbxLetter4_Answer,  note that i = 0 
            for (int i = 0; i < tbxLetter1_Answer.Text.Length; i++)
            {
                if (tbxLetter1_Answer.Text[i].ToString() == Level9.UnitsShowns[i+9])
                {
              //      tbkResult.Text += "Correct ";
                }
                else
                {
               //     tbkResult.Text += "Incorrect ";
                    letter4allRight = 0;
                    advanceToB5 = false;
                }
            }

            if (tbxLetter4_Answer.Text == "")
            {
                letter4allRight = 2;
                advanceToB5 = false;
            }


            //tbxUnitsShowing1_Answer
            for (int i = 0; i < tbxUnitsShowing1_Answer.Text.Length; i++)
            {
                if (tbxUnitsShowing1_Answer.Text[i].ToString() == Level9.UnitsShowns[i+12])
                {
                  //  tbkResult.Text += "Correct ";
                }
                else
                {
                  //  tbkResult.Text += "Incorrect ";
                    unitsShowingAllright = 0;
                    advanceToB5 = false;
                }
            }


            if (tbxUnitsShowing1_Answer.Text == "")
            {
                unitsShowingAllright = 2;
                advanceToB5 = false;
            }

            //show results and colours
            if (letter1allRight == 1)
            {
                tbkResult.Text += "Letter 1: Correct";
                tbxLetter1_Answer.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (letter1allRight == 0)
            {
                tbkResult.Text += "Letter 1: Incorrect || Correct Answer: " + Level9.UnitsShowns[0] + Level9.UnitsShowns[1] + Level9.UnitsShowns[2];
                tbxLetter1_Answer.Foreground = new SolidColorBrush(Colors.Red);

            }
            if (letter1allRight == 2)
            {
                tbkResult.Text += "Letter 1: Missed || Correct Answer: " + Level9.UnitsShowns[0] + Level9.UnitsShowns[1] + Level9.UnitsShowns[2];
            }



            if (letter2allRight == 1)
            {
                tbkResult.Text += "\nLetter 2: Correct";
                tbxLetter2_Answer.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (letter2allRight == 0)
            {
                tbkResult.Text += "\nLetter 2: Incorrect || Correct Answer: " + Level9.UnitsShowns[3] + Level9.UnitsShowns[4] + Level9.UnitsShowns[5];
                tbxLetter2_Answer.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (letter2allRight == 2)
            {
                tbkResult.Text += "\nLetter 2: Missed || Correct Answer: " + Level9.UnitsShowns[3] + Level9.UnitsShowns[4] + Level9.UnitsShowns[5];
            }



            if (letter3allRight == 1)
            {
                tbkResult.Text += "\nLetter 3: Correct";
                tbxLetter3_Answer.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (letter3allRight == 0)
            {
                tbkResult.Text += "\nLetter 3: Incorrect || Correct Answer: " + Level9.UnitsShowns[6] + Level9.UnitsShowns[7] + Level9.UnitsShowns[8];
                tbxLetter3_Answer.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (letter3allRight == 2)
            {
                tbkResult.Text += "\nLetter 3: Missed || Correct Answer: " + Level9.UnitsShowns[6] + Level9.UnitsShowns[7] + Level9.UnitsShowns[8];
            }



            if (letter4allRight == 1)
            {
                tbkResult.Text += "\nLetter 4: Correct";
                tbxLetter4_Answer.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (letter4allRight == 0)
            {
                tbkResult.Text += "\nLetter 4: Incorrect || Correct Answer: " + Level9.UnitsShowns[9] + Level9.UnitsShowns[01] + Level9.UnitsShowns[11];
                tbxLetter4_Answer.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (letter4allRight == 2)
            {
                tbkResult.Text += "\nLetter 4: Missed || Correct Answer: " + Level9.UnitsShowns[9] + Level9.UnitsShowns[01] + Level9.UnitsShowns[11];
            }


            if (unitsShowingAllright == 1)
            {
                tbkResult.Text += "\n\n6-digit number: Correct";
                tbxUnitsShowing1_Answer.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (unitsShowingAllright == 0)
            {
                tbkResult.Text += "\n\n6-digit number: Incorrect || Correct Answer: " + Level9.UnitsShowns[12] + Level9.UnitsShowns[13] + Level9.UnitsShowns[14]
                    + Level9.UnitsShowns[15] + Level9.UnitsShowns[16] + Level9.UnitsShowns[17];
                tbxUnitsShowing1_Answer.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (unitsShowingAllright == 2)
            {
                tbkResult.Text += "\n\n6-digit number: Incorrect || Correct Answer: " + Level9.UnitsShowns[12] + Level9.UnitsShowns[13] + Level9.UnitsShowns[14]
                  + Level9.UnitsShowns[15] + Level9.UnitsShowns[16] + Level9.UnitsShowns[17];
            }

            if (advanceToB5)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["B5"] = 1;
            }

        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level9));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level10));
        }

        //focus state
        private void tbxUnitsShowing1_Answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxUnitsShowing1_Answer.Text.Length == 6)
            {
                tbxLetter1_Answer.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxLetter1_Answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxLetter1_Answer.Text.Length == 3)
            {
                tbxLetter2_Answer.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxLetter2_Answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxLetter2_Answer.Text.Length == 3)
            {
                tbxLetter3_Answer.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }

        private void tbxLetter3_Answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxLetter3_Answer.Text.Length == 3)
            {
                tbxLetter4_Answer.Focus(Windows.UI.Xaml.FocusState.Programmatic);
            }
        }
    }
}
