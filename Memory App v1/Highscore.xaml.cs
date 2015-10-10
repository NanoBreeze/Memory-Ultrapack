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

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Highscore : Page
    {

        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;

        public Highscore()
        {
            this.InitializeComponent();

            numberstbk1.Text = settings.Values["HighScore1_Number"].ToString();
            numberstbk2.Text = settings.Values["HighScore2_Number"].ToString();
            numberstbk3.Text = settings.Values["HighScore3_Number"].ToString();
            numberstbk4.Text = settings.Values["HighScore4_Number"].ToString();
            numberstbk5.Text = settings.Values["HighScore5_Number"].ToString();


            lettertbk1.Text = settings.Values["HighScore1_Letter"].ToString();
            lettertbk2.Text = settings.Values["HighScore2_Letter"].ToString();
            lettertbk3.Text = settings.Values["HighScore3_Letter"].ToString();
            lettertbk4.Text = settings.Values["HighScore4_Letter"].ToString();
            lettertbk5.Text = settings.Values["HighScore5_Letter"].ToString();


            symboltbk1.Text = settings.Values["HighScore1_Symbol"].ToString();
            symboltbk2.Text = settings.Values["HighScore2_Symbol"].ToString();
            symboltbk3.Text = settings.Values["HighScore3_Symbol"].ToString();
            symboltbk4.Text = settings.Values["HighScore4_Symbol"].ToString();
            symboltbk5.Text = settings.Values["HighScore5_Symbol"].ToString();


            cardtbk1.Text = settings.Values["HighScore1_Card"].ToString();
            cardtbk2.Text = settings.Values["HighScore2_Card"].ToString();
            cardtbk3.Text = settings.Values["HighScore3_Card"].ToString();
            cardtbk4.Text = settings.Values["HighScore4_Card"].ToString();
            cardtbk5.Text = settings.Values["HighScore5_Card"].ToString();


        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void appbarbuttonMainPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
