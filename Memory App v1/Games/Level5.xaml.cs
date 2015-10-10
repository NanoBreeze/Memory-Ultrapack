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

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level5 : Page
    {
        DateTime dateTime = new DateTime();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Random random = new Random();

        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };

        static string[] unitsShowns = new string[10];

        public Level5()
        {
            this.InitializeComponent();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dateTime = dateTime.AddSeconds(5);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();

            for (int i = 0; i < 5; i ++)
            {
                unitsShowns[i] = random.Next(10,99).ToString();
            }

            for (int i = 5; i < 8; i++)
            {
                unitsShowns[i] = letters[random.Next(0,52)];
            }

            for (int i = 8; i < 10; i++)
            {
                unitsShowns[i] = symbols[random.Next(0,10)];
            }

            textBlock1.Text = unitsShowns[0];
            textBlock2.Text = unitsShowns[1];
            textBlock3.Text = unitsShowns[2];
            textBlock4.Text = unitsShowns[3];
            textBlock5.Text = unitsShowns[4];
            tbkUnitsShowing1.Text = unitsShowns[5] + " " + unitsShowns[6] + " " + unitsShowns[7];
            tbkUnitsShowing2.Text = unitsShowns[8];
            tbkUnitsShowing3.Text = unitsShowns[9];
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 2)
            {
                stryInstructions.Begin();
            }
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Stop();
                CanvasAppearAndDissapear();
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        private void CanvasAppearAndDissapear()
        {
            //set ellipse1's dimensions, and viewbox's dimensions and positions.
            ellipse1.Height = Frame.ActualHeight / 7;
            ellipse1.Width = ellipse1.Height;

            viewbox_textBlock1.Height = ellipse1.Height / 2 * 1.414;  //sets height 
            viewbox_textBlock1.Width = viewbox_textBlock1.Height;

            Canvas.SetLeft(viewbox_textBlock1, ellipse1.Height / 2 * 0.2929);
            Canvas.SetTop(viewbox_textBlock1, ellipse1.Width / 2 * 0.2929);

            //ellipse2
            ellipse2.Height = Frame.ActualHeight / 5;
            ellipse2.Width = ellipse2.Height;

            viewbox_textBlock2.Height = ellipse2.Height / 2 * 1.414;  //sets height 
            viewbox_textBlock2.Width = viewbox_textBlock2.Height;

            Canvas.SetLeft(viewbox_textBlock2, ellipse2.Height / 2 * 0.2929);
            Canvas.SetTop(viewbox_textBlock2, ellipse2.Width / 2 * 0.2929);



            //ellipse3
            ellipse3.Height = Frame.ActualHeight / 3;
            ellipse3.Width = ellipse3.Height;

            viewbox_textBlock3.Height = ellipse3.Height / 2 * 1.414;  //sets height 
            viewbox_textBlock3.Width = viewbox_textBlock3.Height;

            Canvas.SetLeft(viewbox_textBlock3, ellipse3.Height / 2 * 0.2929);
            Canvas.SetTop(viewbox_textBlock3, ellipse3.Width / 2 * 0.2929);


            //ellipse4
            ellipse4.Height = Frame.ActualHeight / 10;
            ellipse4.Width = ellipse4.Height;

            viewbox_textBlock4.Height = ellipse4.Height / 2 * 1.414;  //sets height 
            viewbox_textBlock4.Width = viewbox_textBlock4.Height;

            Canvas.SetLeft(viewbox_textBlock4, ellipse4.Height / 2 * 0.2929);
            Canvas.SetTop(viewbox_textBlock4, ellipse4.Width / 2 * 0.2929);


            //ellipse5
            ellipse5.Height = Frame.ActualHeight / 6;
            ellipse5.Width = ellipse5.Height;

            viewbox_textBlock5.Height = ellipse5.Height / 2 * 1.414;  //sets height 
            viewbox_textBlock5.Width = viewbox_textBlock5.Height;

            Canvas.SetLeft(viewbox_textBlock5, ellipse5.Height / 2 * 0.2929);
            Canvas.SetTop(viewbox_textBlock5, ellipse5.Width / 2 * 0.2929);


            stry1a.Begin();
            stry1a.Completed += stry1a_Completed;
        
        }

        void stry1a_Completed(object sender, object e)
        {
            stry1b.Begin();
            stry2a.Begin();
            stry2a.Completed += stry2a_Completed;
        }

        void stry2a_Completed(object sender, object e)
        {
            stry2b.Begin();
            stry3a.Begin();
            stry3a.Completed += stry3a_Completed;
        }

        void stry3a_Completed(object sender, object e)
        {
            stry3b.Begin();
            stry4a.Begin();
            stry4a.Completed += stry4a_Completed;
        }

        void stry4a_Completed(object sender, object e)
        {
            stry4b.Begin();
            stry5a.Begin();
            stry5a.Completed += stry5a_Completed;
        }

        void stry5a_Completed(object sender, object e)
        {
            stry5b.Begin();
            TextBlockAppearAndDissapear();
        }

        private void TextBlockAppearAndDissapear()
        {

            viewboxUnitsShowing1.Opacity = 1;
            da_viewboxUnitsShowing1.From = viewboxUnitsShowing1.ActualWidth * -1;
            da_viewboxUnitsShowing1.To = Frame.ActualWidth + 10;
            da_viewboxUnitsShowing1.Duration = new Duration(TimeSpan.FromSeconds(10));
            stry6_tbkUnitsShowing1.Begin();

            viewboxUnitsShowing2.Opacity = 2;
            da_viewboxUnitsShowing2.From = viewboxUnitsShowing2.ActualHeight;
            da_viewboxUnitsShowing2.To = Frame.ActualHeight * -1 - 10;
            da_viewboxUnitsShowing2.Duration = new Duration(TimeSpan.FromSeconds(10));
            stry6_tbkUnitsShowing2.Begin();

            viewboxUnitsShowing3.Opacity = 3;
            da_viewboxUnitsShowing3.From = viewboxUnitsShowing3.ActualHeight;
            da_viewboxUnitsShowing3.To = Frame.ActualHeight * -1 - 10;
            da_viewboxUnitsShowing3.Duration = new Duration(TimeSpan.FromSeconds(10));
            stry6_tbkUnitsShowing3.Begin();

        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level5Answer));
        }

        public static string[] UnitsShowns
        {
            get { return unitsShowns; }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level5));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
