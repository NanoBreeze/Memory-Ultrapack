using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Level6Answer : Page
    {
        bool advanceToB2 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        DispatcherTimer setFontSize = new DispatcherTimer();

        public Level6Answer()
        {
            this.InitializeComponent();
            setFontSize.Interval = TimeSpan.FromMilliseconds(20);
            setFontSize.Tick += setFontSize_Tick;
            setFontSize.Start();
        }

        void setFontSize_Tick(object sender, object e)
        {
            setFontSize.Stop();
            setFontSize.Tick -= setFontSize_Tick;

            //set font size and tbxAnswer text to empty string
            tbxAnswer.FontSize = tbxAnswer.ActualHeight * 0.8;
            tbxAnswer.Text = "";

        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            char[] delimiter = new char[] { ' ' };

            string[] answers = tbxAnswer.Text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            tbkResult.FontSize = Frame.ActualHeight / 30;
            tbkResult.Text = "";


            //Two cases: if the user types less numbers than what appeared and if the user typed more numbers than appeared. 
            if (Level6.UnitsShowns.Length >= answers.Length)
            {
                for (int i = 0; i < answers.Length; i++)
                {
                    if (answers[i] == Level6.UnitsShowns[i])
                    {
                        tbkResult.Text += "\nNumber " + (i+1).ToString() + ": " + "Correct ";
                    }
                    else
                    {
                        tbkResult.Text += "\nNumber " + (i+1).ToString() + ": " + "Incorrect || Correct Answer: " + Level6.UnitsShowns[i].ToString();
                        advanceToB2 = false;
                    }
                }

                for (int i = answers.Length; i < Level6.UnitsShowns.Length; i++)
                {
                    tbkResult.Text += "\nNumber " + (i + 1).ToString() + ": " + "Missed || Correct Answer: " + Level6.UnitsShowns[i].ToString();
                    advanceToB2 = false;
                }
            }

            else
            {
                for (int i = 0; i < Level6.UnitsShowns.Length; i++)
                {
                    if (answers[i] == Level6.UnitsShowns[i])
                    {
                        tbkResult.Text += "\nNumber " + (i + 1).ToString() + ": " + "Correct ";
                    }
                    else
                    {
                        tbkResult.Text += "\nNumber " + (i + 1).ToString() + ": " + "Missed || Correct Answer: " + Level6.UnitsShowns[i].ToString();
                        advanceToB2 = false;
                    }
                }
            }

            if (advanceToB2)
            {
                btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                strybtnNextLevel.Begin();
                settings.Values["B2"] = 1;
            }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level6));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level7));
        }
    }
}
