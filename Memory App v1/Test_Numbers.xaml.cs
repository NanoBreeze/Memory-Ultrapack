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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test_Numbers : Page
    {

        bool captionOn = false;

        int initialNumberOfNumbersToDisplay = 5;
        int numberOfWrongAnswers = 0;

        DispatcherTimer instructionsDispatcher = new DispatcherTimer();
        DateTime instructionDateTime = new DateTime();

        //DispatcherTimer and DateTime work together to create short break before new numbers are displayed 
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DateTime dateTime = new DateTime();

        List<Run> list_runs = new List<Run>();  //Green is all right, yellow is missed, red is wrong, 

        //stores the value of high score

        ApplicationDataContainer applicationDataContainer = ApplicationData.Current.LocalSettings;
        int[] highScores = new int[5];

        DispatcherTimer fontsizeDT = new DispatcherTimer();
        DispatcherTimer fontsizeAnswerDT = new DispatcherTimer();

        public Test_Numbers()
        {
                this.InitializeComponent();

                highScores[0] = (int)applicationDataContainer.Values["HighScore1_Number"];
                highScores[1] = (int)applicationDataContainer.Values["HighScore2_Number"];
                highScores[2] = (int)applicationDataContainer.Values["HighScore3_Number"];
                highScores[3] = (int)applicationDataContainer.Values["HighScore4_Number"];
                highScores[4] = (int)applicationDataContainer.Values["HighScore5_Number"];

                fontsizeDT.Interval = TimeSpan.FromMilliseconds(20);
                fontsizeDT.Tick += fontsizeDT_Tick;
                fontsizeDT.Start();

            instructionDateTime = instructionDateTime.AddSeconds(8);
            instructionsDispatcher.Interval = TimeSpan.FromSeconds(1);
            instructionsDispatcher.Tick +=instructionsDispatcher_Tick;
            instructionsDispatcher.Start();
        }

        void fontsizeDT_Tick(object sender, object e)
        {
            fontsizeDT.Stop();
            fontsizeDT.Tick -= fontsizeDT_Tick;
            tbkInstructions.FontSize = Frame.ActualHeight / 40;
            tbkAnalysis.FontSize = Frame.ActualHeight / 35;

        }


        void instructionsDispatcher_Tick(object sender, object e)
        {
            if  (instructionDateTime.Second == 1)
            {
                stryInstruction.Begin();
            }

            if (instructionDateTime.Second == 0)
            {
                  //random numbers appear when the instructions fade begins
                Random random = new Random();
                tbkDisplayNumbers.FontSize = Frame.ActualHeight / 10;

                for (int i = 0; i < 5; i++)
                {

                    //we create Run objects because we can add individual colours to them
                    Run runText = new Run();
                    runText.Text = random.Next(0, 10).ToString();

                    list_runs.Add(runText);

                    tbkDisplayNumbers.Inlines.Add(list_runs[i]);
                }

                instructionsDispatcher.Stop();
                instructionsDispatcher.Tick -= instructionsDispatcher_Tick;

                btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;    //user can only click btnAnswer when tbxAnswer is visible
                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Visible;
                tbkTimeRemaining.Visibility = Windows.UI.Xaml.Visibility.Visible;

                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Tick += dispatcherTimerInitial_Tick;
                dateTime = dateTime.AddSeconds(26);

                dispatcherTimer.Start();
            }
            else
            {
                instructionDateTime = instructionDateTime.AddSeconds(-1);
              
            }
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            btnAnswer_Operation();
        }

        private void btnAnswer_Operation()
        {


            btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            tbkDisplayNumbers.Opacity = 1;

            tbkAnalysis.Text = "";      //clears the text in order to accurately prepare for new incoming text
            if (captionOn)      //if user wants a transcript of the results: 
            {
                tbkAnalysis.Opacity = 1;
            }
            else
            {
                tbkAnalysis.Opacity = 0;
            }

            //when the user has inputted two wrong answers in a row, we terminate the test.
            if (numberOfWrongAnswers == 2)
            {
                int indexToPlaceUserScore = -1;
                int[] secondArrayToMakeLifeEasier = new int[5];

                Array.Copy(highScores,secondArrayToMakeLifeEasier,5);

                //find where to place the score
                for (int i = 0; i < 5; i++ )
                {
                    if (initialNumberOfNumbersToDisplay - 1 > highScores[i])
                    {
                        indexToPlaceUserScore = i;
                        break;
                    }
                }

                if (indexToPlaceUserScore != -1)
                {
                    secondArrayToMakeLifeEasier[indexToPlaceUserScore] = (initialNumberOfNumbersToDisplay - 1);


                    //secondArrayToMakeLifeEasier contains new highscores
                    for (int j = indexToPlaceUserScore + 1; j < 5; j++)
                    {
                        secondArrayToMakeLifeEasier[j] = highScores[j - 1];
                    }

                    //we now provide highScores with the values in secondArrayToMakeLifeEasier
                    for (int k = 0; k < 5; k++)
                    {
                        highScores[k] = secondArrayToMakeLifeEasier[k];
                    }
                }
                    

                //we now store the values in highScores into our app data
                applicationDataContainer.Values["HighScore1_Number"] = highScores[0];
                applicationDataContainer.Values["HighScore2_Number"] = highScores[1];
                applicationDataContainer.Values["HighScore3_Number"] = highScores[2];
                applicationDataContainer.Values["HighScore4_Number"] = highScores[3];
                applicationDataContainer.Values["HighScore5_Number"] = highScores[4];



                    tbkAnalysis.Opacity = 1;
                    tbkAnalysis.Text = "";
                tbkAnalysis.Text = "The test is now finished. \n Maximum number of numbers memorized: " + (initialNumberOfNumbersToDisplay - 1).ToString();
                btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

              
                //applicationDataContainer.Values.Remove("HighScore1_Number");
                //applicationDataContainer.Values.Remove("HighScore2_Number");
                //applicationDataContainer.Values.Remove("HighScore3_Number");
                //applicationDataContainer.Values.Remove("HighScore4_Number");
                //applicationDataContainer.Values.Remove("HighScore5_Number");


            }
            else
            {
                bool addOneMoreUnit = true;



                for (int i = 0; i < Math.Min(tbxAnswer.Text.Length, list_runs.Count); i++)
                {
                    if (list_runs[i].Text == tbxAnswer.Text[i].ToString())
                    {
                        list_runs[i].Foreground = new SolidColorBrush(Colors.Green);
                        tbkAnalysis.Text += "\n" + (i + 1).ToString() + ". Correct ";
                    }
                    else
                    {
                        list_runs[i].Foreground = new SolidColorBrush(Colors.Red);
                        tbkAnalysis.Text += "\n" + (i + 1).ToString() + ". Incorrect ";
                        addOneMoreUnit = false;
                    }
                }

                if (list_runs.Count > tbxAnswer.Text.Length)
                {
                    addOneMoreUnit = false;

                    for (int i = tbxAnswer.Text.Length; i < list_runs.Count; i++)
                    {
                        list_runs[i].Foreground = new SolidColorBrush(Colors.Yellow);
                        tbkAnalysis.Text += "\n" + (i+1).ToString() + ". Missed ";
                    }
                }

                if (addOneMoreUnit)
                {
                    initialNumberOfNumbersToDisplay++;
                    numberOfWrongAnswers = 0;
                }
                else
                {
                    numberOfWrongAnswers++;
                }

                if (numberOfWrongAnswers == 2)
                {
                    btnAnswer_Operation();
                }
               else         
                {

                    dispatcherTimer.Tick += dispatcherTimerDisplayNewNumbers_Tick;
                    dateTime = dateTime.AddSeconds(3);

                    dispatcherTimer.Start();
                }

            }
        } 

        private void dispatcherTimerDisplayNewNumbers_Tick(object sender, object e)
        {
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Tick -= dispatcherTimerDisplayNewNumbers_Tick;
                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Visible;
                DisplayNumbers(initialNumberOfNumbersToDisplay);
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
                tbkTimeRemaining.Text = "Break Time Remaining ";

                tbkTimeRemaining_Minutes.Text = dateTime.ToString("mm");
                tbkTimeRemaining_Seconds.Text = dateTime.ToString("ss");
            }
        }

        private void dispatcherTimerInitial_Tick(object sender, object e)
        {
            if (dateTime.Second == 0 && dateTime.Minute == 0)       //when time for displaying the numbers in tbkDisplayNumbers is 0, we change its opacity to 0 and allow tbxAnswer to appear
            {
                dispatcherTimer.Stop();
                tbkDisplayNumbers.Opacity = 0;
                tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Visible;
                tbxAnswer.Opacity = 1;
                tbxAnswer.Focus(Windows.UI.Xaml.FocusState.Programmatic);

                fontsizeAnswerDT.Interval = TimeSpan.FromMilliseconds(20);
                fontsizeAnswerDT.Tick += fontsizeAnswerDT_Tick;
                fontsizeAnswerDT.Start();

                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Visible;
                dispatcherTimer.Tick -= dispatcherTimerInitial_Tick;

                tbkTimeRemaining_Minutes.Text = "";
                tbkTimeRemaining_Seconds.Text = "";
                tbkTimeRemaining.Text = "";


         //       tbkTimeRemaining_Minutes.Text = dateTime.ToString("mm");
            //    tbkTimeRemaining_Seconds.Text = dateTime.ToString("ss");
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
                tbkTimeRemaining_Minutes.Text = dateTime.ToString("mm");
                tbkTimeRemaining_Seconds.Text = dateTime.ToString("ss");
            }
        }

        void fontsizeAnswerDT_Tick(object sender, object e)
        {
            fontsizeAnswerDT.Stop();
            fontsizeAnswerDT.Tick -= fontsizeAnswerDT_Tick;

            tbxAnswer.FontSize = tbxAnswer.ActualHeight * 0.5;
        }

        private void DisplayNumbers(int i)
        {

            list_runs.Clear();      //clears the list of run objects in order to accurately store the position of the new run objects

            tbxAnswer.Text = "";        //sets textbox to empty string
            tbxAnswer.Opacity = 0;      //when we are displaying new numbers, the answerbox must be collapsed
            tbxAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
       
            tbkDisplayNumbers.Text = ""; //sets textblock to empty string here to make room for new numbers
            tbkDisplayNumbers.Opacity = 1;

            Random random = new Random();

            for (int a = 0; a < i; a++)
            {
                //we create Run objects because we can add individual colours to them
                Run runText = new Run();
                runText.Text = random.Next(0, 10).ToString();

                list_runs.Add(runText);

                tbkDisplayNumbers.Inlines.Add(list_runs[a]);
            }


            dispatcherTimer.Tick += dispatcherTimerInitial_Tick;
            dateTime = dateTime.AddSeconds(i*5 + 1);

            dispatcherTimer.Start();

        }

        private void btnAnswerNow_Click(object sender, RoutedEventArgs e)
        {
            dateTime = DateTime.MinValue;
            btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
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

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test));
        }

        private void appbarButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test));
        }

        private void appbarButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    
    }
}
