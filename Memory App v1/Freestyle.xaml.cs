using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Freestyle : Page
    {

       //Record user's most recent number of units displayed

        int initialNumberOfNumbersToDisplay = 5;        //tells us how many numbers to display
        int initialNumberOfLettersToDisplay = 5;
        int initialNumberOfSymbolsToDisplay = 5;
        int switchOfNumberLetterSymbol;         //tells us if we are displaying a number, letter, or symbol


        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };  

        public Freestyle()
        {
            this.InitializeComponent();
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            bool addOneMoreUnit = true;

            char[] delimiter = new char[] { ' ' };
            string[] userAnswers = tbxAnswer.Text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            string[] displayedUnits = tbkDisplay.Text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < userAnswers.Length; i++)
            {
                if (displayedUnits[i] == userAnswers[i])
                {
                    tbkAnalysis.Text += "Corrent" + " ";
                }
                else
                {
                    tbkAnalysis.Text += "Incorrect" + " ";
                    addOneMoreUnit = false;
                }
            }

         

        switch (switchOfNumberLetterSymbol)
        {
            case 0:
                if (addOneMoreUnit)
                {
                    initialNumberOfNumbersToDisplay++;
                }
                else
                {
                    initialNumberOfNumbersToDisplay--;
                }
                btnModeNumber_Operation(initialNumberOfNumbersToDisplay);
                break;

            case 1:
                 if (addOneMoreUnit)
                {
                    initialNumberOfLettersToDisplay++;
                }
                else
                {
                    initialNumberOfLettersToDisplay--;
                }
                btnModeLetter_Operation(initialNumberOfLettersToDisplay);
                break;

            case 2:
                 if (addOneMoreUnit)
                {
                    initialNumberOfSymbolsToDisplay++;
                }
                else
                {
                    initialNumberOfSymbolsToDisplay--;
                }
                btnModeSymbol_Operation(initialNumberOfSymbolsToDisplay);
                break;

            default:
                break;
        }

        }

        private void btnModeNumber_Click(object sender, RoutedEventArgs e)
        {
            switchOfNumberLetterSymbol = 0;

            btnModeNumber_Operation(initialNumberOfNumbersToDisplay);
        }

        private void btnModeLetter_Click(object sender, RoutedEventArgs e)
        {
            switchOfNumberLetterSymbol = 1;

            btnModeLetter_Operation(initialNumberOfLettersToDisplay);
        }

        private void btnModeSymbol_Click(object sender, RoutedEventArgs e)
        {
            switchOfNumberLetterSymbol = 2;

            btnModeSymbol_Operation(initialNumberOfSymbolsToDisplay);
        }

        public void btnModeNumber_Operation(int i)        //i is the number of numbers to display
        {
            tbkDisplay.Text = ""; //sets textblock to empty string here to make room for new numbers

            Random random = new Random();

            for (int a = 0; a < i; a++)
            {           
                int randomNumber = random.Next(0,100);

                tbkDisplay.Text += randomNumber + " ";      //is used by btnAnswer to determine if user's answer is right or wrong
            }
        }

        public void btnModeLetter_Operation(int i)
        {
            tbkDisplay.Text = "";

            Random random = new Random();

            for (int a = 0; a < i; a++)
            {
                int randomLetterPosition = random.Next(0, letters.Length);
                string randomLetter = letters[randomLetterPosition];

                tbkDisplay.Text += randomLetter + " ";
            }
        }

        public void btnModeSymbol_Operation(int i)
        {
            tbkDisplay.Text = "";

            Random random = new Random();

            for (int a = 0; a < i; a++)
            {
                int randomSymbolPosition = random.Next(0, symbols.Length);
                string randomSymbol = symbols[randomSymbolPosition];

                tbkDisplay.Text += randomSymbol + " ";
            }
        }
    }
}
