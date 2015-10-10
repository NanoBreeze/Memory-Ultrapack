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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level13 : Page
    {
        static string[] unitsShowns = new string[24];

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();

        DateTime dateTime = new DateTime();
        DateTime dateTime2 = new DateTime();

        //corresponding string value of the cards shown
       static  List<string> list_orderOfCardsShown = new List<string>();

        //list of images and storyboards, to facilitate working with the switch statement
       static  List<Image> list_images = new List<Image>();
        List<Storyboard> list_storyboards = new List<Storyboard>();

        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        Random random = new Random();

        int j = 0;


        DispatcherTimer startTimer = new DispatcherTimer();
        DateTime startT = new DateTime();

        public Level13()
        {
            this.InitializeComponent();

            //set the dispatcherTimer and dateTime ready
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;

            dispatcherTimer2.Interval = TimeSpan.FromSeconds(1);

            //adding the images to a list, makes life easier
            list_images.Add(image1);
            list_images.Add(image2);
            list_images.Add(image3);
            list_images.Add(image4);
            list_images.Add(image5);
            list_images.Add(image6);
            list_images.Add(image7);
            list_images.Add(image8);
            list_images.Add(image9);
            list_images.Add(image10);
            list_images.Add(image11);
            list_images.Add(image12);


            //adding storyboards to a list, also makes life easier
            list_storyboards.Add(stry1a);
            list_storyboards.Add(stry1b);
            list_storyboards.Add(stry2a);
            list_storyboards.Add(stry2b);
            list_storyboards.Add(stry3a);
            list_storyboards.Add(stry3b);
            list_storyboards.Add(stry4a);
            list_storyboards.Add(stry4b);
            list_storyboards.Add(stry5a);
            list_storyboards.Add(stry5b);
            list_storyboards.Add(stry6a);
            list_storyboards.Add(stry6b);
            list_storyboards.Add(stry7a);
            list_storyboards.Add(stry7b);
            list_storyboards.Add(stry8a);
            list_storyboards.Add(stry8b);
            list_storyboards.Add(stry9a);
            list_storyboards.Add(stry9b);
            list_storyboards.Add(stry10a);
            list_storyboards.Add(stry10b);
            list_storyboards.Add(stry11a);
            list_storyboards.Add(stry11b);
            list_storyboards.Add(stry12a);
            list_storyboards.Add(stry12b);

            //make capital letters
            for (int i = 0; i < 12; i++)  
            {
                unitsShowns[i] = letters[random.Next(0, 25)];
            }

            //make lowercase letters
            for (int i = 12; i < 24; i++)
            {
                unitsShowns[i] = letters[random.Next(26, 52)];
            }


            //Show letters
            tbkUnitsShowing1.Text = unitsShowns[0];
            tbkUnitsShowing2.Text = unitsShowns[1];
            tbkUnitsShowing3.Text = unitsShowns[2];
            tbkUnitsShowing4.Text = unitsShowns[3];
            tbkUnitsShowing5.Text = unitsShowns[4];
            tbkUnitsShowing6.Text = unitsShowns[5];
            tbkUnitsShowing7.Text = unitsShowns[6];
            tbkUnitsShowing8.Text = unitsShowns[7];
            tbkUnitsShowing9.Text = unitsShowns[8];
            tbkUnitsShowing10.Text = unitsShowns[9];
            tbkUnitsShowing11.Text = unitsShowns[10];
            tbkUnitsShowing12.Text = unitsShowns[11];

            tbkUnitsShowing13.Text = unitsShowns[12];
            tbkUnitsShowing14.Text = unitsShowns[13];
            tbkUnitsShowing15.Text = unitsShowns[14];
            tbkUnitsShowing16.Text = unitsShowns[15];
            tbkUnitsShowing17.Text = unitsShowns[16];
            tbkUnitsShowing18.Text = unitsShowns[17];
            tbkUnitsShowing19.Text = unitsShowns[18];
            tbkUnitsShowing20.Text = unitsShowns[19];
            tbkUnitsShowing21.Text = unitsShowns[20];
            tbkUnitsShowing22.Text = unitsShowns[21];
            tbkUnitsShowing23.Text = unitsShowns[22];
            tbkUnitsShowing24.Text = unitsShowns[23];

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
                CreateAndAnimateCards(0);
            }
            else
            {
                startT = startT.AddSeconds(-1);
            }
        }


        private void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.Tick -= dispatcherTimer_Tick;
        
                list_storyboards[j * 2 + 1].Begin();
                list_storyboards[j * 2].Completed -= Level13_Completed;

                dateTime2 = dateTime2.AddSeconds(2);
                dispatcherTimer2.Tick += dispatcherTimer2_Tick;
                dispatcherTimer2.Start();
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        private void dispatcherTimer2_Tick(object sender, object e)
        {
            if (dateTime2.Second == 0)
            {
                dispatcherTimer2.Stop();
                dispatcherTimer2.Tick -= dispatcherTimer2_Tick;

                if (j != 11)
                    CreateAndAnimateCards(j + 1);

                if (j == 11)
                {
                    btnGoToAnswerPage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
            }
            else
            {
                dateTime2 = dateTime2.AddSeconds(-1);
            }
        }

        private void CreateAndAnimateCards(int i)      //i indicates the index of list_images and list_storyboards 
        {

            #region choosing card
            switch (random.Next(1, 27))
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
                default:
                    throw new ArgumentException("Something unexpected happened");
            }
            #endregion

            dateTime = dateTime.AddSeconds(5);
            j = i;

            list_storyboards[i * 2].Begin();
            list_storyboards[i * 2].Completed += Level13_Completed;
        }

        private void Level13_Completed(object sender, object e)
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }



        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level13Answer));
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
            Frame.Navigate(typeof(Level13));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

    }
}
