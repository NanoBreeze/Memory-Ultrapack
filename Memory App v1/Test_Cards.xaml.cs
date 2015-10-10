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
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test_Cards : Page
    {
        DispatcherTimer instructionsDispatcher = new DispatcherTimer();
        DateTime instructionDateTime = new DateTime();
        bool captionOn = false;

        int initialNumberOfCards = 3;
        int[] cardsToDisplays;
        int[] controlRandomNumber;
        Image[] images = new Image[52];

        //cards variables
        List<TextBlock> list_textBlocks = new List<TextBlock>();
        List<Image> list_images = new List<Image>();
        static List<string> list_orderOfCardsShown = new List<string>();   //Holds the string version of the cards. Its count is the number of cards shown, which helps us keep track 

        List<string> list_orderOfCardsPressed = new List<string>();
       static int pressedNumber = 0;  //displays digit in textblock

       DateTime dateTime = new DateTime();
       DispatcherTimer dispatcherTimer = new DispatcherTimer();

       DateTime dateTimeBreak = new DateTime();
       DispatcherTimer dispatcherTimerBreak = new DispatcherTimer();

       int numberOfWrongAnswer = 0;

       ApplicationDataContainer applicationDataContainer = ApplicationData.Current.LocalSettings;
       int[] highScores = new int[5];


       DispatcherTimer fontsizeDT = new DispatcherTimer();

        public Test_Cards()
        {
            this.InitializeComponent();

            fontsizeDT.Interval = TimeSpan.FromMilliseconds(20);
            fontsizeDT.Tick += fontsizeDT_Tick;
            fontsizeDT.Start();

            highScores[0] = (int)applicationDataContainer.Values["HighScore1_Card"];
            highScores[1] = (int)applicationDataContainer.Values["HighScore2_Card"];
            highScores[2] = (int)applicationDataContainer.Values["HighScore3_Card"];
            highScores[3] = (int)applicationDataContainer.Values["HighScore4_Card"];
            highScores[4] = (int)applicationDataContainer.Values["HighScore5_Card"];



#region setting images to images array
            //array that will determine which image should have its source set

            images[0] = image1;
            images[1] = image2;
            images[2] = image3;
            images[3] = image4;
            images[4] = image5;
            images[5] = image6;
            images[6] = image7;
            images[7] = image8;
            images[8] = image9;
            images[9] = image10;
            images[10] = image11;
            images[11] = image12;
            images[12] = image13;
            images[13] = image14;
            images[14] = image15;
            images[15] = image16;
            images[16] = image17;
            images[17] = image18;
            images[18] = image19;
            images[19] = image20;
            images[20] = image21;
            images[21] = image22;
            images[22] = image23;
            images[23] = image24;
            images[24] = image25;
            images[25] = image26;
            images[26] = image27;
            images[27] = image28;
            images[28] = image29;
            images[29] = image30;
            images[30] = image31;
            images[31] = image32;
            images[32] = image33;
            images[33] = image34;
            images[34] = image35;
            images[35] = image36;
            images[36] = image37;
            images[37] = image38;
            images[38] = image39;
            images[39] = image40;
            images[40] = image41;
            images[41] = image42;
            images[42] = image43;
            images[43] = image44;
            images[44] = image45;
            images[45] = image46;
            images[46] = image47;
            images[47] = image48;
            images[48] = image49;
            images[49] = image50;
            images[50] = image51;
            images[51] = image52;
           
#endregion

            instructionDateTime = instructionDateTime.AddSeconds(8);
            instructionsDispatcher.Interval = TimeSpan.FromSeconds(1);
            instructionsDispatcher.Tick += instructionsDispatcher_Tick;
            instructionsDispatcher.Start();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);

            dispatcherTimerBreak.Interval = TimeSpan.FromSeconds(1);

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
            if (instructionDateTime.Second == 1)
            {
                stryInstruction.Begin();
            }

            if (instructionDateTime.Second == 0)
            {
                instructionsDispatcher.Stop();
                instructionsDispatcher.Tick -= instructionsDispatcher_Tick;
                CreateCards(initialNumberOfCards);
            }
            else
            {
                instructionDateTime = instructionDateTime.AddSeconds(-1);
                tbkInstructions.FontSize = Frame.ActualHeight / 40;
            }
        }

        private void CreateCards(int numberOfCards)
        {
            cardsToDisplays = new int[numberOfCards];       //array holding numbers that represent cards
            controlRandomNumber = new int[numberOfCards];


            for (int i = 0; i < cardsToDisplays.Length; i++)       // we assign random numbers (representing cards) to sequential index in the array. i is sequential index , randomNunber is the number represnting the card
            {
                bool randomNumberAlreadyAppeared = false;
                Random random = new Random();
                int randomNumber = random.Next(1,53);       //1 is the S1 , 52 is C13

                //we need to control the values of randomNumber
                for (int a = 0; a < controlRandomNumber.Length; a++)
                {
                    if (controlRandomNumber[a] == randomNumber)
                    {
                        randomNumberAlreadyAppeared = true;
                        break;
                    }
                }

                if (randomNumberAlreadyAppeared)
                {
                    i--;
                    continue;
                }
              
                cardsToDisplays[i] = randomNumber;
                controlRandomNumber[i] = randomNumber;
            }

            for (int i = 0; i < cardsToDisplays.Length; i++)        //we display the cards according to their corresponding numbers, in sequential index order. Meanwhile, we set each 
                                                                    //card's corresponding string in list_orderOfCardsShown
            {
                #region switch statement for cardsToDisplays[i]
                switch (cardsToDisplays[i])
                {
                    case 1:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S1.png"));
                        list_orderOfCardsShown.Add("S1");
                        break;
                    case 2: 
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S2.png"));
                        list_orderOfCardsShown.Add("S2");
                        break;
                    case 3: 
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S3.png"));
                        list_orderOfCardsShown.Add("S3");
                        break;
                    case 4:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S4.png"));
                        list_orderOfCardsShown.Add("S4");
                        break;
                    case 5:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S5.png"));
                        list_orderOfCardsShown.Add("S5");
                        break;
                    case 6:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S6.png"));
                        list_orderOfCardsShown.Add("S6");
                        break;
                    case 7:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S7.png"));
                        list_orderOfCardsShown.Add("S7");
                        break;
                    case 8:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S8.png"));
                        list_orderOfCardsShown.Add("S8");
                        break;
                    case 9:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S9.png"));
                        list_orderOfCardsShown.Add("S9");
                        break;
                    case 10:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S10.png"));
                        list_orderOfCardsShown.Add("S10");
                        break;
                    case 11:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S11.png"));
                        list_orderOfCardsShown.Add("S11");
                        break;
                    case 12:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S12.png"));
                        list_orderOfCardsShown.Add("S12");
                        break;
                    case 13:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Spades/S13.png"));
                        list_orderOfCardsShown.Add("S13");
                        break;


                    case 14:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H1.png"));
                        list_orderOfCardsShown.Add("H1");
                        break;
                    case 15:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H2.png"));
                        list_orderOfCardsShown.Add("H2");
                        break;
                    case 16:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H3.png"));
                        list_orderOfCardsShown.Add("H3");
                        break;
                    case 17:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H4.png"));
                        list_orderOfCardsShown.Add("H4");
                        break;
                    case 18:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H5.png"));
                        list_orderOfCardsShown.Add("H5");
                        break;
                    case 19:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H6.png"));
                        list_orderOfCardsShown.Add("H6");
                        break;
                    case 20:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H7.png"));
                        list_orderOfCardsShown.Add("H7");
                        break;
                    case 21:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H8.png"));
                        list_orderOfCardsShown.Add("H8");
                        break;
                    case 22:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H9.png"));
                        list_orderOfCardsShown.Add("H9");
                        break;
                    case 23:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H10.png"));
                        list_orderOfCardsShown.Add("H10");
                        break;
                    case 24:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H11.png"));
                        list_orderOfCardsShown.Add("H11");
                        break;
                    case 25:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H12.png"));
                        list_orderOfCardsShown.Add("H12");
                        break;
                    case 26:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Hearts/H13.png"));
                        list_orderOfCardsShown.Add("H13");
                        break;


                    case 27:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D1.png"));
                        list_orderOfCardsShown.Add("D1");
                        break;
                    case 28:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D2.png"));
                        list_orderOfCardsShown.Add("D2");
                        break;
                    case 29:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D3.png"));
                        list_orderOfCardsShown.Add("D3");
                        break;
                    case 30:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D4.png"));
                        list_orderOfCardsShown.Add("D4");
                        break;
                    case 31:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D5.png"));
                        list_orderOfCardsShown.Add("D5");
                        break;
                    case 32:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D6.png"));
                        list_orderOfCardsShown.Add("D6");
                        break;
                    case 33:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D7.png"));
                        list_orderOfCardsShown.Add("D7");
                        break;
                    case 34:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D8.png"));
                        list_orderOfCardsShown.Add("D8");
                        break;
                    case 35:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D9.png"));
                        list_orderOfCardsShown.Add("D9");
                        break;
                    case 36:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D10.png"));
                        list_orderOfCardsShown.Add("D10");
                        break;
                    case 37:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D11.png"));
                        list_orderOfCardsShown.Add("D11");
                        break;
                    case 38:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D12.png"));
                        list_orderOfCardsShown.Add("D12");
                        break;
                    case 39:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Diamonds/D13.png"));
                        list_orderOfCardsShown.Add("D13");
                        break;



                    case 40:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C1.png"));
                        list_orderOfCardsShown.Add("C1");
                        break;
                    case 41:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C2.png"));
                        list_orderOfCardsShown.Add("C2");
                        break;
                    case 42:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C3.png"));
                        list_orderOfCardsShown.Add("C3");
                        break;
                    case 43:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C4.png"));
                        list_orderOfCardsShown.Add("C4");
                        break;
                    case 44:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C5.png"));
                        list_orderOfCardsShown.Add("C5");
                        break;
                    case 45:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C6.png"));
                        list_orderOfCardsShown.Add("C6");
                        break;
                    case 46:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C7.png"));
                        list_orderOfCardsShown.Add("C7");
                        break;
                    case 47:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C8.png"));
                        list_orderOfCardsShown.Add("C8");
                        break;
                    case 48:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C9.png"));
                        list_orderOfCardsShown.Add("C9");
                        break;
                    case 49:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C10.png"));
                        list_orderOfCardsShown.Add("C10");
                        break;
                    case 50:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C11.png"));
                        list_orderOfCardsShown.Add("C11");
                        break;
                    case 51:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C12.png"));
                        list_orderOfCardsShown.Add("C12");
                        break;
                    case 52:
                        images[i].Source = new BitmapImage(new Uri(this.BaseUri, "Assets/Clubs/C13.png"));
                        list_orderOfCardsShown.Add("C13");
                        break;

                    default:
                        throw new ArgumentException("cardsToDisplays doesn't contain a case to satisfy the cardsToDisplays[i]'s demand");

                }

                #endregion
            }

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dateTime = dateTime.AddSeconds(initialNumberOfCards * 10);
            dispatcherTimer.Start();

        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 0 && dateTime.Minute == 0)
            {
                tbkTimeRemaining.Opacity = 0;
                tbkTimeRemaining_Minutes.Opacity = 0;
                tbkTimeRemaining_Seconds.Opacity = 0;

                dispatcherTimer.Stop();
                dispatcherTimer.Tick -= dispatcherTimer_Tick;

                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Visible;
                scrollviewer_imagesdisplay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                scrollviewer_answer.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Visible;
                tbkTimeRemaining.Opacity = 1;
                tbkTimeRemaining.Text = "Time Remaining";
                tbkTimeRemaining_Minutes.Text = dateTime.ToString("mm");
                tbkTimeRemaining_Seconds.Text = dateTime.ToString("ss");
                dateTime = dateTime.AddSeconds(-1);
            }
        }


        #region spades
        private void image_S1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk1, image_S1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S1");
            i.MainOperation();
        }

        private void tbk1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk1, image_S1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S1");
            i.MainOperation();
        }


        private void image_S2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk2, image_S2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S2");
            i.MainOperation();
        }

        private void tbk2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk2, image_S2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S2");
            i.MainOperation();
        }

        private void image_S3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk3, image_S3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S3");
            i.MainOperation();
        }

        private void tbk3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk3, image_S3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S3");
            i.MainOperation();
        }

        private void image_S4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk4, image_S4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S4");
            i.MainOperation();
        }

        private void tbk4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk4, image_S4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S4");
            i.MainOperation();
        }

        private void image_S5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk5, image_S5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S5");
            i.MainOperation();
        }

        private void tbk5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk5, image_S5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S5");
            i.MainOperation();
        }

        private void image_S6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk6, image_S6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S6");
            i.MainOperation();
        }

        private void tbk6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk6, image_S6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S6");
            i.MainOperation();
        }

        private void image_S7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk7, image_S7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S7");
            i.MainOperation();
        }

        private void tbk7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk7, image_S7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S7");
            i.MainOperation();
        }

        private void image_S8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk8, image_S8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S8");
            i.MainOperation();
        }

        private void tbk8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk8, image_S8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S8");
            i.MainOperation();
        }

        private void image_S9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk9, image_S9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S9");
            i.MainOperation();
        }

        private void tbk9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk9, image_S9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S9");
            i.MainOperation();
        }

        private void image_S10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk10, image_S10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S10");
            i.MainOperation();
        }

        private void tbk10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk10, image_S10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S10");
            i.MainOperation();
        }

        private void image_S11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk11, image_S11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S11");
            i.MainOperation();
        }

        private void tbk11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk11, image_S11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S11");
            i.MainOperation();
        }

        private void image_S12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk12, image_S12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S12");
            i.MainOperation();
        }

        private void tbk12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk12, image_S12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S12");
            i.MainOperation();
        }

        private void image_S13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk13, image_S13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S13");
            i.MainOperation();
        }

        private void tbk13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbk13, image_S13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S13");
            i.MainOperation();
        }
        #endregion

        #region hearts
        private void image_H1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH1, image_H1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H1");
            i.MainOperation();
        }

        private void tbkH1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH1, image_H1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H1");
            i.MainOperation();
        }


        private void image_H2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH2, image_H2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H2");
            i.MainOperation();
        }

        private void tbkH2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH2, image_H2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H2");
            i.MainOperation();
        }

        private void image_H3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH3, image_H3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H3");
            i.MainOperation();
        }

        private void tbkH3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH3, image_H3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H3");
            i.MainOperation();
        }

        private void image_H4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH4, image_H4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H4");
            i.MainOperation();
        }

        private void tbkH4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH4, image_H4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H4");
            i.MainOperation();
        }

        private void image_H5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH5, image_H5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H5");
            i.MainOperation();
        }

        private void tbkH5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH5, image_H5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H5");
            i.MainOperation();
        }

        private void image_H6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH6, image_H6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H6");
            i.MainOperation();
        }

        private void tbkH6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH6, image_H6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H6");
            i.MainOperation();
        }

        private void image_H7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH7, image_H7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H7");
            i.MainOperation();
        }

        private void tbkH7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH7, image_H7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H7");
            i.MainOperation();
        }

        private void image_H8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH8, image_H8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H8");
            i.MainOperation();
        }

        private void tbkH8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH8, image_H8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H8");
            i.MainOperation();
        }

        private void image_H9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH9, image_H9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H9");
            i.MainOperation();
        }

        private void tbkH9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH9, image_H9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H9");
            i.MainOperation();
        }

        private void image_H10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH10, image_H10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H10");
            i.MainOperation();
        }

        private void tbkH10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH10, image_H10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H10");
            i.MainOperation();
        }

        private void image_H11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH11, image_H11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H11");
            i.MainOperation();
        }

        private void tbkH11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH11, image_H11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H11");
            i.MainOperation();
        }

        private void image_H12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH12, image_H12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H12");
            i.MainOperation();
        }

        private void tbkH12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH12, image_H12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H12");
            i.MainOperation();
        }

        private void image_H13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH13, image_H13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H13");
            i.MainOperation();
        }

        private void tbkH13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkH13, image_H13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H13");
            i.MainOperation();
        }
        #endregion

        #region clubs
        private void image_C1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC1, image_C1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C1");
            i.MainOperation();
        }

        private void tbkC1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC1, image_C1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C1");
            i.MainOperation();
        }


        private void image_C2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC2, image_C2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C2");
            i.MainOperation();
        }

        private void tbkC2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC2, image_C2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C2");
            i.MainOperation();
        }

        private void image_C3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC3, image_C3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C3");
            i.MainOperation();
        }

        private void tbkC3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC3, image_C3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C3");
            i.MainOperation();
        }

        private void image_C4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC4, image_C4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C4");
            i.MainOperation();
        }

        private void tbkC4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC4, image_C4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C4");
            i.MainOperation();
        }

        private void image_C5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC5, image_C5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C5");
            i.MainOperation();
        }

        private void tbkC5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC5, image_C5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C5");
            i.MainOperation();
        }

        private void image_C6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC6, image_C6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C6");
            i.MainOperation();
        }

        private void tbkC6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC6, image_C6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C6");
            i.MainOperation();
        }

        private void image_C7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC7, image_C7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C7");
            i.MainOperation();
        }

        private void tbkC7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC7, image_C7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C7");
            i.MainOperation();
        }

        private void image_C8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC8, image_C8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C8");
            i.MainOperation();
        }

        private void tbkC8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC8, image_C8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C8");
            i.MainOperation();
        }

        private void image_C9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC9, image_C9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C9");
            i.MainOperation();
        }

        private void tbkC9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC9, image_C9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C9");
            i.MainOperation();
        }

        private void image_C10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC10, image_C10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C10");
            i.MainOperation();
        }

        private void tbkC10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC10, image_C10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C10");
            i.MainOperation();
        }

        private void image_C11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC11, image_C11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C11");
            i.MainOperation();
        }

        private void tbkC11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC11, image_C11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C11");
            i.MainOperation();
        }

        private void image_C12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC12, image_C12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C12");
            i.MainOperation();
        }

        private void tbkC12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC12, image_C12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C12");
            i.MainOperation();
        }

        private void image_C13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC13, image_C13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C13");
            i.MainOperation();
        }

        private void tbkC13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkC13, image_C13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C13");
            i.MainOperation();
        }
        #endregion

        #region diamonds
        private void image_D1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD1, image_D1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D1");
            i.MainOperation();
        }

        private void tbkD1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD1, image_D1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D1");
            i.MainOperation();
        }


        private void image_D2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD2, image_D2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D2");
            i.MainOperation();
        }

        private void tbkD2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD2, image_D2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D2");
            i.MainOperation();
        }

        private void image_D3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD3, image_D3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D3");
            i.MainOperation();
        }

        private void tbkD3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD3, image_D3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D3");
            i.MainOperation();
        }

        private void image_D4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD4, image_D4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D4");
            i.MainOperation();
        }

        private void tbkD4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD4, image_D4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D4");
            i.MainOperation();
        }

        private void image_D5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD5, image_D5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D5");
            i.MainOperation();
        }

        private void tbkD5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD5, image_D5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D5");
            i.MainOperation();
        }

        private void image_D6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD6, image_D6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D6");
            i.MainOperation();
        }

        private void tbkD6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD6, image_D6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D6");
            i.MainOperation();
        }

        private void image_D7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD7, image_D7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D7");
            i.MainOperation();
        }

        private void tbkD7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD7, image_D7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D7");
            i.MainOperation();
        }

        private void image_D8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD8, image_D8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D8");
            i.MainOperation();
        }

        private void tbkD8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD8, image_D8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D8");
            i.MainOperation();
        }

        private void image_D9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD9, image_D9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D9");
            i.MainOperation();
        }

        private void tbkD9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD9, image_D9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D9");
            i.MainOperation();
        }

        private void image_D10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD10, image_D10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D10");
            i.MainOperation();
        }

        private void tbkD10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD10, image_D10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D10");
            i.MainOperation();
        }

        private void image_D11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD11, image_D11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D11");
            i.MainOperation();
        }

        private void tbkD11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD11, image_D11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D11");
            i.MainOperation();
        }

        private void image_D12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD12, image_D12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D12");
            i.MainOperation();
        }

        private void tbkD12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD12, image_D12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D12");
            i.MainOperation();
        }

        private void image_D13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD13, image_D13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D13");
            i.MainOperation();
        }

        private void tbkD13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressedT i = new ImagePressedT(tbkD13, image_D13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D13");
            i.MainOperation();
        }


        #endregion


        private void btnAnswerNow_Click(object sender, RoutedEventArgs e)
        {
            dateTime = DateTime.MinValue;

            tbkNumberOfCardsRemaining.Opacity = 1;
            btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Visible;
            scrollviewer_imagesdisplay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            scrollviewer_answer.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }


        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            tbkNumberOfCardsRemaining.Opacity = 0;
            btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            if (captionOn)
            {
                tbkAnalysis.Opacity = 1;
            }
            else
            {
                tbkAnalysis.Opacity = 0;
            }
            if (numberOfWrongAnswer == 2)
            {
                int indexToPlaceUserScore = -1;
                int[] secondArrayToMakeLifeEasier = new int[5];

                Array.Copy(highScores, secondArrayToMakeLifeEasier, 5);

                //find where to place the score
                for (int i = 0; i < 5; i++)
                {
                    if (initialNumberOfCards - 1 > highScores[i])
                    {
                        indexToPlaceUserScore = i;
                        break;
                    }
                }

                if (indexToPlaceUserScore != -1)
                {
                    secondArrayToMakeLifeEasier[indexToPlaceUserScore] = (initialNumberOfCards - 1);

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
                applicationDataContainer.Values["HighScore1_Card"] = highScores[0];
                applicationDataContainer.Values["HighScore2_Card"] = highScores[1];
                applicationDataContainer.Values["HighScore3_Card"] = highScores[2];
                applicationDataContainer.Values["HighScore4_Card"] = highScores[3];
                applicationDataContainer.Values["HighScore5_Card"] = highScores[4];

                tbkAnalysis.Opacity = 1;

                tbkAnalysis.Text = "The test is now finished. \n Maximum number of cards memorized: " + (initialNumberOfCards - 1).ToString();
                btnAnswer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                bool addOneMoreUnit = true;
                tbkAnalysis.Text = "";

                for (int i = 0; i < list_orderOfCardsPressed.Count; i++)               //we base this for loop on the number of cards user pressed
                {
                    if (list_orderOfCardsPressed[i] == list_orderOfCardsShown[i])
                    {
                        tbkAnalysis.Text += "\nCard " + (i + 1).ToString() + ": Correct";
                        list_textBlocks[i].Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        tbkAnalysis.Text += "\nCard " + (i + 1).ToString() + ": Incorrect";
                        list_textBlocks[i].Foreground = new SolidColorBrush(Colors.Red);
                        addOneMoreUnit = false;
                    }
                }

                //if the user pressed a fewer number of cards than was shown, the check_tbkCheck writes "Missed"
                for (int i = list_orderOfCardsPressed.Count; i < list_orderOfCardsShown.Count; i++)
                {
                    tbkAnalysis.Text += "\nCard " + (i + 1).ToString() + ": Missed";
                    addOneMoreUnit = false;
                }


                if (addOneMoreUnit)
                {
                    initialNumberOfCards++;
                    numberOfWrongAnswer = 0;
                }
                else
                {
                    numberOfWrongAnswer++;
                }

                if (numberOfWrongAnswer == 2)
                {
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(btnAnswer);
                    peer.Invoke();
                }
                else
                {
                    dateTimeBreak = dateTimeBreak.AddSeconds(4);
                    dispatcherTimerBreak.Tick += dispatcherTimerBreak_Tick;
                    dispatcherTimerBreak.Start();
                }

            }
        }

        void dispatcherTimerBreak_Tick(object sender, object e)
        {
            if (dateTimeBreak.Second == 0)
            {
                dispatcherTimerBreak.Stop();
                dispatcherTimerBreak.Tick -= dispatcherTimerBreak_Tick;

                //when break time is over, scrollviewer for answer collapses and scrollviewer for display appears. We also reset the list of cards shown
                scrollviewer_answer.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                scrollviewer_imagesdisplay.Visibility = Windows.UI.Xaml.Visibility.Visible;

              
                list_orderOfCardsPressed.Clear();
                list_orderOfCardsShown.Clear();

                foreach (TextBlock a in list_textBlocks)
                {
                    a.Foreground = new SolidColorBrush(Colors.White);
                    a.Text = "";
                    a.Opacity = 0;
                }
                list_textBlocks.Clear();
                
                foreach (Image a in list_images)
                {
                    a.Opacity = 1;
                }
                list_images.Clear();
                pressedNumber = 0;

                btnAnswerNow.Visibility = Windows.UI.Xaml.Visibility.Visible;

                CreateCards(initialNumberOfCards);
            }
            else
            {
                dateTimeBreak = dateTimeBreak.AddSeconds(-1);

                tbkTimeRemaining.Opacity = 1;
                tbkTimeRemaining_Minutes.Opacity = 1;
                tbkTimeRemaining_Seconds.Opacity = 1;

                tbkTimeRemaining.Text = "Break Time Remaining";
                tbkTimeRemaining_Minutes.Text = dateTimeBreak.ToString("mm");
                tbkTimeRemaining_Seconds.Text = dateTimeBreak.ToString("ss");

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

        public static int PressedNumber
        {
            get { return pressedNumber; }
            set { pressedNumber = value; }
        }

        public static List<string> List_orderOfCardsShown
        {
            get { return list_orderOfCardsShown; }
        }
    }


    class ImagePressedT
    {
        TextBlock textBlock;
        Image image;

        List<Image> list_images2 = new List<Image>();
        List<TextBlock> list_textBlocks2 = new List<TextBlock>();

        int pNumber;
        TextBlock cardsRemaining;

        public ImagePressedT(TextBlock t, Image i, List<Image> list_i, List<TextBlock> list_t, int pressed, TextBlock cRemaining)
        {
            textBlock = t;
            image = i;
            list_images2 = list_i;
            list_textBlocks2 = list_t;
            pNumber = pressed;
            cardsRemaining = cRemaining;
        }

        public void MainOperation()
        {
            if (image.Opacity == 1)
            {
                if (Test_Cards.List_orderOfCardsShown.Count - pNumber == 0)          //if there are no more cards remaining, we do not add additional 
                //cards to list_cardsPressed
                {

                }
                else
                {
                    pNumber++;
                    Test_Cards.PressedNumber = pNumber;

                    image.Opacity = 0.4;
                    textBlock.Opacity = 1;
                    textBlock.Text = Test_Cards.PressedNumber.ToString();

                    list_images2.Add(image);
                    list_textBlocks2.Add(textBlock);
                }
            }
            else
            {
                //find position of current object in list_textBlocks2 and list_images
                int position = -1;
                for (int i = 0; i < list_textBlocks2.Count; i++)
                {
                    if (list_textBlocks2[i] == textBlock)
                    {
                        position = i;
                        break;
                    }
                }

                //changes text of other rectangles and removes their textblocks from list 
                int originalTextBlocksCount = list_textBlocks2.Count;
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_textBlocks2[i].Text = "";
                    pNumber--;
                    Test_Cards.PressedNumber = pNumber;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_textBlocks2.RemoveAt(position);
                }


                //image, changing opacity and removing from list
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_images2[i].Opacity = 1;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_images2.RemoveAt(position);
                }
            }

            cardsRemaining.Text = "Number of cards remaining: " + (Test_Cards.List_orderOfCardsShown.Count - pNumber).ToString();
        }

        public void AddTo_list_orderOfCardsPressed(List<string> list_cardsPressed, string correspondingString)
        {
            int position = -1;
            for (int i = 0; i < list_textBlocks2.Count; i++)
            {
                if (list_textBlocks2[i] == textBlock)
                {
                    position = i;
                    break;
                }
            }

            int originalCardsPressedCount = list_cardsPressed.Count;

            if (image.Opacity == 1)
            {
                if (Test_Cards.List_orderOfCardsShown.Count - pNumber == 0)          //if there are no more cards remaining, we do not add additional 
                //cards to list_cardsPressed
                {

                }
                else
                {
                    list_cardsPressed.Add(correspondingString);
                }
            }
            else
            {
                for (int i = position; i < originalCardsPressedCount; i++)
                {
                    list_cardsPressed.RemoveAt(position);
                }
            }
        }
    }

}
