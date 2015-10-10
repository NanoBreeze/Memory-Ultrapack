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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level14 : Page
    {
        DateTime dateTime = new DateTime();
        //the first DispatcherTimer forces program to wait 5 seconds before animations begin
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        //the second DispatcherTimer indicates when we turn the textblocks into cards, continuous timing
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();


        //corresponding string value of the cards shown
        static List<string> list_orderOfCardsShown = new List<string>();

        //list of images and storyboards, to facilitate working with the switch statement
        static List<Image> list_images = new List<Image>();


        static string[] unitsShowns = new string[40];
        Random random = new Random();

        DispatcherTimer startTimer = new DispatcherTimer();
        DateTime startT = new DateTime();

        public Level14()
        {
            this.InitializeComponent();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dateTime = dateTime.AddSeconds(5);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();

            //adding images
            list_images.Add(image1);
            list_images.Add(image2);
            list_images.Add(image3);
            list_images.Add(image4);
            list_images.Add(image5);


            //making numbers
            for (int i = 0; i < 40; i++)
            {
                unitsShowns[i] = random.Next(0, 10).ToString();
            }

           

            startTimer.Interval = TimeSpan.FromSeconds(1);
            startT = startT.AddSeconds(5);
            startTimer.Tick += startTimer_Tick;
            startTimer.Start();
        }

        void startTimer_Tick(object sender, object e)
        {
            if (startT.Second == 2)
            {
                stryInstructions.Begin();
            }
            if (startT.Second == 0)
            {
                startTimer.Stop();
                startTimer.Tick -= startTimer_Tick;

                //showing numbers
                tbkUnitsShowing1.Text = "";
                for (int i = 0; i < 4; i++)
                {
                    tbkUnitsShowing1.Text += unitsShowns[i];
                }

                tbkUnitsShowing2.Text = "";
                for (int i = 4; i < 8; i++)
                {
                    tbkUnitsShowing2.Text += unitsShowns[i];
                }

                tbkUnitsShowing3.Text = "";
                for (int i = 8; i < 12; i++)
                {
                    tbkUnitsShowing3.Text += unitsShowns[i];
                }

                tbkUnitsShowing4.Text = "";
                for (int i = 12; i < 16; i++)
                {
                    tbkUnitsShowing4.Text += unitsShowns[i];
                }

                tbkUnitsShowing5.Text = "";
                for (int i = 16; i < 20; i++)
                {
                    tbkUnitsShowing5.Text += unitsShowns[i];
                }

                tbkUnitsShowing6.Text = "";
                for (int i = 20; i < 24; i++)
                {
                    tbkUnitsShowing6.Text += unitsShowns[i];
                }

                tbkUnitsShowing7.Text = "";
                for (int i = 24; i < 28; i++)
                {
                    tbkUnitsShowing7.Text += unitsShowns[i];
                }

                tbkUnitsShowing8.Text = "";
                for (int i = 28; i < 32; i++)
                {
                    tbkUnitsShowing8.Text += unitsShowns[i];
                }

                tbkUnitsShowing9.Text = "";
                for (int i = 32; i < 36; i++)
                {
                    tbkUnitsShowing9.Text += unitsShowns[i];
                }

                tbkUnitsShowing10.Text = "";
                for (int i = 36; i < 40; i++)
                {
                    tbkUnitsShowing10.Text += unitsShowns[i];
                }

            }
            else
            {
                startT = startT.AddSeconds(-1);
            }
        }


        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.Tick -= dispatcherTimer_Tick;
                
                //set initial and final destinations of the textblocks
                da_viewbox_tbkUnitsShowing1X.From = 0;
                da_viewbox_tbkUnitsShowing1Y.From = 0;
                da_viewbox_tbkUnitsShowing1X.To = Frame.ActualWidth/14 * 2;
                da_viewbox_tbkUnitsShowing1Y.To = Frame.ActualHeight * -1 / 7 * 2;

                da_viewbox_tbkUnitsShowing2X.From = 0;
                da_viewbox_tbkUnitsShowing2Y.From = 0;
                da_viewbox_tbkUnitsShowing2X.To = Frame.ActualWidth / 14 * 3;
                da_viewbox_tbkUnitsShowing2Y.To = Frame.ActualHeight * -1 / 7 * 3;

                da_viewbox_tbkUnitsShowing3X.To = Frame.ActualWidth / 14 * 4;
                da_viewbox_tbkUnitsShowing3Y.To = Frame.ActualHeight * -1 / 7 * 4;

                da_viewbox_tbkUnitsShowing4X.To = Frame.ActualWidth / 14 * 5;
                da_viewbox_tbkUnitsShowing4Y.To = Frame.ActualHeight * -1 / 7 * 5;

                da_viewbox_tbkUnitsShowing5X.To = Frame.ActualWidth / 14 * 6;
                da_viewbox_tbkUnitsShowing5Y.To = Frame.ActualHeight * -1 / 7 * 6;

                //begins the storyboards
                stry1_tbkUnitsShowing1.Begin();
                stry1_tbkUnitsShowing2.Begin();
                stry1_tbkUnitsShowing3.Begin();
                stry1_tbkUnitsShowing4.Begin();
                stry1_tbkUnitsShowing5.Begin();

                //begins countdown to turning textblocks into cards
                dispatcherTimer2.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer2.Tick += dispatcherTimer2_Tick;
                dispatcherTimer2.Start();
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        void dispatcherTimer2_Tick(object sender, object e)
        {
            dateTime = dateTime.AddSeconds(1);

         
            if (dateTime.Second == 11)
            {
                da_viewbox_tbkUnitsShowing6X.To = Frame.ActualWidth/14 * 5 + Frame.ActualWidth / 14 * 6;
                da_viewbox_tbkUnitsShowing6Y.To = Frame.ActualHeight  / 7 * 7;
                stry1_tbkUnitsShowing6.Begin();
                stry2_image1.Begin();
                ChooseCard(0);
            }
            if (dateTime.Second == 12)
            {
                da_viewbox_tbkUnitsShowing7X.To = Frame.ActualWidth / 14 * 5 + Frame.ActualWidth / 14 * 6;
                da_viewbox_tbkUnitsShowing7Y.To = Frame.ActualHeight / 7 * 6;
                stry1_tbkUnitsShowing7.Begin();
                stry2_image2.Begin();
                ChooseCard(1);
            }
            if (dateTime.Second == 13)
            {
                da_viewbox_tbkUnitsShowing8X.To = Frame.ActualWidth / 14 * 6 + Frame.ActualWidth / 14 * 6;
                da_viewbox_tbkUnitsShowing8Y.To = Frame.ActualHeight / 7 * 6;
                stry1_tbkUnitsShowing8.Begin();
                stry2_image3.Begin();
                ChooseCard(2);
            }
            if (dateTime.Second == 14)
            {
                da_viewbox_tbkUnitsShowing9X.To = Frame.ActualWidth / 14 * 7 + Frame.ActualWidth / 14 * 6;
                da_viewbox_tbkUnitsShowing9Y.To = Frame.ActualHeight / 7 * 6;
                stry1_tbkUnitsShowing9.Begin();
                stry2_image4.Begin();
                ChooseCard(3);
            }
            if (dateTime.Second == 15)
            {
                da_viewbox_tbkUnitsShowing10X.To = Frame.ActualWidth / 14 * 8 + Frame.ActualWidth / 14 * 6;
                da_viewbox_tbkUnitsShowing10Y.To = Frame.ActualHeight / 7 * 6;
                stry1_tbkUnitsShowing10.Begin();
                stry2_image5.Begin();
                ChooseCard(4);
            }
        }

        private void ChooseCard(int i)
        {
            #region choosing card
            switch (random.Next(1, 53))
            {
                case 1:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S1.png"));
                    list_orderOfCardsShown.Add("S1");


                    //images to the latest/last stackpanel in the list.
                    break;
                case 2:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S2.png"));
                    list_orderOfCardsShown.Add("S2");

                    //images to the latest/last stackpanel in the list.
                    break;
                case 3:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S3.png"));
                    list_orderOfCardsShown.Add("S3");


                    break;
                case 4:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S4.png"));
                    list_orderOfCardsShown.Add("S4");

                    break;
                case 5:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S5.png"));
                    list_orderOfCardsShown.Add("S5");

                    break;
                case 6:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S6.png"));
                    list_orderOfCardsShown.Add("S6");

                    break;
                case 7:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S7.png"));
                    list_orderOfCardsShown.Add("S7");

                    break;
                case 8:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S8.png"));
                    list_orderOfCardsShown.Add("S8");

                    break;
                case 9:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S9.png"));
                    list_orderOfCardsShown.Add("S9");


                    break;
                case 10:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S10.png"));
                    list_orderOfCardsShown.Add("S10");

                    break;
                case 11:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S11.png"));
                    list_orderOfCardsShown.Add("S11");

                    break;
                case 12:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S12.png"));
                    list_orderOfCardsShown.Add("S12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 13:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Spades/S13.png"));
                    list_orderOfCardsShown.Add("S13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 14:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H1.png"));
                    list_orderOfCardsShown.Add("H1");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 15:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H2.png"));
                    list_orderOfCardsShown.Add("H2");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 16:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H3.png"));
                    list_orderOfCardsShown.Add("H3");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 17:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H4.png"));
                    list_orderOfCardsShown.Add("H4");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 18:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H5.png"));
                    list_orderOfCardsShown.Add("H5");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 19:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H6.png"));
                    list_orderOfCardsShown.Add("H6");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 20:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H7.png"));
                    list_orderOfCardsShown.Add("H7");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 21:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H8.png"));
                    list_orderOfCardsShown.Add("H8");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 22:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H9.png"));
                    list_orderOfCardsShown.Add("H9");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 23:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H10.png"));
                    list_orderOfCardsShown.Add("H10");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 24:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H11.png"));
                    list_orderOfCardsShown.Add("H11");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 25:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H12.png"));
                    list_orderOfCardsShown.Add("H12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 26:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Hearts/H13.png"));
                    list_orderOfCardsShown.Add("H13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                    case 27:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D1.png"));
                    list_orderOfCardsShown.Add("D1");


                    //images to the latest/last stackpanel in the list.
                    break;
                case 28:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D2.png"));
                    list_orderOfCardsShown.Add("D2");

                    //images to the latest/last stackpanel in the list.
                    break;
                case 29:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D3.png"));
                    list_orderOfCardsShown.Add("D3");


                    break;
                case 30:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D4.png"));
                    list_orderOfCardsShown.Add("D4");

                    break;
                case 31:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D5.png"));
                    list_orderOfCardsShown.Add("D5");

                    break;
                case 32:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D6.png"));
                    list_orderOfCardsShown.Add("D6");

                    break;
                case 33:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D7.png"));
                    list_orderOfCardsShown.Add("D7");

                    break;
                case 34:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D8.png"));
                    list_orderOfCardsShown.Add("D8");

                    break;
                case 35:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D9.png"));
                    list_orderOfCardsShown.Add("D9");


                    break;
                case 36:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D10.png"));
                    list_orderOfCardsShown.Add("D10");

                    break;
                case 37:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D11.png"));
                    list_orderOfCardsShown.Add("D11");

                    break;
                case 38:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D12.png"));
                    list_orderOfCardsShown.Add("D12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 39:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Diamonds/D13.png"));
                    list_orderOfCardsShown.Add("D13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 40:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C1.png"));
                    list_orderOfCardsShown.Add("C1");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 41:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C2.png"));
                    list_orderOfCardsShown.Add("C2");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 42:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C3.png"));
                    list_orderOfCardsShown.Add("C3");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 43:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C4.png"));
                    list_orderOfCardsShown.Add("C4");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 44:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C5.png"));
                    list_orderOfCardsShown.Add("C5");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 45:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C6.png"));
                    list_orderOfCardsShown.Add("C6");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 46:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C7.png"));
                    list_orderOfCardsShown.Add("C7");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 47:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C8.png"));
                    list_orderOfCardsShown.Add("C8");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 48:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C9.png"));
                    list_orderOfCardsShown.Add("C9");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 49:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C10.png"));
                    list_orderOfCardsShown.Add("C10");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 50:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C11.png"));
                    list_orderOfCardsShown.Add("C11");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 51:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C12.png"));
                    list_orderOfCardsShown.Add("C12");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                case 52:
                    list_images[i].Source = new BitmapImage(new Uri("ms-appx:///Assets/Clubs/C13.png"));
                    list_orderOfCardsShown.Add("C13");

                    //since we use our stackpanels sequentially, we're always be adding the
                    //images to the latest/last stackpanel in the list.
                    break;
                default:
                    throw new ArgumentException("Something unexpected happened");
            }
            #endregion

        }

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level14Answer));
        }

        public static string[] UnitsShowns
        {
            get { return unitsShowns; }
        }

        public static List<string> List_OrderOfCardsShown
        {
            get { return list_orderOfCardsShown; }
        }

        public static List<Image> List_images
        {
            get { return list_images; }
        }

        private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Level14));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
