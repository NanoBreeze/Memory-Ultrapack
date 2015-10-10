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
    public sealed partial class Level10 : Page
    {
        static string[] unitsShowns = new string[32];

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();

        DateTime dateTime = new DateTime();
        DateTime dateTime2 = new DateTime();

        DispatcherTimer startTimer = new DispatcherTimer();
        DateTime startT = new DateTime();


        //corresponding string value of the cards shown
        static List<string> list_orderOfCardsShown = new List<string>();

        //list of images and storyboards, to facilitate working with the switch statement
        static List<Image> list_images = new List<Image>();
        List<Storyboard> list_storyboards = new List<Storyboard>();

        Random random = new Random();

        string[] letters = new string[] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
           "a","b","c","d","e","f","g","h","i","j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };

        string[] symbols = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "?", "/" };  

        int j = 0; //j is the same as i, the parameter passed into CreateAndAnimateCards(i)

        public Level10()
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

           
            //make numbers, letters, and symbols
            unitsShowns[0] = random.Next(1, 10).ToString();

            for (int i = 1; i < 10; i ++ )  //making numbers
            {
                unitsShowns[i] = random.Next(0, 10).ToString(); ;
            }

            for (int i = 10; i < 20; i++ )  //making letters
            {
                unitsShowns[i] = letters[random.Next(0, 52)];
            }

            for (int i = 20; i < 32; i++)   //making symbols
            {
                unitsShowns[i] = symbols[random.Next(0, 10)];
            }

            startT = startT.AddSeconds(5);
            startTimer.Interval = TimeSpan.FromSeconds(1);
            startTimer.Tick += startTimer_Tick;
            startTimer.Start();  
        }

        void startTimer_Tick(object sender, object e)
        {
            if (startT.Second == 3)
            {
                stryInstructions.Begin();
            }
            if (startT.Second == 0)
            {
                startTimer.Stop();
                startTimer.Tick -= startTimer_Tick;

                //Show numbers, letters, and symbols
                tbkUnitsShowing1.Text = "";

                for (int i = 0; i < 10; i++)
                {
                    tbkUnitsShowing1.Text += unitsShowns[i];
                }

                for (int i = 10; i < 20; i++)
                {
                    tbkUnitsShowing2.Text += unitsShowns[i];
                }

                for (int i = 20; i < 32; i++)
                {
                    tbkUnitsShowing3.Text += unitsShowns[i];
                }

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
                list_storyboards[j * 2].Completed -= Level10_Completed;

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

                if (j != 4)
                CreateAndAnimateCards(j + 1);

                if (j == 4)
                {
                    btnGoToAnswerPage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
            }
            else
            {
                dateTime2 = dateTime2.AddSeconds(-1);
            }
        }

        private void CreateAndAnimateCards( int i)      //i indicates the index of list_images and list_storyboards 
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
                list_storyboards[i*2].Completed += Level10_Completed;
        }

        private void Level10_Completed(object sender, object e)
        {
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

       

        private void btnGoToAnswerPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Games.Level10Answer));
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
            Frame.Navigate(typeof(Level10));
        }

        private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
