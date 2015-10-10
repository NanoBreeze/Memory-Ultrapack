using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cards : Page
    {
        private static int toggle = 0;      //determines which toggle button is on.
        private static bool captionOn = false;

        public static bool CaptionOn
        {
            get { return captionOn; }
        }

        public static int Toggle
        {
            get { return toggle; }
            set { toggle = value; }
        }

        DispatcherTimer timer = new DispatcherTimer();
        DateTime dateTime_CountDown = new DateTime();

        static List<string> list_orderOfCardsShown = new List<string>();   //Holds the string version of the cards. Its count is the number of cards shown, which helps us keep track 
        //the number of stackpanelswe'll need
        List<StackPanel> list_stackpanels = new List<StackPanel>(); //stackpanels that display images are added to this list this list has broad scope so those stackpanels
        //can be accessed programatically
        int[] cardsToDisplays;           //this array holds random numbers in its indices. When btnDeck is pressed, we sequentially display
        //the card that correspond with the index's number

        int indexOfCardsToDisplays = 0;
        int cardsPerStackPanel = 6;         //the number of cards shown in each stackpanel

        static int setTimer_minute = 7777;
        static int setTimer_second = 7777;

        public static int SetTime_minute
        {
            get { return setTimer_minute; }
            set { setTimer_minute = value; }
         }

        public static int SetTime_second
        {
            get { return setTimer_second; }
            set { setTimer_second = value; }
        }

        int numberOfOn = 0;
        bool clubOn = false;
        bool spadeOn = false;
        bool diamondOn = false;
        bool heartOn = false;


        public Cards()
        {
            this.InitializeComponent();
            toggle = Cards2.Toggle;
            captionOn = Cards2.CaptionOn;

            if (setTimer_minute == 7777 && setTimer_second == 7777)
            {
                commandbar_timer_tbxMinutes.Text = "";
                commandbar_timer_tbxSeconds.Text = "";
            }
            else
            {
                commandbar_timer_tbxMinutes.Text = setTimer_minute.ToString();
                commandbar_timer_tbxSeconds.Text = setTimer_second.ToString();
            }
 
        }

        public void PlacingNumbersInIndex(int index, int number, int[] array)
        {
            if (array[index] == 0)
            {
                array[index] = number;
            }
            else
            {
                if (index == cardsToDisplays.Length -1)
                {
                    PlacingNumbersInIndex(0, number, array);
                }
                else
                {
                    PlacingNumbersInIndex(index + 1, number, array);
                }
            }
        }

        private void stpn_btnDeck_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random(); //randomly selects one of the three images to make;

            if (numberOfOn == 0)
            {
                viewboxPleaseSelectSuite.Opacity = 1;
            }
            else
            {
                hyperlink.Visibility = Windows.UI.Xaml.Visibility.Visible;

                //Begin the timer count down from the user's set time or predefined time. Beginning the countdown occurs once, when list_orderOfCardsShown is empty
                if (list_orderOfCardsShown.Count == 0)
                {
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

                        tbkDigitalClock_Minutes.Opacity = 1;
                        tbkDigitalClock_Seconds.Opacity = 1;
                        tbkTimeRemaining.Opacity = 1;

                        timer.Interval = TimeSpan.FromSeconds(1);
                        timer.Tick += timerCountDown;

                        dateTime_CountDown = dateTime_CountDown.AddMinutes(setTimer_minute);
                        dateTime_CountDown = dateTime_CountDown.AddSeconds(setTimer_second);

                        timer.Start();
                    }

                    Random ra = new Random();

                    for (int i = 1; i <= 52; i++)
                    {
                        int randomIndex = ra.Next(0, cardsToDisplays.Length);

                        if (spadeOn == false && heartOn == false && diamondOn == false && clubOn == false)
                        {
                            break;
                        }

                        if ((spadeOn == false && (i >= 1 && i <= 13)) || (heartOn == false && (i >= 14 && i <= 26)) || (diamondOn == false && (i >= 27 && i <= 39)) || (clubOn == false && (i >= 40 && i <= 52)))
                        {
                            continue;
                        }


                        if (cardsToDisplays[randomIndex] == 0)
                        {
                            cardsToDisplays[randomIndex] = i;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                    }

                }


                if (list_orderOfCardsShown.Count % cardsPerStackPanel == 0)
                {
                    StackPanel stpn2 = new StackPanel();
                    stpn2.Orientation = Orientation.Horizontal;
                    stpn2.Width = stpnMain.ActualWidth;

                    if (list_orderOfCardsShown.Count == 0)
                    {
                        stpn2.Height = stpnMain.ActualHeight / 3;
                    }
                    else
                    {
                        stpn2.Height = list_stackpanels[0].ActualHeight;
                    }
                    list_stackpanels.Add(stpn2);            //we add stpn2 here instead of at the end so that its future children images can refer to it.
                    stpnMain.Children.Add(list_stackpanels[list_stackpanels.Count - 1]);
                }

                if (list_orderOfCardsShown.Count == 1)
                    cardsPerStackPanel = (int)(list_stackpanels[0].ActualWidth / (list_stackpanels[0].ActualHeight / 1.4));

                //Prepares image creation; now, we'll need to give it a source. The image's height equals the first stackpanel's rendered height. However, if this 
                //is the first image created, the first stackpanel is not yet rendered but if it were, it would be equal to one thrid of stpnMain's rendered height

                Image stpn2_image1 = new Image();
                if (list_orderOfCardsShown.Count == 0)
                {
                    stpn2_image1.Height = stpnMain.ActualHeight / 3;
                }
                else
                {
                    stpn2_image1.Height = list_stackpanels[0].ActualHeight;
                }

                //Prepares image animation
                Storyboard sb = new Storyboard();


                //Double animation in X direction
                DoubleAnimation daX = new DoubleAnimation();
                CompositeTransform compositeXTransform = new CompositeTransform();
                stpn2_image1.RenderTransform = compositeXTransform;
                stpn2_image1.RenderTransformOrigin = new Point(0, 0);

                daX.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                daX.From = 10;

                Storyboard.SetTarget(daX, compositeXTransform);
                Storyboard.SetTargetProperty(daX, "TranslateX");


                //Double animation in Y direction
                DoubleAnimation daY = new DoubleAnimation();
                CompositeTransform compositeYTransform = new CompositeTransform();
                stpn2_image1.RenderTransform = compositeYTransform;
                stpn2_image1.RenderTransformOrigin = new Point(0, 0);

                daY.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                daY.From = 10;

                Storyboard.SetTarget(daY, compositeYTransform);
                Storyboard.SetTargetProperty(daY, "TranslateY");


                //Double animation to create fade-in effect, changing opacity
                DoubleAnimation daOpacity = new DoubleAnimation();
                daOpacity.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                daOpacity.From = 0;
                daOpacity.To = 1;
                Storyboard.SetTarget(daOpacity, stpn2_image1);
                Storyboard.SetTargetProperty(daOpacity, "Opacity");

                sb.Children.Add(daX);
                sb.Children.Add(daY);
                sb.Children.Add(daOpacity);

                if (indexOfCardsToDisplays == cardsToDisplays.Length - 3)           //if there remains cards to display
                {
                    image_deck.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/TwoCards.png"));
                }

                if (indexOfCardsToDisplays == cardsToDisplays.Length - 2)           //if there remains cards to display
                {
                    image_deck.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/OneCard.png"));
                }

                if (indexOfCardsToDisplays == cardsToDisplays.Length - 1)           //if there remains cards to display
                {
                    image_deck.Source = null;
                    tbkDeckComplete.Opacity = 1;
                    tbkDeckComplete.Text = "The deck is now complete.";
                }


                if (indexOfCardsToDisplays == cardsToDisplays.Length)           //if there remains cards to display
                {
                    image_deck.Source = null;
                    tbkDeckComplete.Opacity = 1;
                    tbkDeckComplete.Text = "The deck is now complete.";
                }
                else
                {
                    switch (cardsToDisplays[indexOfCardsToDisplays])
                    {
                        #region cases from 1 to 52
                        case 1:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S1.png"));
                            list_orderOfCardsShown.Add("S1");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 2:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S2.png"));
                            list_orderOfCardsShown.Add("S2");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 3:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S3.png"));
                            list_orderOfCardsShown.Add("S3");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 4:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S4.png"));
                            list_orderOfCardsShown.Add("S4");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 5:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S5.png"));
                            list_orderOfCardsShown.Add("S5");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 6:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S6.png"));
                            list_orderOfCardsShown.Add("S6");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 7:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S7.png"));
                            list_orderOfCardsShown.Add("S7");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 8:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S8.png"));
                            list_orderOfCardsShown.Add("S8");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 9:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S9.png"));
                            list_orderOfCardsShown.Add("S9");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 10:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S10.png"));
                            list_orderOfCardsShown.Add("S10");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 11:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S11.png"));
                            list_orderOfCardsShown.Add("S11");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 12:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S12.png"));
                            list_orderOfCardsShown.Add("S12");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 13:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S13.png"));
                            list_orderOfCardsShown.Add("S13");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 14:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H1.png"));
                            list_orderOfCardsShown.Add("H1");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 15:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H2.png"));
                            list_orderOfCardsShown.Add("H2");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 16:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H3.png"));
                            list_orderOfCardsShown.Add("H3");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 17:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H4.png"));
                            list_orderOfCardsShown.Add("H4");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 18:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H5.png"));
                            list_orderOfCardsShown.Add("H5");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 19:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H6.png"));
                            list_orderOfCardsShown.Add("H6");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 20:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H7.png"));
                            list_orderOfCardsShown.Add("H7");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 21:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H8.png"));
                            list_orderOfCardsShown.Add("H8");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 22:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H9.png"));
                            list_orderOfCardsShown.Add("H9");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 23:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H10.png"));
                            list_orderOfCardsShown.Add("H10");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 24:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H11.png"));
                            list_orderOfCardsShown.Add("H11");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 25:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H12.png"));
                            list_orderOfCardsShown.Add("H12");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 26:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H13.png"));
                            list_orderOfCardsShown.Add("H13");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 27:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D1.png"));
                            list_orderOfCardsShown.Add("D1");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 28:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D2.png"));
                            list_orderOfCardsShown.Add("D2");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 29:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D3.png"));
                            list_orderOfCardsShown.Add("D3");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 30:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D4.png"));
                            list_orderOfCardsShown.Add("D4");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 31:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D5.png"));
                            list_orderOfCardsShown.Add("D5");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 32:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D6.png"));
                            list_orderOfCardsShown.Add("D6");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 33:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D7.png"));
                            list_orderOfCardsShown.Add("D7");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 34:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D8.png"));
                            list_orderOfCardsShown.Add("D8");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 35:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D9.png"));
                            list_orderOfCardsShown.Add("D9");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 36:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D10.png"));
                            list_orderOfCardsShown.Add("D10");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 37:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D11.png"));
                            list_orderOfCardsShown.Add("D11");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 38:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D12.png"));
                            list_orderOfCardsShown.Add("D12");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 39:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D13.png"));
                            list_orderOfCardsShown.Add("D13");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 40:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C1.png"));
                            list_orderOfCardsShown.Add("C1");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 41:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C2.png"));
                            list_orderOfCardsShown.Add("C2");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 42:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C3.png"));
                            list_orderOfCardsShown.Add("C3");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 43:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C4.png"));
                            list_orderOfCardsShown.Add("C4");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 44:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C5.png"));
                            list_orderOfCardsShown.Add("C5");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 45:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C6.png"));
                            list_orderOfCardsShown.Add("C6");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 46:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C7.png"));
                            list_orderOfCardsShown.Add("C7");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 47:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C8.png"));
                            list_orderOfCardsShown.Add("C8");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 48:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C9.png"));
                            list_orderOfCardsShown.Add("C9");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 49:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C10.png"));
                            list_orderOfCardsShown.Add("C10");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 50:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C11.png"));
                            list_orderOfCardsShown.Add("C11");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 51:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C12.png"));
                            list_orderOfCardsShown.Add("C12");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        case 52:
                            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C13.png"));
                            list_orderOfCardsShown.Add("C13");
                            sb.Begin();
                            list_stackpanels[list_stackpanels.Count - 1].Children.Add(stpn2_image1);      //since we use our stackpanels sequentially, we're always be adding the
                            //images to the latest/last stackpanel in the list.
                            break;
                        default:
                            break;
                        #endregion
                    }

                    indexOfCardsToDisplays++;

                    scrollViewer.ChangeView(0, stpnMain.ActualHeight, 1);
                }
            }
        }

        private void timerCountDown(object sender, object e)
        {
            if (dateTime_CountDown.Second == 0 && dateTime_CountDown.Minute == 0)
            {
                timer.Stop();
                Frame.Navigate(typeof(Cards2));
                Cards2.SetTime_minute = setTimer_minute;
                Cards2.SetTime_second = setTimer_second;
            }
            else
            {
                dateTime_CountDown = dateTime_CountDown.AddSeconds(-1);

                //the textblock with text "Time Remaining" is now visible
                tbkTimeRemaining.Opacity = 1;

   
                tbkDigitalClock_Minutes.Text = dateTime_CountDown.ToString("mm");
                tbkDigitalClock_Seconds.Text = dateTime_CountDown.ToString("ss");
            }
        }

        private void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Tick -= timerCountDown;
            Frame.Navigate(typeof(Cards2));
            Cards2.SetTime_minute = setTimer_minute;
            Cards2.SetTime_second = setTimer_second;

        }

        public static List<string> List_orderOfCardsShown
        {
            get { return list_orderOfCardsShown; }
        }


        /*     private void btnButton_Click(object sender, RoutedEventArgs e)
             {
                 Random random = new Random(); //randomly selects one of the three images to make;

                 switch (random.Next(1, 4))
                 {
                     case 1:
                         imageBox.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/One.png"));
                         list_orderOfCardsShown.Add("One");
                         break;
                     case 2:
                         imageBox.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Two.png"));
                         list_orderOfCardsShown.Add("Two");
                         break;
                     case 3:
                         imageBox.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Three.png"));
                         list_orderOfCardsShown.Add("Three");
                         break;
                     default:
                         break;

                 }
                 // Image image = new Image();


                 int j = counter % 6;
                 counter++;

                 double width = trid.ActualWidth * (j - 3);

                 doubleAnimationX.To = width;
                 doubleAnimationY.To = grid.ActualHeight / -2;
                 stbAnimatingImage.Begin();

                 DispatcherTimer timer = new DispatcherTimer();
                 timer.Interval = TimeSpan.FromSeconds(1);
                 timer.Tick += timer_Tick;

                 timer.Start();

                 //     stpn.Children.Add(imageBox);

             }
             */
        /*     void timer_Tick(object sender, object e)
             {
                 dateTime = dateTime.AddSeconds(1);
                 //   string time = dateTime.TimeOfDay.Add(TimeSpan.FromSeconds(1)).ToString();


                 tbkDigitalClock.Text = dateTime.ToString("HH:mm:ss");
             }
     
             private void btnAnswer_Click(object sender, RoutedEventArgs e)
             {
                 if (tbxNameOfCard.Text == list_orderOfCardsShown[0])
                 {
                     tbkDigitalClock.Text += Frame.ActualWidth.ToString();
                 }
                 else
                 {
                     tbkDigitalClock.Text += "Incorrect";
                 }
             }

        /*     private void stpn_btnTest_Click(object sender, RoutedEventArgs e)
             {
                 stpn1.Height = stpnMain.ActualHeight;

                 stpn1_rect1.Width = stpn1.ActualWidth/5;
                 stpn1_rect2.Width = stpn1.ActualWidth / 5;
                 stpn1_rect3.Width = stpn1.ActualWidth / 5;
                 stpn1_rect4.Width = stpn1.ActualWidth / 5;
             }
             */
        private void stpn_btnAddStackPanel_Click(object sender, RoutedEventArgs e)
        {

            //we create a storyboard to animate the image when it is created



            SolidColorBrush color = new SolidColorBrush(Windows.UI.Colors.Yellow);
            Thickness thick = new Thickness(10);

            StackPanel stpn2 = new StackPanel();
            stpn2.Orientation = Orientation.Horizontal;
            //    stpn2.Width = stpn1.ActualWidth;
            //     stpn2.Height = stpn1.ActualHeight;



            Image stpn2_image1 = new Image();
            stpn2_image1.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/One.png"));
            stpn2_image1.Margin = thick;
            stpn2_image1.Width = stpnMain.ActualWidth / 5;
            stpn2_image1.RenderTransformOrigin = new Point(0, 0);
            CompositeTransform composite = new CompositeTransform();
            stpn2_image1.RenderTransform = composite;


            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 100;
            doubleAnimation.To = -10;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(4));

            Storyboard.SetTarget(doubleAnimation, composite);
            Storyboard.SetTargetProperty(doubleAnimation, "TranslateX");

            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();




            Rectangle stpn2_rect2 = new Rectangle();
            stpn2_rect2.Fill = color;
            stpn2_rect2.Width = stpnMain.ActualWidth / 5;
            stpn2_rect2.Margin = thick;

            Rectangle stpn2_rect3 = new Rectangle();
            stpn2_rect3.Fill = color;
            stpn2_rect3.Width = stpnMain.ActualWidth / 5;
            stpn2_rect3.Margin = thick;
            Rectangle stpn2_rect4 = new Rectangle();
            stpn2_rect4.Fill = color;
            stpn2_rect4.Width = stpnMain.ActualWidth / 5;
            stpn2_rect4.Margin = thick;


            stpn2.Children.Add(stpn2_image1);
            stpn2.Children.Add(stpn2_rect2);
            stpn2.Children.Add(stpn2_rect3);
            stpn2.Children.Add(stpn2_rect4);

            stpnMain.Children.Add(stpn2);
        }

        private void btnTimerCountDown_Click(object sender, RoutedEventArgs e)
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerCountDown;

            dateTime_CountDown = dateTime_CountDown.AddMinutes(5);

            timer.Start();
        }

        private void btnSpades_Click(object sender, RoutedEventArgs e)
        {
            if (spadeOn)
            {
                spadeOn = false;
                btnSpades.Background = new SolidColorBrush(Colors.Gray);
                numberOfOn--;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();
            }
            else
            {
                spadeOn = true;
                btnSpades.Background = new SolidColorBrush(Colors.Brown);
                numberOfOn++;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();

            }
        }

        private void btnHearts_Click(object sender, RoutedEventArgs e)
        {
            if (heartOn)
            {
                heartOn = false;
                btnHearts.Background = new SolidColorBrush(Colors.Gray);
                numberOfOn--;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();
            }
            else
            {
                heartOn = true;
                btnHearts.Background = new SolidColorBrush(Colors.Brown);
                numberOfOn++;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();

            }
        }

        private void btnClubs_Click(object sender, RoutedEventArgs e)
        {
            if (clubOn)
            {
                clubOn = false;
                btnClubs.Background = new SolidColorBrush(Colors.Gray);
                numberOfOn--;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();


            }
            else
            {
                clubOn = true;
                btnClubs.Background = new SolidColorBrush(Colors.Brown);
                numberOfOn++;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();

            }
        }

        private void btnDiamonds_Click(object sender, RoutedEventArgs e)
        {
            if (diamondOn)
            {
                diamondOn = false;
                btnDiamonds.Background = new SolidColorBrush(Colors.Gray);
                numberOfOn--;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();
            }
            else
            {
                diamondOn = true;
                btnDiamonds.Background = new SolidColorBrush(Colors.Brown);
                numberOfOn++;

                if (numberOfOn != 0)
                {
                    viewboxPleaseSelectSuite.Opacity = 0;
                }
                else
                {
                    viewboxPleaseSelectSuite.Opacity = 1;
                }

                ClearScreen();

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

        private void ClearScreen()
        {
          
            list_orderOfCardsShown.Clear();
            list_stackpanels.Clear();
            indexOfCardsToDisplays = 0;
            stpnMain.Children.Clear();
            image_deck.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/ThreeCards.png"));
            tbkDeckComplete.Opacity = 0;

            tbkDigitalClock_Minutes.Opacity = 0;
            tbkDigitalClock_Seconds.Opacity = 0;
            tbkTimeRemaining.Opacity = 0;


            dateTime_CountDown = dateTime_CountDown.AddMinutes(dateTime_CountDown.Minute * -1);
            dateTime_CountDown = dateTime_CountDown.AddSeconds(dateTime_CountDown.Second * -1);

            timer.Stop();
            timer.Tick -=  timerCountDown;

            cardsToDisplays = new int[numberOfOn * 13];
        }
    }
}
