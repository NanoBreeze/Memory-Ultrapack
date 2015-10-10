using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Text;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml.Documents;
using Windows.System;




// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NumbersLettersSymbols : Page
    {
        //DateTime and DispatcherTImer are used if user decides to set a time limit

        DispatcherTimer timer = new DispatcherTimer();
        DateTime dateTime_CountDown = new DateTime();

        int setTimer_minute;
        int setTimer_second;

        int setTimer_minute_redo;
        int setTimer_second_redo;

        int leftRectangleCounter = 1;       //for transitioning the rectangle operated by the left button
        int rightRectangleCounter = 1;        //for transitioning the rectangle operated by the right button

        int maxNumber = 100;                //Largest number to display, used for the Go buttons but not for redo button
        int minNumber = 0;                  //Smallest number to display, used for the Go buttons but not for redo button

        int redoMinNumber;                  //Takes on the value of minNumber and is initialized when a Go button is pressed. Used by redo button
        int redoMaxNumber;                  //Takes on the value of maxNumber and is initialized when a Go button is pressed. Used by redo button

        int numberOfNumber = 0;               //number of digits to display
        int numberOfLetter;            //number of letters to display
        int numberOfSymbol;            //number of symbols to display


        //minimum and maximum number of #/L/S to display, separated by the delimiter '-', along with their redo counterparts
        int minLowerRangeNumber;
        int maxUpperRangeNumber;

        int minLowerRangeLetter;
        int maxUpperRangeLetter;

        int minLowerRangeSymbol;
        int maxUpperRangeSymbol;

        int redoMinLowerRangeNumber;
        int redoMaxUpperRangeNumber;

        int redoMinLowerRangeLetter;
        int redoMaxUpperRangeLetter;

        int redoMinLowerRangeSymbol;
        int redoMaxUpperRangeSymbol;


        //Arrays
        int[] numbers;                      //array holds all numbers to appear and put into displays, assuming positive numbers only
        string[] letters;                     //array holds all letters (lower and upper-case) to appear and put into "units"
        string[] symbols;                     //array holds all symbols to appear and put into "units"
        string[] units;                     //array holds everything, ready to be displayed from foreach loop in string type

        int[] redoNumbers;
        string[] redoPossibleLetters;
        string[] redoPossibleSymbols;
        string[] redoLetters;
        string[] redoSymbols;

        List<Run> list_runs = new List<Run>();  //Green is all right, yellow is missed, red is wrong, 
        bool captionOn = false;



        string[] possibleLetters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };     //the total letters user can choose from

        string[] allLettersRestore = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };     //allows user to choose letters multiple times

        string[] possibleSymbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };                 //the total letters user can choose from

        string[] allSymbolsRestore = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };     //allows user to choose symbols multiple times


        //======================================

        bool allLowerLettersIsOn = false;
        bool allUpperLettersIsOn = false;
        bool bool_gridMoreLettersIsOn = false;
        bool bool_gridMoreLettersIsOnFirstTime = true;

        int numberOfSymbolsSelected = 0;        //stores the number of symbols selected. If equals zero and user wants symbols, error message will appear
        int numberOfLettersSelected = 0;

        bool numberOfLettersResetToZero = false;     //if user did not select which letters to appear and wanted letters, we set the user's choice to 0. We'll let the user know about this.
        bool numberOfSymbolsResetToZero = false;

        bool[] theLetterIsOn = new bool[52];        //since we are unable to change a button's background and foreground colours according to its current colours, we'll change them according to a bool balue
        //if currently gray, then currently off, if currently red, the currently on
        Button[] letterButtons = new Button[52];      //we synchronize "thLetterIsOn" with each letter button, makes life easier


        bool[] theSymbolIsOn = new bool[10];
        Button[] symbolButtons = new Button[10];


        DispatcherTimer mostfontsizeTimer = new DispatcherTimer();
        DispatcherTimer fontsizetbxAnswer = new DispatcherTimer();

        DispatcherTimer automaticRedoWaitTimer = new DispatcherTimer();
        DateTime automaticRedoDateTime = new DateTime();

        public NumbersLettersSymbols()
        {
            this.InitializeComponent();


            #region letters
            for (int i = 0; i < 52; i++)
            {
                theLetterIsOn[i] = false;
            }

            letterButtons[0] = btnLetterA;
            letterButtons[1] = btnLetterB;
            letterButtons[2] = btnLetterC;
            letterButtons[3] = btnLetterD;
            letterButtons[4] = btnLetterE;
            letterButtons[5] = btnLetterF;
            letterButtons[6] = btnLetterG;
            letterButtons[7] = btnLetterH;
            letterButtons[8] = btnLetterI;
            letterButtons[9] = btnLetterJ;

            letterButtons[10] = btnLetterK;
            letterButtons[11] = btnLetterL;
            letterButtons[12] = btnLetterM;
            letterButtons[13] = btnLetterN;
            letterButtons[14] = btnLetterO;
            letterButtons[15] = btnLetterP;
            letterButtons[16] = btnLetterQ;
            letterButtons[17] = btnLetterR;
            letterButtons[18] = btnLetterS;
            letterButtons[19] = btnLetterT;

            letterButtons[20] = btnLetterU;
            letterButtons[21] = btnLetterV;
            letterButtons[22] = btnLetterW;
            letterButtons[23] = btnLetterX;
            letterButtons[24] = btnLetterY;
            letterButtons[25] = btnLetterZ;
            letterButtons[26] = btnLettera;
            letterButtons[27] = btnLetterb;
            letterButtons[28] = btnLetterc;
            letterButtons[29] = btnLetterd;

            letterButtons[30] = btnLettere;
            letterButtons[31] = btnLetterf;
            letterButtons[32] = btnLetterg;
            letterButtons[33] = btnLetterh;
            letterButtons[34] = btnLetteri;
            letterButtons[35] = btnLetterj;
            letterButtons[36] = btnLetterk;
            letterButtons[37] = btnLetterl;
            letterButtons[38] = btnLetterm;
            letterButtons[39] = btnLettern;

            letterButtons[40] = btnLettero;
            letterButtons[41] = btnLetterp;
            letterButtons[42] = btnLetterq;
            letterButtons[43] = btnLetterr;
            letterButtons[44] = btnLetters;
            letterButtons[45] = btnLettert;
            letterButtons[46] = btnLetteru;
            letterButtons[47] = btnLetterv;
            letterButtons[48] = btnLetterw;
            letterButtons[49] = btnLetterx;

            letterButtons[50] = btnLettery;
            letterButtons[51] = btnLetterz;

            #endregion

            #region symbols

            for (int i = 0; i < 10; i++)
            {
                theSymbolIsOn[i] = false;
            }

            symbolButtons[0] = btnSymbol1;
            symbolButtons[1] = btnSymbol2;
            symbolButtons[2] = btnSymbol3;
            symbolButtons[3] = btnSymbol4;
            symbolButtons[4] = btnSymbol5;
            symbolButtons[5] = btnSymbol6;
            symbolButtons[6] = btnSymbol7;
            symbolButtons[7] = btnSymbol8;
            symbolButtons[8] = btnSymbol9;
            symbolButtons[9] = btnSymbol10;

            #endregion

            ButtonAutomationPeer peer1 = new ButtonAutomationPeer(btn_allUppercaseLetter);
            ButtonAutomationPeer peer11 = new ButtonAutomationPeer(btnSymbol1);
            ButtonAutomationPeer peer12 = new ButtonAutomationPeer(btnSymbol2);
            ButtonAutomationPeer peer13 = new ButtonAutomationPeer(btnSymbol3);
            ButtonAutomationPeer peer14 = new ButtonAutomationPeer(btnSymbol4);
            ButtonAutomationPeer peer15 = new ButtonAutomationPeer(btnSymbol5);
            ButtonAutomationPeer peer16 = new ButtonAutomationPeer(btnSymbol6);
            ButtonAutomationPeer peer17 = new ButtonAutomationPeer(btnSymbol7);
            ButtonAutomationPeer peer18 = new ButtonAutomationPeer(btnSymbol8);
            ButtonAutomationPeer peer19 = new ButtonAutomationPeer(btnSymbol9);
            ButtonAutomationPeer peer20 = new ButtonAutomationPeer(btnSymbol10);

            peer1.Invoke();
            peer11.Invoke();
            peer12.Invoke();
            peer13.Invoke();
            peer14.Invoke();
            peer15.Invoke();
            peer16.Invoke();
            peer17.Invoke();
            peer18.Invoke();
            peer19.Invoke();
            peer20.Invoke();


            automaticRedoWaitTimer.Interval = TimeSpan.FromSeconds(1);

            mostfontsizeTimer.Interval = TimeSpan.FromMilliseconds(20);
            mostfontsizeTimer.Tick += fontsizeTimer_Tick;
            mostfontsizeTimer.Start();
        }

      
        void fontsizeTimer_Tick(object sender, object e)
        {
            mostfontsizeTimer.Stop();
            mostfontsizeTimer.Tick -= fontsizeTimer_Tick;

            tbxMaxNumber.FontSize = tbxMaxNumber.ActualHeight * 0.5;
            tbxMinNumber.FontSize = tbxMinNumber.ActualHeight * 0.5;
            tbxNumberOfLetters.FontSize = tbxNumberOfLetters.ActualHeight * 0.5;
            tbxNumberOfNumbers.FontSize = tbxNumberOfNumbers.ActualHeight * 0.5;
            tbxNumberOfSymbols.FontSize = tbxNumberOfSymbols.ActualHeight * 0.5;

            tbkResults.FontSize = Frame.ActualHeight / 35;

            tbkLettersOnButton.FontSize = Frame.ActualHeight / 40;
            tbkSymbolsOnButton.FontSize = Frame.ActualHeight / 40;


        }

        #region rectnagle's buttons
        private void btnOneRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "1";
        }

        private void btnTwoRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "2";
        }

        private void btnThreeRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "3";
        }

        private void btnFourRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "4";
        }

        private void btnFiveRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "5";
        }

        private void btnSixRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "6";
        }

        private void btnSevenRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "7";
        }

        private void btnEightRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "8";
        }

        private void btnNineRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "9";
        }

        private void btnZeroRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "0";
        }

        private void btnDashRect_Click(object sender, RoutedEventArgs e)
        {
            tbxNumberOfNumbers.Text += "-";
        }

        private void btnDeleteRect_Click(object sender, RoutedEventArgs e)
        {
            string temp = tbxNumberOfNumbers.Text;
            tbxNumberOfNumbers.Text = "";

            for (int i = 0; i < temp.Length - 1; i++)
            {
                tbxNumberOfNumbers.Text += temp[i];
            }
        }
        #endregion

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //we animate tbxAnswer to its original position
                da_tbxAnswer.To = 0;
                stytbxAnswer.Begin();

                //new timer with same settings as the previous one
                timer.Tick -= timerCountDown;
                timer.Tick += timerCountDown;

                dateTime_CountDown = DateTime.MinValue;

                if ((setTimer_minute_redo == 0 && setTimer_second_redo == 0) == false)
                {
                    dateTime_CountDown = dateTime_CountDown.AddMinutes(setTimer_minute_redo);
                    dateTime_CountDown = dateTime_CountDown.AddSeconds(setTimer_second_redo);

                    timer.Start();
                }
                tbkUnitsDisplay.Opacity = 1;

                Random random = new Random();
                int randomNumber_ = random.Next(redoMinLowerRangeNumber, redoMaxUpperRangeNumber + 1);   //number of numbers to display, for "redoNumbers" array
                redoNumbers = new int[randomNumber_];
                redoLetters = new string[random.Next(redoMinLowerRangeLetter, redoMaxUpperRangeLetter + 1)];
                redoSymbols = new string[random.Next(redoMinLowerRangeSymbol, redoMaxUpperRangeSymbol + 1)];

                units = new string[redoNumbers.Length + letters.Length + symbols.Length];


                //places random numbers into "redoNumbers" array
                for (int i = 0; i < redoNumbers.Length; i++)
                {
                    int randomNumber = random.Next(redoMinNumber, redoMaxNumber + 1);    // random values
                    redoNumbers[i] = randomNumber;
                }


                //randomly places  letters from "redoPossibleLetters" to "redoLetters"
                for (int i = 0; i < redoLetters.Length; i++)
                {
                    int randomNumber = random.Next(0, redoPossibleLetters.Length);       //finds random position in "redoPossibleLetters", thus, letters, to place into "redoLetters"

                    if (redoPossibleLetters[randomNumber] != "=")
                    {
                        redoLetters[i] = redoPossibleLetters[randomNumber];
                    }
                    else
                    {
                        i--;
                    }
                }

                //randomly places letters from "redoPossibleSymbols" to "redoSymbols"
                for (int i = 0; i < redoSymbols.Length; i++)
                {
                    int randomNumber = random.Next(0, redoPossibleSymbols.Length);       //finds random position in "redoPossibleSetters", thus, letters, to place into "redoSymbols"

                    if (redoPossibleSymbols[randomNumber] != "=")
                    {
                        redoSymbols[i] = redoPossibleSymbols[randomNumber];
                    }
                    else
                    {
                        i--;
                    }
                }

                //adds elements' values from randomly choosing values from the arrays holding numbers, letters, and symbols to "units" array.
                //We incrementally assign values to "units" array by randomly choosing which of the three other array to use, and incrementally run through those array

                int counterOfNegativeOne_Numbers = 0;
                int counterOfNegativeOne_Letters = 0;
                int counterOfNegativeOne_Symbols = 0;

                for (int i = 0; i < units.Length; i++)
                {
                    switch (random.Next(0, 2 + 1))
                    {
                        case 0:        //numbers
                            if (counterOfNegativeOne_Numbers == redoNumbers.Length)
                            {
                                i--;
                                continue;
                            }
                            for (int a = 0; a < redoNumbers.Length; a++)
                            {
                                if (redoNumbers[a] != -1)
                                {
                                    units[i] = redoNumbers[a].ToString();
                                    redoNumbers[a] = -1;
                                    counterOfNegativeOne_Numbers++;
                                    break;
                                }
                            }
                            break;

                        case 1:        //letters
                            if (counterOfNegativeOne_Letters == redoLetters.Length)
                            {
                                i--;
                                continue;
                            }
                            for (int b = 0; b < redoLetters.Length; b++)
                            {
                                if (redoLetters[b] != "=")
                                {
                                    units[i] = redoLetters[b];
                                    redoLetters[b] = "=";
                                    counterOfNegativeOne_Letters++;
                                    break;
                                }
                            }
                            break;

                        case 2:        //symbols
                            if (counterOfNegativeOne_Symbols == redoSymbols.Length)
                            {
                                i--;
                                continue;
                            }
                            for (int b = 0; b < redoSymbols.Length; b++)
                            {
                                if (redoSymbols[b] != "=")
                                {
                                    units[i] = redoSymbols[b].ToString();
                                    redoSymbols[b] = "=";
                                    counterOfNegativeOne_Symbols++;
                                    break;
                                }
                            }
                            break;

                        default: break;
                    }
                }

                list_runs.Clear();

                //display the values stored in "units" array
                tbkUnitsDisplay.Text = "";
                for (int i = 0; i < units.Length; i++)
                {
                    Run runText = new Run();
                    runText.Text = units[i];
                    list_runs.Add(runText);

                    tbkUnitsDisplay.Inlines.Add(list_runs[i]);

                    Run runSpace = new Run();
                    runSpace.Text = " ";

                    tbkUnitsDisplay.Inlines.Add(runSpace);
                }

                grid_moreLetters.Opacity = 0;
                gridLeftRect.Opacity = 0;
                gridRightRect.Opacity = 0;
                gridRectMiddle.Opacity = 0;
                bool_gridMoreLettersIsOnFirstTime = true;

                btnPeek_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnCheck_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                btnAnswer_.Visibility = Windows.UI.Xaml.Visibility.Visible;
                tbkAnswerLabel.Visibility = Windows.UI.Xaml.Visibility.Visible;

                automaticRedoDateTime = DateTime.MinValue;
                automaticRedoWaitTimer.Tick -= automaticRedoWaitTimer_Tick;

            }
            catch (Exception)
            {
                tbkUnitsDisplay.Text = "We cannot repeat the operation. Please enter a new operation.";
            }
        }

        private void btnAnswer__Click(object sender, RoutedEventArgs e)
        {
            tbkUnitsDisplay.Opacity = 0;

            tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnCheck_.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnPeek_.Visibility = Windows.UI.Xaml.Visibility.Visible;
            tbxAnswer.Text = "";
            tbxAnswer.Focus(Windows.UI.Xaml.FocusState.Programmatic);

            timer.Stop();
            timer.Tick -= timerCountDown;

            fontsizetbxAnswer.Interval = TimeSpan.FromMilliseconds(20);
            fontsizetbxAnswer.Tick += fontsizetbxAnswer_Tick;
            fontsizetbxAnswer.Start();
        }

        void fontsizetbxAnswer_Tick(object sender, object e)
        {
            fontsizetbxAnswer.Stop();
            fontsizetbxAnswer.Tick -= fontsizetbxAnswer_Tick;

            tbxAnswer.FontSize = tbxAnswer.ActualHeight * 0.5;
        }

        private void btnSee__Click(object sender, RoutedEventArgs e)
        {
            tbkUnitsDisplay.Opacity = 1;
            tbxAnswer.Text = "";
            tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            btnCheck_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            btnPeek_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            if (dateTime_CountDown.Second >= 1 || dateTime_CountDown.Minute >= 1)
            {
                timer.Tick += timerCountDown;
                timer.Start();
            }
        }

        private void btnCheck__Click(object sender, RoutedEventArgs e)
        {
            dateTime_CountDown = DateTime.MinValue;

            btnAnswer_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            tbkAnswerLabel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            btnCheck_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            btnPeek_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            bool allRight = true; //if the +/- 1 option from the ToggleMenuFlyoutItem is checked, this
            //variable determines if we should add or minus one

            //animates tbxAnswer to move downwards to not obscure tbkDisplayUnits, so the user can compare his answer to the units shown
            if (tbkUnitsDisplay.Text.Length > 62)
            da_tbxAnswer.To = gridContainingtbxAnswer.ActualHeight;
            stytbxAnswer.Begin();

            char[] delimiter = new char[] { ' ' };
            string[] answers = tbxAnswer.Text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            tbkResults.Text = "";
            tbkUnitsDisplay.Opacity = 1;

            if (captionOn)
            {
                tbkResults.Opacity = 1;
            }
            else
            {
                tbkResults.Opacity = 0;
            }

            for (int i = 0; i < Math.Min(answers.Length, units.Length); i++)
            {
                if (answers[i] == list_runs[i].Text)
                {
                    list_runs[i].Foreground = new SolidColorBrush(Colors.LawnGreen);
                    tbkResults.Text += "\n" + (i+1).ToString() + ". Correct ";
                }
                else
                {
                    list_runs[i].Foreground = new SolidColorBrush(Colors.Red);
                    allRight = false;
                    tbkResults.Text += "\n" + (i+1).ToString() + ". Incorrect ";
                }
            }

            for (int i = answers.Length; i < units.Length; i++)
            {
                list_runs[i].Foreground = new SolidColorBrush(Colors.Yellow);
                allRight = false;
                tbkResults.Text += "\n" + (i+1).ToString() + ". Missed ";
            }

            //if +/- 1 from the menuflyout was checked
            if (commandbar_options_toggle2.IsChecked == true)
            {
                if (allRight)       //if the user had answer all correctly
                {
                    //if we had been given a range, we change tbxNumberOfNumbers' text into a range. If it was not a range, then we give it a number
                    if (redoMinLowerRangeNumber == redoMaxUpperRangeNumber)
                    {
                        tbxNumberOfNumbers.Text = (redoMaxUpperRangeNumber + 1).ToString();
                    }
                    else
                    {
                        tbxNumberOfNumbers.Text = (redoMinLowerRangeNumber + 1).ToString() + "-" + (redoMaxUpperRangeNumber + 1).ToString();
                    }
                }
                else        // if the user had made a mistake
                {
                    if (redoMinLowerRangeNumber == redoMaxUpperRangeNumber)
                    {
                        tbxNumberOfNumbers.Text = (redoMaxUpperRangeNumber - 1).ToString();
                    }
                    else
                    {
                        tbxNumberOfNumbers.Text = (redoMinLowerRangeNumber - 1).ToString() + "-" + (redoMaxUpperRangeNumber - 1).ToString();
                    }
                }

                automaticRedoDateTime = automaticRedoDateTime.AddSeconds(3);
                automaticRedoWaitTimer.Tick += automaticRedoWaitTimer_Tick;
                automaticRedoWaitTimer.Start();
            }

            //if automatic redo from the menuflyout was checked
            if (commandbar_options_toggle1.IsChecked == true)
            {
                automaticRedoDateTime = automaticRedoDateTime.AddSeconds(3);
                automaticRedoWaitTimer.Tick += automaticRedoWaitTimer_Tick;
                automaticRedoWaitTimer.Start();
            }
        }

        void automaticRedoWaitTimer_Tick(object sender, object e)
        {
            if (automaticRedoDateTime.Second == 0)
            {
                automaticRedoWaitTimer.Stop();
                automaticRedoWaitTimer.Tick -= automaticRedoWaitTimer_Tick;

                ButtonAutomationPeer peer = new ButtonAutomationPeer(btnGoRect);
                peer.Invoke();
            }
            else
            {
                automaticRedoDateTime = automaticRedoDateTime.AddSeconds(-1);
            }
        }

        private void btnGoRect_Click(object sender, RoutedEventArgs e)
        {
            //we animate tbxAnswer to its original position
            da_tbxAnswer.To = 0;
            stytbxAnswer.Begin();

            //clears the message in tbkResults so messages to not overlap
            tbkResults.Text = "";
            tbkResults.Opacity = 0;

      


            //clears and resets time for automatic redos
            automaticRedoDateTime = DateTime.MinValue;
            automaticRedoWaitTimer.Tick -= automaticRedoWaitTimer_Tick;


            //Timer begins if the user has set a time limit
            //clear dateTime_Countdown of previous values

            dateTime_CountDown = DateTime.MinValue;
//detachse event handler to ensure that if btnGo was pressed while pressed timer was on, our ticks remain accurate
            timer.Tick -= timerCountDown;

            if (commandbar_timer_tbxMinutes.Text != "" || commandbar_timer_tbxSeconds.Text != "")
            {
                if (commandbar_timer_tbxMinutes.Text != "")
                {
                    //if the value entered is unreadable, we automatically set it to 0
                    try
                    {
                        setTimer_minute = Convert.ToInt32(commandbar_timer_tbxMinutes.Text);
                    }
                    catch (Exception)
                    {
                        setTimer_minute = 0;
                        commandbar_timer_tbxMinutes.Text = "0";
                    }
                }
                else
                {
                    commandbar_timer_tbxMinutes.Text = "0";
                    setTimer_minute = 0;
                }

                if (commandbar_timer_tbxSeconds.Text != "")
                {
                    //if the value entered is unreadable, we automatically set it to 0
                    try
                    {
                        setTimer_second = Convert.ToInt32(commandbar_timer_tbxSeconds.Text);
                    }
                    catch (Exception)
                    {
                        setTimer_second = 0;
                        commandbar_timer_tbxSeconds.Text = "0";
                    }

                }
                else
                {
                    commandbar_timer_tbxSeconds.Text = "0";
                    setTimer_second = 0;
                }

                setTimer_minute_redo = setTimer_minute;
                setTimer_second_redo = setTimer_second;

                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timerCountDown;

                dateTime_CountDown = dateTime_CountDown.AddMinutes(setTimer_minute);
                dateTime_CountDown = dateTime_CountDown.AddSeconds(setTimer_second);

                timer.Start();
            }

            tbkUnitsDisplay.Opacity = 1;

            tbkUnitsDisplay.FontSize = Frame.ActualWidth / 20;

            btnRedo_.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnNew_.Visibility = Windows.UI.Xaml.Visibility.Visible;
            btnAnswer_.Visibility = Windows.UI.Xaml.Visibility.Visible;
            tbkAnswerLabel.Visibility = Windows.UI.Xaml.Visibility.Visible;

            Random random = new Random();


            try //catches any exception along with Overflow exceptions
            {
                minNumber = Convert.ToInt32(tbxMinNumber.Text);
                maxNumber = Convert.ToInt32(tbxMaxNumber.Text);
            }
            catch (System.OverflowException)
            {
                tbkResults.Text = "These are strange numbers. Let's try memorizing numbers within a more moderate range please.";
                tbkResults.Opacity = 1;
                return;
            }
            catch (Exception)
            {
                tbkResults.Text = "Oh-uh, something unexpected happened. Please double check the minimum and maximum size of numbers you would like to memorize.";
                tbkResults.Opacity = 1;
                return;
            }
    

            //if the minimum number to display is greater than the maximum number to display, we swap the two values
            if (minNumber > maxNumber)
            {
                int temp = minNumber;
                minNumber = maxNumber;
                maxNumber = temp;
            }

            redoMinNumber = minNumber;      //sets redoNumber so that we can repeat this operation when "btnRedo" is pressed
            redoMaxNumber = maxNumber;


            //sets the number of numbers to display. Checks if user has entered a range (with the '-' as the delimiter) or a single number
            if (tbxNumberOfNumbers.Text.Contains('-'))
            {
                try
                {
                    string[] numberDelimiter = tbxNumberOfNumbers.Text.Split('-');
                    minLowerRangeNumber = Convert.ToInt32(numberDelimiter[0]);                 
                    maxUpperRangeNumber = Convert.ToInt32(numberDelimiter[1]);

                    if (minLowerRangeNumber > maxUpperRangeNumber)
                    {
                        int temp = minLowerRangeNumber;
                        minLowerRangeNumber = maxUpperRangeNumber;
                        maxUpperRangeNumber = temp;
                    }

            
                    if (maxUpperRangeNumber > 1000)
                    {
                        tbkResults.Text = "That's a lot of numbers. Could we try a smaller maximum amount of numbers to memorize (less than or equal to 1000)?";
                        tbkResults.Opacity = 1;
                        return;
                    }

                    redoMinLowerRangeNumber = minLowerRangeNumber; //allows redo to set the same parameter for the number of numbers to show
                    redoMaxUpperRangeNumber = maxUpperRangeNumber;

                    numberOfNumber = random.Next(minLowerRangeNumber, maxUpperRangeNumber + 1);
                    numbers = new int[numberOfNumber];
                }
                catch (Exception)
                {
                    tbkResults.Text = "Please double check the amount of numbers you would like to memorize.";
                    tbkResults.Opacity = 1;
                    return;
                }
            }
            else
            {
                try
                {
                    //if nothing is in the textbox or a lot of spaces
                    
                    if (tbxNumberOfNumbers.Text == "")
                    {
                        numberOfNumber = 0;
                    }
                    else
                    {
                        numberOfNumber = Convert.ToInt16(tbxNumberOfNumbers.Text);      //number of digits to display
                    }

                    //maximum number to show is 1000
                    if (numberOfNumber > 1000)
                    {
                        tbkResults.Text = "That's a lot of numbers. Could we try memorizing fewer numbers (less than or equal to 1000)?";
                        tbkResults.Opacity = 1;
                        return;
                    }

                    numbers = new int[numberOfNumber];
                }
                catch (Exception )
                {
                    tbkResults.Text = "Please double check the amount of numbers you would like to memorize.";
                    tbkResults.Opacity = 1;
                    return;
                }
            

                //btnRedo determines the upper and lower bounds of length of "redonumbers" from these two values. Works if real range both exists or not
                redoMinLowerRangeNumber = numberOfNumber;
                redoMaxUpperRangeNumber = numberOfNumber;
            }



            //sets the number of letters to display. Checks if user has entered a range (with the '-' as the delimiter) or a single number
            if (tbxNumberOfLetters.Text.Contains('-'))
            {
                try
                {
                    string[] letterDelimiter = tbxNumberOfLetters.Text.Split('-');

                    minLowerRangeLetter = Convert.ToInt32(letterDelimiter[0]);
                    maxUpperRangeLetter = Convert.ToInt32(letterDelimiter[1]);

                    if (minLowerRangeLetter > maxUpperRangeLetter)
                    {
                        int temp = minLowerRangeLetter;
                        minLowerRangeLetter = maxUpperRangeLetter;
                        maxUpperRangeLetter = temp;
                    }

                    //if user wants symbols to appear but did not select any letters, we set the  option to 0
                  if ((minLowerRangeLetter != 0 || maxUpperRangeLetter != 0) && numberOfLettersSelected ==0)
                  {
                      maxUpperRangeLetter = 0;
                      minLowerRangeLetter = 0;
                      numberOfLettersResetToZero = true;
                  }

                    if (maxUpperRangeLetter > 1000)
                    {
                        tbkResults.Text = "That's a lot of letters. Could we try memorizing fewer letters (less than or equal to 1000)?";
                        tbkResults.Opacity = 1;
                        return;
                    }

                    redoMinLowerRangeLetter = minLowerRangeLetter;
                    redoMaxUpperRangeLetter = maxUpperRangeLetter;

               //     if ()
                    numberOfLetter = random.Next(minLowerRangeLetter, maxUpperRangeLetter + 1);
                    letters = new string[numberOfLetter];
                }
                catch (Exception)
                {
                    tbkResults.Text = "Please double check the amount of letters you would like to memorize.";
                    tbkResults.Opacity = 1;
                    return;
                }
            }
            else
            {
                try
                {
                    if (tbxNumberOfLetters.Text == "")      //if the textbox contains empty string
                    {
                        numberOfLetter = 0;
                    }
                    else
                    {
                        numberOfLetter = Convert.ToInt32(tbxNumberOfLetters.Text);
                    }

                    //if user wants letters ut didn't select which ones
                    if (numberOfLetter != 0 && numberOfLettersSelected ==0)
                    {
                        numberOfLetter = 0;
                        numberOfLettersResetToZero = true;
                    }

                    if (numberOfLetter > 1000)
                    {
                        tbkResults.Text = "That's a lot of letters. Could we try memorizing fewer letters (less than or equal to 1000)?";
                        tbkResults.Opacity = 1;
                        return;
                    }
                    letters = new string[numberOfLetter];

                    //btnRedo determines the upper and lower bounds of length of "redoletters" from these two values. Works if real range both exists or not
                    redoMinLowerRangeLetter = numberOfLetter;
                    redoMaxUpperRangeLetter = numberOfLetter;
                }
                catch (Exception)
                {
                    tbkResults.Text = "Please double check the amount of letters you would like to memorize.";
                    tbkResults.Opacity = 1;
                    return;
                }
            }


            //sets the number of symbols to display. Checks if user has entered a range (with the '-' as the delimiter) or a single number
            if (tbxNumberOfSymbols.Text.Contains('-'))
            {
                try
                {
                    string[] symbolDelimiter = tbxNumberOfSymbols.Text.Split('-');
                    minLowerRangeSymbol = Convert.ToInt32(symbolDelimiter[0]);
                    maxUpperRangeSymbol = Convert.ToInt32(symbolDelimiter[1]);

                    if (minLowerRangeSymbol > maxUpperRangeSymbol)
                    {
                        int temp = minLowerRangeSymbol;
                        minLowerRangeSymbol = maxUpperRangeSymbol;
                        maxUpperRangeSymbol = temp;
                    }

                    if ((minLowerRangeSymbol != 0 || maxUpperRangeSymbol != 0) && numberOfSymbolsSelected == 0)
                    {
                        maxUpperRangeSymbol = 0;
                        minLowerRangeSymbol = 0;
                        numberOfSymbolsResetToZero = true;
                    }

                 
                  
                    if (maxUpperRangeSymbol > 1000)
                    {
                        tbkResults.Text = "That's a lot of symbols. Could we try a smaller maximum amount of symbols to memorize (less than or equal to 1000)?";
                        tbkResults.Opacity = 1;
                        return;
                    }

                    redoMinLowerRangeSymbol = minLowerRangeSymbol;
                    redoMaxUpperRangeSymbol = maxUpperRangeSymbol;

                    numberOfSymbol = random.Next(minLowerRangeSymbol, maxUpperRangeSymbol + 1);
                    symbols = new string[numberOfSymbol];
                }
                catch (Exception)
                {
                    tbkResults.Text = "Please double check the amount of symbols you would like to memorize.";
                    tbkResults.Opacity = 1;
                    return;
                }
            }
            else
            {
                try
                {
                    if (tbxNumberOfSymbols.Text == "")
                    {
                        numberOfSymbol = 0;
                    }
                    else
                    {
                        numberOfSymbol = Convert.ToInt32(tbxNumberOfSymbols.Text);
                    }

                    //if user wants symbols ut didn't select which ones
                    if (numberOfSymbol != 0 && numberOfSymbolsSelected == 0)
                    {
                        numberOfSymbol = 0;
                        numberOfSymbolsResetToZero = true;
                    }

                    if (numberOfSymbol > 1000)
                    {
                        tbkResults.Text = "That's a lot of symbols. Could we try memorizing fewer symbols (less than or equal to 1000)?";
                        tbkResults.Opacity = 1;
                        return;
                    }

                    symbols = new string[numberOfSymbol];

                    //btnRedo determines the upper and lower bounds of length of "redosymbols" from these two values. Works if real range both exists or not
                    redoMinLowerRangeSymbol = numberOfSymbol;
                    redoMaxUpperRangeSymbol = numberOfSymbol;
                }
                catch (Exception)
                {
                    tbkResults.Text = "Please double check the amount of symbols you would like to memorize.";
                    tbkResults.Opacity = 1;
                    return;
                }
            }


            //if no majorexceptions were found, we make certain elements visible and collapsed
            gridContainingThreeAppButtons.Visibility = Windows.UI.Xaml.Visibility.Visible;

            btnCheck_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            btnPeek_.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            tbxAnswer.Text = "";
            tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            grid_moreLetters.Opacity = 0;
            gridLeftRect.Opacity = 0;
            gridRightRect.Opacity = 0;
            gridRectMiddle.Opacity = 0;
            bool_gridMoreLettersIsOnFirstTime = true;


            //find length of units array, which is the sum of the lengths of the numbers, letters, and symbols arrays       
            units = new string[numbers.Length + letters.Length + symbols.Length];

            //adds values to "numbers" array
            for (int i = 0; i < numbers.Length; i++)
            {
                int randomNumber = random.Next(minNumber, maxNumber + 1);    // random number from the minimum to the maximum number
                numbers[i] = randomNumber;
            }

            //===adds values to "letters" array

            //makes possibleLetters hold symbols that user has selected, that COULD appear in the "letters" array
            for (int i = 0; i < theLetterIsOn.Length; i++)
            {
                if (theLetterIsOn[i] == false)
                {
                    possibleLetters[i] = "=";
                }
                else
                {
                    possibleLetters[i] = allLettersRestore[i];
                }
            }

            redoPossibleLetters = possibleLetters; //allows us to replicate the randomizing of letters when "btnRedo" is pressed


            //we now transfer the possible letters that are randomly selected from "possibleLetters" to the "letters" array
            for (int i = 0; i < letters.Length; i++)
            {
                int randomNumber = random.Next(0, possibleLetters.Length);       //finds random position in possibleLetters, thus, letters, to place into "letters"

                if (possibleLetters[randomNumber] != "=")
                {
                    letters[i] = possibleLetters[randomNumber];
                }
                else
                {
                    i--;
                }
            }


            //===adds  values to "symbols" array

            //makes possibleSymbols hold symbols that user has selected, that COULD appear in the "symbols" array
            for (int i = 0; i < theSymbolIsOn.Length; i++)
            {
                if (theSymbolIsOn[i] == false)
                {
                    possibleSymbols[i] = "=";
                }
                else
                {
                    possibleSymbols[i] = allSymbolsRestore[i];
                }
            }

            redoPossibleSymbols = possibleSymbols;


            //we now transfer the possible symbols that are randomly selected from "possibleSymbols" to the "symbols" array
            for (int i = 0; i < symbols.Length; i++)
            {
                int randomNumber = random.Next(0, possibleSymbols.Length);       //finds random position from specificLetters

                if (possibleSymbols[randomNumber] != "=")
                {
                    symbols[i] = possibleSymbols[randomNumber];
                }
                else
                {
                    i--;
                }
            }



            //adds elements' values from randomly choosing values from the arrays holding numbers, letters, and symbols to "units" array.
            //We incrementally assign values to "units" array by randomly choosing which of the three other array to use, and incrementally run through those array

            int counterOfNegativeOne_Numbers = 0;
            int counterOfNegativeOne_Letters = 0;
            int counterOfNegativeOne_Symbols = 0;

            for (int i = 0; i < units.Length; i++)
            {
                switch (random.Next(0, 2 + 1))
                {
                    case 0:        //numbers
                        if (counterOfNegativeOne_Numbers == numbers.Length)
                        {
                            i--;
                            continue;
                        }
                        for (int a = 0; a < numbers.Length; a++)
                        {
                            if (numbers[a] != -1)
                            {
                                units[i] = numbers[a].ToString();
                                numbers[a] = -1;
                                counterOfNegativeOne_Numbers++;
                                break;
                            }
                        }
                        break;

                    case 1:        //letters
                        if (counterOfNegativeOne_Letters == letters.Length)
                        {
                            i--;
                            continue;
                        }
                        for (int b = 0; b < letters.Length; b++)
                        {
                            if (letters[b] != "=")
                            {
                                units[i] = letters[b];
                                letters[b] = "=";
                                counterOfNegativeOne_Letters++;
                                break;
                            }
                        }
                        break;

                    case 2:        //symbols
                        if (counterOfNegativeOne_Symbols == symbols.Length)
                        {
                            i--;
                            continue;
                        }
                        for (int b = 0; b < symbols.Length; b++)
                        {
                            if (symbols[b] != "=")
                            {
                                units[i] = symbols[b].ToString();
                                symbols[b] = "=";
                                counterOfNegativeOne_Symbols++;
                                break;
                            }
                        }
                        break;

                    default: break;
                }
            }

            list_runs.Clear(); //clears the list so it can be used again

            //display the values stored in units
            tbkUnitsDisplay.Text = "";
            for (int i = 0; i < units.Length; i++)
            {
                Run runText = new Run();
                runText.Text = units[i];
                list_runs.Add(runText);

                tbkUnitsDisplay.Inlines.Add(list_runs[i]);

                Run runSpace = new Run();
                runSpace.Text = " ";

                tbkUnitsDisplay.Inlines.Add(runSpace);
            }

            if (numberOfSymbolsResetToZero == true)
            {
                tbkResults.Text += "To show symbols, please select which symbols you'd like to memorize from the Symbols Pane. Selected symbols have" +
                                   " red backgrounds while unselected ones have gray backgrounds.";
                tbkResults.Opacity = 1;
            }
            else
            {
                //if all is fine, tbkResults has 0 opacity
                tbkResults.Opacity = 0;
            }
            if (numberOfLettersResetToZero == true)
            {
                tbkResults.Text += "To show letters, please select which letters you'd like to memorize from the Letters Pane. Selected letters have" +
                                   " red backgrounds while unselected ones have gray backgrounds.";
                tbkResults.Opacity = 1;
            }

            if (numberOfLettersResetToZero == false && numberOfSymbolsResetToZero == false)
            {
                tbkResults.Opacity = 0;
            }

            numberOfSymbolsResetToZero = false;
            numberOfLettersResetToZero = false;

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            styGridRectsAppear.Begin();
        }

        private void btnMidRectToRight_Click(object sender, RoutedEventArgs e)
        {
            if (rightRectangleCounter == 1)
            {
                da_gridRightRectDisappear.To = gridRightRect.ActualWidth * -1;
                styGridRightRectDisappear.Begin();
                rightRectangleCounter = 0;
            }
            else
            {
                da_gridRightRectAppear.To = 0;
                styGridRightRectAppear.Begin();
                rightRectangleCounter = 1;
            }
        }

        private void btnMidRectToLeft_Click(object sender, RoutedEventArgs e)
        {

            if (leftRectangleCounter == 1)
            {

                da_gridLeftRectDisappear.To = gridLeftRect.ActualWidth;
                styGridLeftRectDisappear.Begin();
                leftRectangleCounter = 0;
            }
            else
            {

                da_gridLeftRectAppear.To = 0;
                styGridLeftRectAppear.Begin();
                leftRectangleCounter = 1;
            }
        }


        //time count-down

        private void timerCountDown(object sender, object e)
        {
            if (dateTime_CountDown.Second == 0 && dateTime_CountDown.Minute == 0)
            {
                timer.Stop();
                timer.Tick -= timerCountDown;
                tbkUnitsDisplay.Opacity = 0;

                tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Visible;
                btnCheck_.Visibility = Windows.UI.Xaml.Visibility.Visible;
                btnPeek_.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {

                //the textblock with text "Time Remaining" is now visible

                gridContainingTimer.Opacity = 1;

                tbkDisplayTimer_Minute.Text = dateTime_CountDown.ToString("mm");
                tbkDisplayTimer_Seconde.Text = dateTime_CountDown.ToString("ss");

                dateTime_CountDown = dateTime_CountDown.AddSeconds(-1);
            }
        }


        private void tbxAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxAnswer.BorderBrush = new SolidColorBrush(Colors.LightBlue);
            tbxAnswer.BorderThickness = new Thickness(5);
        }

        private void tbxAnswer_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxAnswer.BorderBrush = new SolidColorBrush(Colors.Gray);
            tbxAnswer.BorderThickness = new Thickness(1);
        }

        private void commandbar_options_toggle2_Click(object sender, RoutedEventArgs e)
        {
            if (commandbar_options_toggle1.IsChecked == true)
            {
                commandbar_options_toggle1.IsChecked = false;
            }
        }

        private void commandbar_options_toggle1_Click(object sender, RoutedEventArgs e)
        {
            if (commandbar_options_toggle2.IsChecked == true)
            {
                commandbar_options_toggle2.IsChecked = false;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (captionOn)
            {
                captionOn = false;
                appbarbuttonCaption.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                captionOn = true;
                appbarbuttonCaption.Foreground = new SolidColorBrush(Colors.Yellow);

            }
        }

        private void btn_allLowercaseLetter_Click(object sender, RoutedEventArgs e)
        {
            if (allLowerLettersIsOn)
            {
                allLowerLettersIsOn = false;
                btn_allLowercaseLetter.Foreground = new SolidColorBrush(Colors.White);
                btn_allLowercaseLetter.Background = new SolidColorBrush(Colors.Gray);

                for (int i = 26; i < 52; i++)
                {
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(letterButtons[i]);
                    peer.Invoke();
                }
            }
            else
            {
                for (int i = 26; i < 52; i++)
                {
                    theLetterIsOn[i] = true;
                    letterButtons[i].Foreground = new SolidColorBrush(Colors.Yellow);
                    letterButtons[i].Background = new SolidColorBrush(Colors.Brown);
                }

                allLowerLettersIsOn = true;
                btn_allLowercaseLetter.Foreground = new SolidColorBrush(Colors.Yellow);
                btn_allLowercaseLetter.Background = new SolidColorBrush(Colors.Brown);
            }


            //==determines if selective numbers should be on or off
            int numberOfLowerOn = 0;
            int numberOfUpperOn = 0;

            for (int b = 0; b < 26; b++)
            {
                if (theLetterIsOn[b] == true)
                {
                    numberOfLowerOn++;
                }
            }

            for (int c = 26; c < 52; c++)
            {
                if (theLetterIsOn[c] == true)
                {
                    numberOfUpperOn++;
                }
            }

            numberOfLettersSelected = numberOfLowerOn + numberOfUpperOn;

            if ((numberOfLowerOn == 0 && numberOfUpperOn == 0) || (numberOfLowerOn == 0 && numberOfUpperOn == 26) || (numberOfLowerOn == 26 && numberOfUpperOn == 0) || (numberOfLowerOn == 26 && numberOfUpperOn == 26))
            {
                tbk_selectiveLettersONOff.Text = "OFF";
                tbk_selectiveLettersONOff.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                tbk_selectiveLettersONOff.Text = "ON";
                tbk_selectiveLettersONOff.Foreground = new SolidColorBrush(Colors.LawnGreen);

            }
        }

        private void btn_allUppercaseLetter_Click(object sender, RoutedEventArgs e)
        {
            if (allUpperLettersIsOn)
            {
                allUpperLettersIsOn = false;
                btn_allUppercaseLetter.Foreground = new SolidColorBrush(Colors.White);
                btn_allUppercaseLetter.Background = new SolidColorBrush(Colors.Gray);
                for (int i = 0; i < 26; i++)
                {
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(letterButtons[i]);
                    peer.Invoke();
                }
            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                    theLetterIsOn[i] = true;
                    letterButtons[i].Foreground = new SolidColorBrush(Colors.Yellow);
                    letterButtons[i].Background = new SolidColorBrush(Colors.Brown);
                }

                allUpperLettersIsOn = true;
                btn_allUppercaseLetter.Foreground = new SolidColorBrush(Colors.Yellow);
                btn_allUppercaseLetter.Background = new SolidColorBrush(Colors.Brown);

            }

            int numberOfLowerOn = 0;
            int numberOfUpperOn = 0;

            for (int b = 0; b < 26; b++)
            {
                if (theLetterIsOn[b] == true)
                {
                    numberOfLowerOn++;
                }
            }

            for (int c = 26; c < 52; c++)
            {
                if (theLetterIsOn[c] == true)
                {
                    numberOfUpperOn++;
                }
            }

            numberOfLettersSelected = numberOfLowerOn + numberOfUpperOn;

            if ((numberOfLowerOn == 0 && numberOfUpperOn == 0) || (numberOfLowerOn == 0 && numberOfUpperOn == 26) || (numberOfLowerOn == 26 && numberOfUpperOn == 0) || (numberOfLowerOn == 26 && numberOfUpperOn == 26))
            {
                tbk_selectiveLettersONOff.Text = "OFF";
                tbk_selectiveLettersONOff.Foreground = new SolidColorBrush(Colors.White);

            }
            else
            {
                tbk_selectiveLettersONOff.Text = "ON";
                tbk_selectiveLettersONOff.Foreground = new SolidColorBrush(Colors.LawnGreen);

            }

        }

        private void btn_moreLetters_Click(object sender, RoutedEventArgs e)
        {
            if (bool_gridMoreLettersIsOn)
            {
                bool_gridMoreLettersIsOn = false;
                da_gridMoreLettersDisappear.To = grid_moreLetters.ActualHeight;
                styGridMoreLettersDisappear.Begin();
            }
            else
            {
                bool_gridMoreLettersIsOn = true;

                if (bool_gridMoreLettersIsOnFirstTime)
                {
                    da_gridMoreLettersAppear.From = grid_moreLetters.ActualHeight;
                    da_gridMoreLettersAppear.To = 0;
                    grid_moreLetters.Opacity = 1;
                    bool_gridMoreLettersIsOnFirstTime = false;
                }
                else
                {
                    da_gridMoreLettersAppear.From = null;
                    da_gridMoreLettersAppear.To = 0;
                }
                styGridMoreLettersAppear.Begin();
            }
        }

        private void letterButtons_click(object sender, RoutedEventArgs e)
        {
            Button buttonclicked = e.OriginalSource as Button;

            string name = buttonclicked.Name;
            int i;        //the index in the bool and button array;

            #region switch statement
            switch (name)
            {
                case "btnLetterA":
                    i = 0;
                    break;
                case "btnLetterB":
                    i = 1;
                    break;
                case "btnLetterC":
                    i = 2;
                    break;
                case "btnLetterD":
                    i = 3;
                    break;
                case "btnLetterE":
                    i = 4;
                    break;
                case "btnLetterF":
                    i = 5;
                    break;
                case "btnLetterG":
                    i = 6;
                    break;
                case "btnLetterH":
                    i = 7;
                    break;
                case "btnLetterI":
                    i = 8;
                    break;
                case "btnLetterJ":
                    i = 9;
                    break;
                case "btnLetterK":
                    i = 10;
                    break;
                case "btnLetterL":
                    i = 11;
                    break;
                case "btnLetterM":
                    i = 12;
                    break;
                case "btnLetterN":
                    i = 13;
                    break;
                case "btnLetterO":
                    i = 14;
                    break;
                case "btnLetterP":
                    i = 15;
                    break;
                case "btnLetterQ":
                    i = 16;
                    break;
                case "btnLetterR":
                    i = 17;
                    break;
                case "btnLetterS":
                    i = 18;
                    break;
                case "btnLetterT":
                    i = 19;
                    break;
                case "btnLetterU":
                    i = 20;
                    break;
                case "btnLetterV":
                    i = 21;
                    break;
                case "btnLetterW":
                    i = 22;
                    break;
                case "btnLetterX":
                    i = 23;
                    break;
                case "btnLetterY":
                    i = 24;
                    break;
                case "btnLetterZ":
                    i = 25;
                    break;
                case "btnLettera":
                    i = 26;
                    break;
                case "btnLetterb":
                    i = 27;
                    break;
                case "btnLetterc":
                    i = 28;
                    break;
                case "btnLetterd":
                    i = 29;
                    break;
                case "btnLettere":
                    i = 30;
                    break;
                case "btnLetterf":
                    i = 31;
                    break;
                case "btnLetterg":
                    i = 32;
                    break;
                case "btnLetterh":
                    i = 33;
                    break;
                case "btnLetteri":
                    i = 34;
                    break;
                case "btnLetterj":
                    i = 35;
                    break;
                case "btnLetterk":
                    i = 36;
                    break;
                case "btnLetterl":
                    i = 37;
                    break;
                case "btnLetterm":
                    i = 38;
                    break;
                case "btnLettern":
                    i = 39;
                    break;
                case "btnLettero":
                    i = 40;
                    break;
                case "btnLetterp":
                    i = 41;
                    break;
                case "btnLetterq":
                    i = 42;
                    break;
                case "btnLetterr":
                    i = 43;
                    break;
                case "btnLetters":
                    i = 44;
                    break;
                case "btnLettert":
                    i = 45;
                    break;
                case "btnLetteru":
                    i = 46;
                    break;
                case "btnLetterv":
                    i = 47;
                    break;
                case "btnLetterw":
                    i = 48;
                    break;
                case "btnLetterx":
                    i = 49;
                    break;
                case "btnLettery":
                    i = 50;
                    break;
                case "btnLetterz":
                    i = 51;
                    break;
                default:
                    throw new ArgumentException();
            }

            #endregion

            if (theLetterIsOn[i] == true)
            {
                letterButtons[i].Background = new SolidColorBrush(Colors.Gray);
                letterButtons[i].Foreground = new SolidColorBrush(Colors.White);
                theLetterIsOn[i] = false;
            }
            else
            {
                letterButtons[i].Background = new SolidColorBrush(Colors.Brown);
                letterButtons[i].Foreground = new SolidColorBrush(Colors.Yellow);
                theLetterIsOn[i] = true;
            }

            //turn on the "All upper is On" button
            bool turnAllUpperOn = true;
            for (int x = 0; x < 26; x++)
            {
                if (theLetterIsOn[x] == false)
                {
                    turnAllUpperOn = false;
                }
            }

            if (turnAllUpperOn)
            {
                allUpperLettersIsOn = true;
                btn_allUppercaseLetter.Foreground = new SolidColorBrush(Colors.Yellow);
                btn_allUppercaseLetter.Background = new SolidColorBrush(Colors.Brown);
            }
            else
            {
                allUpperLettersIsOn = false;
                btn_allUppercaseLetter.Foreground = new SolidColorBrush(Colors.White);
                btn_allUppercaseLetter.Background = new SolidColorBrush(Colors.Gray);
            }

            bool turnAllLowerOn = true;
            for (int x = 26; x < 52; x++)
            {
                if (theLetterIsOn[x] == false)
                {
                    turnAllLowerOn = false;
                }
            }

            if (turnAllLowerOn)
            {
                allLowerLettersIsOn = true;
                btn_allLowercaseLetter.Foreground = new SolidColorBrush(Colors.Yellow);
                btn_allLowercaseLetter.Background = new SolidColorBrush(Colors.Brown);
            }
            else
            {
                allLowerLettersIsOn = false;
                btn_allLowercaseLetter.Foreground = new SolidColorBrush(Colors.White);
                btn_allLowercaseLetter.Background = new SolidColorBrush(Colors.Gray);
            }

            //we turn on "Selective Letters" if all upper is on and some lower are on, all lower are on and some upper, some lower no upper, some upper no lower, some lower some upper
            //we turn off "selective Letters" if all upper, no lower, all lower no upper, and all upper all lower

            int numberOfLowerOn = 0;
            int numberOfUpperOn = 0;

            for (int b = 0; b < 26; b++)
            {
                if (theLetterIsOn[b] == true)
                {
                    numberOfLowerOn++;
                }
            }

            for (int c = 26; c < 52; c++)
            {
                if (theLetterIsOn[c] == true)
                {
                    numberOfUpperOn++;
                }
            }

            numberOfLettersSelected = numberOfLowerOn + numberOfUpperOn;

            if ((numberOfLowerOn == 0 && numberOfUpperOn == 0) || (numberOfLowerOn == 0 && numberOfUpperOn == 26) || (numberOfLowerOn == 26 && numberOfUpperOn == 0) || (numberOfLowerOn == 26 && numberOfUpperOn == 26))
            {
                tbk_selectiveLettersONOff.Text = "OFF";
                tbk_selectiveLettersONOff.Foreground = new SolidColorBrush(Colors.White);

            }
            else
            {
                tbk_selectiveLettersONOff.Text = "ON";
                tbk_selectiveLettersONOff.Foreground = new SolidColorBrush(Colors.LawnGreen);

            }
        }

        private void letterSymbols_click(object sender, RoutedEventArgs e)
        {
            Button buttonclicked = e.OriginalSource as Button;

            string name = buttonclicked.Name;
            int i;        //the index in the bool and button array;

            #region switch statement
            switch (name)
            {
                case "btnSymbol1":
                    i = 0;
                    break;
                case "btnSymbol2":
                    i = 1;
                    break;
                case "btnSymbol3":
                    i = 2;
                    break;
                case "btnSymbol4":
                    i = 3;
                    break;
                case "btnSymbol5":
                    i = 4;
                    break;
                case "btnSymbol6":
                    i = 5;
                    break;
                case "btnSymbol7":
                    i = 6;
                    break;
                case "btnSymbol8":
                    i = 7;
                    break;
                case "btnSymbol9":
                    i = 8;
                    break;
                case "btnSymbol10":
                    i = 9;
                    break;
                default:
                    throw new ArgumentException();
            }
            #endregion

            if (theSymbolIsOn[i] == true)
            {
                symbolButtons[i].Background = new SolidColorBrush(Colors.Gray);
                symbolButtons[i].Foreground = new SolidColorBrush(Colors.White);
                theSymbolIsOn[i] = false;
            }
            else
            {
                symbolButtons[i].Background = new SolidColorBrush(Colors.Brown);
                symbolButtons[i].Foreground = new SolidColorBrush(Colors.Yellow);
                theSymbolIsOn[i] = true;
            }


            numberOfSymbolsSelected = 0;

            for (int a = 0; a < 10; a++)
            {
                if (theSymbolIsOn[a] == true)
                {
                    numberOfSymbolsSelected++;
                }
            }
        }

        private void appbarButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Practice));
        }

        private void appbarButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


        //private void KeyDown1(object sender, KeyRoutedEventArgs e)
        //{
        //    switch (e.Key)
        //    {
        //        case Windows.System.VirtualKey.Number0:
        //        case Windows.System.VirtualKey.Number1:
        //        case Windows.System.VirtualKey.Number2:
        //        case Windows.System.VirtualKey.Number3:
        //        case Windows.System.VirtualKey.Number4:
        //        case Windows.System.VirtualKey.Number5:
        //        case Windows.System.VirtualKey.Number6:
        //        case Windows.System.VirtualKey.Number7:
        //        case Windows.System.VirtualKey.Number8:
        //        case Windows.System.VirtualKey.Number9:
        //        case Windows.System.VirtualKey.NumberKeyLock:
        //        case Windows.System.VirtualKey.NumberPad0:
        //        case Windows.System.VirtualKey.NumberPad1:
        //        case Windows.System.VirtualKey.NumberPad2:
        //        case Windows.System.VirtualKey.NumberPad3:
        //        case Windows.System.VirtualKey.NumberPad4:
        //        case Windows.System.VirtualKey.NumberPad5:
        //        case Windows.System.VirtualKey.NumberPad6:
        //        case Windows.System.VirtualKey.NumberPad7:
        //        case Windows.System.VirtualKey.NumberPad8:
        //        case Windows.System.VirtualKey.NumberPad9:
        //        case Windows.System.VirtualKey.Delete:
        //        case Windows.System.VirtualKey.Back:
        //            if (Window.Current.CoreWindow.GetAsyncKeyState(VirtualKey.Shift) != Windows.UI.Core.CoreVirtualKeyStates.None)
        //            {
        //                e.Handled = true;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        default:
        //            e.Handled = true;
        //            break;
        //    }
        //}

  

        public class ComboUserChoice
        {
            private string name;
            private int lowerRange;
            private int upperRange;

            public ComboUserChoice(string presetName, int presetMinRange, int presetMaxRange)
            {
                name = presetName;
                lowerRange = presetMinRange;
                upperRange = presetMaxRange;
            }

            public ComboUserChoice(TextBox tbxComboName, TextBox tbxComboLowerRange, TextBox tbxComboUpperRange)
            {
                name = tbxComboName.Text;
                lowerRange = Convert.ToInt32(tbxComboLowerRange.Text);
                upperRange = Convert.ToInt32(tbxComboUpperRange.Text);
            }

            public string Name { get { return name; } }
            public int LowerRange { get { return lowerRange; } }
            public int UpperRange { get { return upperRange; } }
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
