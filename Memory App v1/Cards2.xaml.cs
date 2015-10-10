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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cards2 : Page
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); //keeps seconds for "Automatic Redos"
        DateTime dateTime = new DateTime();
        
        private static int toggle = 0;
        private static bool captionOn = false;

        static int setTimer_minute = -1;
        static int setTimer_second = -1;

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

        //if user has pressed the wrong sequence, , upon clicking btnCheck, the right sequence appears. we'll need an array of textblocks and itscorresponding string values,
        //which determines which textblock to user. The second array contains strings because Cards.List_orderOfCardsShown us composed of string values.

        TextBlock[] check_textBlocks = new TextBlock[52];
        string[] check_strings = new string[52];
        Image[] check_images = new Image[52];

        static int pressedNumber = 0;  //displays digit in textblock
        

        //these lists keep track of the order of textblocks, so we can unclick the textblocks behind one when that one is clicked
        List<TextBlock> list_textBlocks = new List<TextBlock>();
        List<Image> list_images = new List<Image>();
        List<Rectangle> bigRectangles = new List<Rectangle>();
        List<Rectangle> smallRectangles = new List<Rectangle>();

        //this list keeps the corresponding string of the cards pressed (in order) so that the order may later be validated
        List<string> list_orderOfCardsPressed = new List<string>();

        public Cards2()
        {
            this.InitializeComponent();

            //we set up the values in check_textBlocks (with textblocks) and check_strings (with strings)

            #region strings
            check_strings[0] = "S1";
            check_strings[1] = "S2";
            check_strings[2] = "S3";
            check_strings[3] = "S4";
            check_strings[4] = "S5";
            check_strings[5] = "S6";
            check_strings[6] = "S7";
            check_strings[7] = "S8";
            check_strings[8] = "S9";
            check_strings[9] = "S10";
            check_strings[10] = "S11";
            check_strings[11] = "S12";
            check_strings[12] = "S13";

            check_strings[13] = "H1";
            check_strings[14] = "H2";
            check_strings[15] = "H3";
            check_strings[16] = "H4";
            check_strings[17] = "H5";
            check_strings[18] = "H6";
            check_strings[19] = "H7";
            check_strings[20] = "H8";
            check_strings[21] = "H9";
            check_strings[22] = "H10";
            check_strings[23] = "H11";
            check_strings[24] = "H12";
            check_strings[25] = "H13";

            check_strings[26] = "C1";
            check_strings[27] = "C2";
            check_strings[28] = "C3";
            check_strings[29] = "C4";
            check_strings[30] = "C5";
            check_strings[31] = "C6";
            check_strings[32] = "C7";
            check_strings[33] = "C8";
            check_strings[34] = "C9";
            check_strings[35] = "C10";
            check_strings[36] = "C11";
            check_strings[37] = "C12";
            check_strings[38] = "C13";

            check_strings[39] = "D1";
            check_strings[40] = "D2";
            check_strings[41] = "D3";
            check_strings[42] = "D4";
            check_strings[43] = "D5";
            check_strings[44] = "D6";
            check_strings[45] = "D7";
            check_strings[46] = "D8";
            check_strings[47] = "D9";
            check_strings[48] = "D10";
            check_strings[49] = "D11";
            check_strings[50] = "D12";
            check_strings[51] = "D13";
            #endregion

            #region textblocks
            check_textBlocks[0] = tbk1;
            check_textBlocks[1] = tbk2;
            check_textBlocks[2] = tbk3;
            check_textBlocks[3] = tbk4;
            check_textBlocks[4] = tbk5;
            check_textBlocks[5] = tbk6;
            check_textBlocks[6] = tbk7;
            check_textBlocks[7] = tbk8;
            check_textBlocks[8] = tbk9;
            check_textBlocks[9] = tbk10;
            check_textBlocks[10] = tbk11;
            check_textBlocks[11] = tbk12;
            check_textBlocks[12] = tbk13;

            check_textBlocks[13] = tbkH1;
            check_textBlocks[14] = tbkH2;
            check_textBlocks[15] = tbkH3;
            check_textBlocks[16] = tbkH4;
            check_textBlocks[17] = tbkH5;
            check_textBlocks[18] = tbkH6;
            check_textBlocks[19] = tbkH7;
            check_textBlocks[20] = tbkH8;
            check_textBlocks[21] = tbkH9;
            check_textBlocks[22] = tbkH10;
            check_textBlocks[23] = tbkH11;
            check_textBlocks[24] = tbkH12;
            check_textBlocks[25] = tbkH13;

            check_textBlocks[26] = tbkC1;
            check_textBlocks[27] = tbkC2;
            check_textBlocks[28] = tbkC3;
            check_textBlocks[29] = tbkC4;
            check_textBlocks[30] = tbkC5;
            check_textBlocks[31] = tbkC6;
            check_textBlocks[32] = tbkC7;
            check_textBlocks[33] = tbkC8;
            check_textBlocks[34] = tbkC9;
            check_textBlocks[35] = tbkC10;
            check_textBlocks[36] = tbkC11;
            check_textBlocks[37] = tbkC12;
            check_textBlocks[38] = tbkC13;


            check_textBlocks[39] = tbkD1;
            check_textBlocks[40] = tbkD2;
            check_textBlocks[41] = tbkD3;
            check_textBlocks[42] = tbkD4;
            check_textBlocks[43] = tbkD5;
            check_textBlocks[44] = tbkD6;
            check_textBlocks[45] = tbkD7;
            check_textBlocks[46] = tbkD8;
            check_textBlocks[47] = tbkD9;
            check_textBlocks[48] = tbkD10;
            check_textBlocks[49] = tbkD11;
            check_textBlocks[50] = tbkD12;
            check_textBlocks[51] = tbkD13; 

            #endregion

            check_images[0] = image_S1;
            check_images[1] = image_S2;
            check_images[2] = image_S3;
            check_images[3] = image_S4;
            check_images[4] = image_S5;
            check_images[5] = image_S6;
            check_images[6] = image_S7;
            check_images[7] = image_S8;
            check_images[8] = image_S9;
            check_images[9] = image_S10;
            check_images[10] = image_S11;
            check_images[11] = image_S12;
            check_images[12] = image_S13;

            check_images[13] = image_H1;
            check_images[14] = image_H2;
            check_images[15] = image_H3;
            check_images[16] = image_H4;
            check_images[17] = image_H5;
            check_images[18] = image_H6;
            check_images[19] = image_H7;
            check_images[20] = image_H8;
            check_images[21] = image_H9;
            check_images[22] = image_H10;
            check_images[23] = image_H11;
            check_images[24] = image_H12;
            check_images[25] = image_H13;

            check_images[26] = image_C1;
            check_images[27] = image_C2;
            check_images[28] = image_C3;
            check_images[29] = image_C4;
            check_images[30] = image_C5;
            check_images[31] = image_C6;
            check_images[32] = image_C7;
            check_images[33] = image_C8;
            check_images[34] = image_C9;
            check_images[35] = image_C10;
            check_images[36] = image_C11;
            check_images[37] = image_C12;
            check_images[38] = image_C13;

            check_images[39] = image_D1;
            check_images[40] = image_D2;
            check_images[41] = image_D3;
            check_images[42] = image_D4;
            check_images[43] = image_D5;
            check_images[44] = image_D6;
            check_images[45] = image_D7;
            check_images[46] = image_D8;
            check_images[47] = image_D9;
            check_images[48] = image_D10;
            check_images[49] = image_D11;
            check_images[50] = image_D12;
            check_images[51] = image_D13;



            toggle = Cards.Toggle;
            captionOn = Cards.CaptionOn;

            setTimer_minute = Cards.SetTime_minute;
            setTimer_second = Cards.SetTime_second;

            switch (toggle)
            {
                case 1:
                    commandbar_options_toggle1.IsChecked = true;
                    appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case 2:
                    commandbar_options_toggle2.IsChecked = true;
                    appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case 3:
                    commandbar_options_toggle3.IsChecked = true;
                    appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case 4:
                    commandbar_options_toggle4.IsChecked = true;
                    appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                default:
                    commandbar_options_toggle1.IsChecked = false;
                    commandbar_options_toggle2.IsChecked = false;
                    commandbar_options_toggle3.IsChecked = false;
                    commandbar_options_toggle4.IsChecked = false;
                    appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.White);
                    break;
            }

            switch (captionOn)
            {
                case true:
                    appbarbuttonCaption.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case false:
                    appbarbuttonCaption.Foreground = new SolidColorBrush(Colors.White);
                    break;
            }


            tbkNumberOfCardsRemaining.Text = "Number of cards remaining: " + Cards.List_orderOfCardsShown.Count.ToString();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
        }

        public static int PressedNumber
        {
            get { return pressedNumber; }
            set { pressedNumber = value; }
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (dateTime.Second == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.Tick -= dispatcherTimer_Tick;
                list_orderOfCardsPressed.Clear();
                list_textBlocks.Clear();
                list_images.Clear();
                pressedNumber = 0;
                Frame.Navigate(typeof(Cards));
                Cards.Toggle = toggle;
                Cards.SetTime_minute = setTimer_minute;
                Cards.SetTime_second = setTimer_second;
            }
            else
            {
                dateTime = dateTime.AddSeconds(-1);
            }
        }

        private void check_btnCheck_Click(object sender, RoutedEventArgs e)
        {
            check_tbkCheck.Text = "";
            check_tbkCheck.FontSize = Frame.ActualHeight / 50;
            if (captionOn)
            {
                check_tbkCheck.Opacity = 1;
            }
            else
            {
                check_tbkCheck.Opacity = 0;
            }

            for (int i = 0; i < list_orderOfCardsPressed.Count; i ++)               //we base this for loop on the number of cards user pressed
            {
                if (list_orderOfCardsPressed[i] == Cards.List_orderOfCardsShown[i])
                {
                    check_tbkCheck.Text += "\nCard " + (i+1).ToString() + ": Correct";
                    list_textBlocks[i].Foreground = new SolidColorBrush(Colors.LawnGreen);
                }
                else
                {
                  //  bool red = true;        //if the textblock should stay as red or blue

                    check_tbkCheck.Text += "\nCard " + (i + 1).ToString() + ": Incorrect || Correct Answer: " + Cards.List_orderOfCardsShown[i];

                  //  if (list_textBlocks[i].Opacity != 0.99 || (list_textBlocks[i].Opacity > 98 && list_textBlocks[i].Opacity < 100))
                    list_textBlocks[i].Foreground = new SolidColorBrush(Colors.Red);
                    

                    //show the correct card
                    //for (int a = 0; a < 52; a++)
                    //{
                    //    //if (check_strings[a] == Cards.List_orderOfCardsShown[i] && Brush.ReferenceEquals(list_textBlocks[i].Foreground, Colors.Red) == true)
                    //    //{
                    //    //    list_textBlocks[i].Foreground = new SolidColorBrush(Colors.Blue);
                    //    //    list_textBlocks[i].Text = (i + 1).ToString();
                    //    //}

                    //    if (check_strings[a] == Cards.List_orderOfCardsShown[i])
                    //    {
                    //        check_textBlocks[a].Foreground = new SolidColorBrush(Colors.Blue);

                    //        check_textBlocks[a].Text = (i + 1).ToString();
                    //        check_textBlocks[a].Opacity = 0.99;
                    //        check_images[a].Opacity = 0.5;
                    //        break;
                    //    }
                    //    }
                    }
               }
           
  

             //if the user pressed a fewer number of cards than was shown, the check_tbkCheck writes "Missed"
                for (int i = list_orderOfCardsPressed.Count; i < Cards.List_orderOfCardsShown.Count; i++)
                {
                    check_tbkCheck.Text += "\nCard " + (i + 1).ToString() + ": Missed || Correct Answer: " + Cards.List_orderOfCardsShown[i];

                    //for (int a = 0; a < 52; a++)
                    //{
                    //    if (check_strings[a] == Cards.List_orderOfCardsShown[i])
                    //    {
                    //        check_textBlocks[a].Foreground = new SolidColorBrush(Colors.Blue);
                    //        check_textBlocks[a].Text = (i + 1).ToString();
                    //        check_textBlocks[a].Opacity = 1;
                    //        check_images[a].Opacity = 0.5;
                    //        break;
                    //    }
                    //}
                }

            if (commandbar_options_toggle1.IsChecked)
            {
                dateTime = dateTime.AddSeconds(1);
                dispatcherTimer.Start();
            }

            if (commandbar_options_toggle2.IsChecked)
            {
                dateTime = dateTime.AddSeconds(5);
                dispatcherTimer.Start();
            }

            if (commandbar_options_toggle3.IsChecked)
            {
                dateTime = dateTime.AddSeconds(10);
                dispatcherTimer.Start();
            }

            if (commandbar_options_toggle4.IsChecked)
            {
                dateTime = dateTime.AddSeconds(20);
                dispatcherTimer.Start();
            }


        }

        #region spades
        private void image_S1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           ImagePressed i = new ImagePressed(tbk1, image_S1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
           i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S1");
           i.MainOperation();
        }

        private void tbk1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk1, image_S1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S1");
            i.MainOperation();
        }


        private void image_S2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk2, image_S2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);  
           i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S2");
           i.MainOperation();
        }

        private void tbk2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk2, image_S2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S2");
            i.MainOperation();
        }

        private void image_S3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk3, image_S3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);  
           i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S3");
           i.MainOperation();
        }

        private void tbk3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk3, image_S3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S3");
            i.MainOperation();
        }

        private void image_S4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk4, image_S4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S4");
            i.MainOperation();
        }

        private void tbk4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk4, image_S4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S4");
            i.MainOperation();
        }

        private void image_S5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk5, image_S5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S5");
            i.MainOperation();
        }

        private void tbk5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk5, image_S5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S5");
            i.MainOperation();
        }

        private void image_S6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk6, image_S6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S6");
            i.MainOperation();
        }

        private void tbk6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk6, image_S6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S6");
            i.MainOperation();
        }

        private void image_S7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk7, image_S7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S7");
            i.MainOperation();
        }

        private void tbk7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk7, image_S7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S7");
            i.MainOperation();
        }

        private void image_S8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk8, image_S8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S8");
            i.MainOperation();
        }

        private void tbk8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk8, image_S8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S8");
            i.MainOperation();
        }

        private void image_S9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk9, image_S9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S9");
            i.MainOperation();
        }

        private void tbk9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk9, image_S9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S9");
            i.MainOperation();
        }

        private void image_S10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk10, image_S10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S10");
            i.MainOperation();
        }

        private void tbk10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk10, image_S10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S10");
            i.MainOperation();
        }

        private void image_S11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk11, image_S11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S11");
            i.MainOperation();
        }

        private void tbk11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk11, image_S11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S11");
            i.MainOperation();
        }

        private void image_S12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk12, image_S12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S12");
            i.MainOperation();
        }

        private void tbk12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk12, image_S12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S12");
            i.MainOperation();
        }

        private void image_S13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk13, image_S13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S13");
            i.MainOperation();
        }

        private void tbk13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbk13, image_S13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S13");
            i.MainOperation();
        }
#endregion

        #region hearts
        private void image_H1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH1, image_H1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H1");
            i.MainOperation();
        }

        private void tbkH1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH1, image_H1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H1");
            i.MainOperation();
        }


        private void image_H2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH2, image_H2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H2");
            i.MainOperation();
        }

        private void tbkH2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH2, image_H2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H2");
            i.MainOperation();
        }

        private void image_H3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH3, image_H3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H3");
            i.MainOperation();
        }

        private void tbkH3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH3, image_H3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H3");
            i.MainOperation();
        }

        private void image_H4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH4, image_H4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H4");
            i.MainOperation();
        }

        private void tbkH4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH4, image_H4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H4");
            i.MainOperation();
        }

        private void image_H5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH5, image_H5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H5");
            i.MainOperation();
        }

        private void tbkH5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH5, image_H5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H5");
            i.MainOperation();
        }

        private void image_H6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH6, image_H6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H6");
            i.MainOperation();
        }

        private void tbkH6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH6, image_H6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H6");
            i.MainOperation();
        }

        private void image_H7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH7, image_H7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H7");
            i.MainOperation();
        }

        private void tbkH7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH7, image_H7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H7");
            i.MainOperation();
        }

        private void image_H8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH8, image_H8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H8");
            i.MainOperation();
        }

        private void tbkH8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH8, image_H8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H8");
            i.MainOperation();
        }

        private void image_H9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH9, image_H9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H9");
            i.MainOperation();
        }

        private void tbkH9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH9, image_H9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H9");
            i.MainOperation();
        }

        private void image_H10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH10, image_H10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H10");
            i.MainOperation();
        }

        private void tbkH10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH10, image_H10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H10");
            i.MainOperation();
        }

        private void image_H11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH11, image_H11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H11");
            i.MainOperation();
        }

        private void tbkH11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH11, image_H11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H11");
            i.MainOperation();
        }

        private void image_H12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH12, image_H12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H12");
            i.MainOperation();
        }

        private void tbkH12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH12, image_H12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H12");
            i.MainOperation();
        }

        private void image_H13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH13, image_H13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H13");
            i.MainOperation();
        }

        private void tbkH13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkH13, image_H13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H13");
            i.MainOperation();
        }
#endregion

        #region clubs
        private void image_C1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC1, image_C1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C1");
            i.MainOperation();
        }

        private void tbkC1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC1, image_C1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C1");
            i.MainOperation();
        }


        private void image_C2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC2, image_C2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C2");
            i.MainOperation();
        }

        private void tbkC2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC2, image_C2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C2");
            i.MainOperation();
        }

        private void image_C3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC3, image_C3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C3");
            i.MainOperation();
        }

        private void tbkC3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC3, image_C3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C3");
            i.MainOperation();
        }

        private void image_C4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC4, image_C4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C4");
            i.MainOperation();
        }

        private void tbkC4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC4, image_C4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C4");
            i.MainOperation();
        }

        private void image_C5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC5, image_C5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C5");
            i.MainOperation();
        }

        private void tbkC5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC5, image_C5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C5");
            i.MainOperation();
        }

        private void image_C6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC6, image_C6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C6");
            i.MainOperation();
        }

        private void tbkC6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC6, image_C6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C6");
            i.MainOperation();
        }

        private void image_C7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC7, image_C7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C7");
            i.MainOperation();
        }

        private void tbkC7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC7, image_C7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C7");
            i.MainOperation();
        }

        private void image_C8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC8, image_C8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C8");
            i.MainOperation();
        }

        private void tbkC8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC8, image_C8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C8");
            i.MainOperation();
        }

        private void image_C9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC9, image_C9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C9");
            i.MainOperation();
        }

        private void tbkC9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC9, image_C9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C9");
            i.MainOperation();
        }

        private void image_C10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC10, image_C10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C10");
            i.MainOperation();
        }

        private void tbkC10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC10, image_C10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C10");
            i.MainOperation();
        }

        private void image_C11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC11, image_C11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C11");
            i.MainOperation();
        }

        private void tbkC11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC11, image_C11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C11");
            i.MainOperation();
        }

        private void image_C12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC12, image_C12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C12");
            i.MainOperation();
        }

        private void tbkC12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC12, image_C12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C12");
            i.MainOperation();
        }

        private void image_C13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC13, image_C13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C13");
            i.MainOperation();
        }

        private void tbkC13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkC13, image_C13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C13");
            i.MainOperation();
        }
#endregion

        #region diamonds
        private void image_D1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD1, image_D1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D1");
            i.MainOperation();
        }

        private void tbkD1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD1, image_D1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D1");
            i.MainOperation();
        }


        private void image_D2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD2, image_D2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D2");
            i.MainOperation();
        }

        private void tbkD2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD2, image_D2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D2");
            i.MainOperation();
        }

        private void image_D3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD3, image_D3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D3");
            i.MainOperation();
        }

        private void tbkD3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD3, image_D3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D3");
            i.MainOperation();
        }

        private void image_D4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD4, image_D4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D4");
            i.MainOperation();
        }

        private void tbkD4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD4, image_D4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D4");
            i.MainOperation();
        }

        private void image_D5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD5, image_D5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D5");
            i.MainOperation();
        }

        private void tbkD5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD5, image_D5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D5");
            i.MainOperation();
        }

        private void image_D6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD6, image_D6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D6");
            i.MainOperation();
        }

        private void tbkD6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD6, image_D6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D6");
            i.MainOperation();
        }

        private void image_D7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD7, image_D7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D7");
            i.MainOperation();
        }

        private void tbkD7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD7, image_D7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D7");
            i.MainOperation();
        }

        private void image_D8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD8, image_D8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D8");
            i.MainOperation();
        }

        private void tbkD8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD8, image_D8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D8");
            i.MainOperation();
        }

        private void image_D9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD9, image_D9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D9");
            i.MainOperation();
        }

        private void tbkD9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD9, image_D9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D9");
            i.MainOperation();
        }

        private void image_D10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD10, image_D10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D10");
            i.MainOperation();
        }

        private void tbkD10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD10, image_D10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D10");
            i.MainOperation();
        }

        private void image_D11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD11, image_D11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D11");
            i.MainOperation();
        }

        private void tbkD11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD11, image_D11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D11");
            i.MainOperation();
        }

        private void image_D12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD12, image_D12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D12");
            i.MainOperation();
        }

        private void tbkD12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD12, image_D12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D12");
            i.MainOperation();
        }

        private void image_D13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD13, image_D13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D13");
            i.MainOperation();
        }

        private void tbkD13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed i = new ImagePressed(tbkD13, image_D13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D13");
            i.MainOperation();
        }


        #endregion

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            list_orderOfCardsPressed.Clear();
            list_textBlocks.Clear();
            list_images.Clear();
            pressedNumber = 0;
            Frame.Navigate(typeof(Practice));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            list_orderOfCardsPressed.Clear();
            list_textBlocks.Clear();
            list_images.Clear();
            pressedNumber = 0;
            Frame.Navigate(typeof(MainPage));
        }

        private void appbarbuttonCaption_Click(object sender, RoutedEventArgs e)
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

        private void commandbar_options_toggle1_Click(object sender, RoutedEventArgs e)
        {
            if (commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle3.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                commandbar_options_toggle2.IsChecked = false;
                commandbar_options_toggle3.IsChecked = false;
                commandbar_options_toggle4.IsChecked = false;
            }

            if (commandbar_options_toggle1.IsChecked == true)
            {
                toggle = 1;
            }
            else
            {
                toggle = 0;
            }


            if (commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle3.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.White);
            }

        }

        private void commandbar_options_toggle2_Click(object sender, RoutedEventArgs e)
        {
            if (commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle3.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                commandbar_options_toggle1.IsChecked = false;
                commandbar_options_toggle3.IsChecked = false;
                commandbar_options_toggle4.IsChecked = false;
            }

            if (commandbar_options_toggle2.IsChecked == true)
            {
                toggle = 2;
            }
            else
            {
                toggle = 0;
            }

            if (commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle3.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void commandbar_options_toggle3_Click(object sender, RoutedEventArgs e)
        {
            if (commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                commandbar_options_toggle1.IsChecked = false;
                commandbar_options_toggle2.IsChecked = false;
                commandbar_options_toggle4.IsChecked = false;
            }

            if (commandbar_options_toggle3.IsChecked == true)
            {
                toggle = 3;
            }
            else
            {
                toggle = 0;
            }


            if (commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle3.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void commandbar_options_toggle4_Click(object sender, RoutedEventArgs e)
        {
            if (commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle3.IsChecked == true)
            {
                commandbar_options_toggle2.IsChecked = false;
                commandbar_options_toggle1.IsChecked = false;
                commandbar_options_toggle3.IsChecked = false; 
            }

            if (commandbar_options_toggle4.IsChecked == true)
            {
                toggle = 4;
            }
            else
            {
                toggle = 0;
            }


            if (commandbar_options_toggle1.IsChecked == true || commandbar_options_toggle2.IsChecked == true || commandbar_options_toggle3.IsChecked == true || commandbar_options_toggle4.IsChecked == true)
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                appbarbuttonRedoOptions.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            list_orderOfCardsPressed.Clear();
            list_textBlocks.Clear();
            list_images.Clear();
            pressedNumber = 0;
            Frame.Navigate(typeof(Cards));
            Cards.SetTime_minute = setTimer_minute;
            Cards.SetTime_second = setTimer_second;
        }

        public static int Toggle
        {
            get { return toggle; }
        }

        public static bool CaptionOn
        {
            get { return captionOn; }
        }
    }

    class ImagePressed 
    {
        TextBlock textBlock;
        Image image;

        List<Image> list_images2 = new List<Image>();
        List<TextBlock> list_textBlocks2 = new List<TextBlock>();

        int pNumber;
        TextBlock cardsRemaining;

        public ImagePressed(TextBlock t, Image i, List<Image> list_i, List<TextBlock> list_t,int pressed, TextBlock cRemaining)
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
                if (Cards.List_orderOfCardsShown.Count - pNumber == 0)          //if there are no more cards remaining, we do not add additional 
                                                                                //cards to list_cardsPressed
                {

                }
                else
                {
                    pNumber++;
                    Cards2.PressedNumber = pNumber;

                    image.Opacity = 0.4;
                    textBlock.Opacity = 1;
                    textBlock.Text = Cards2.PressedNumber.ToString();

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
                    Cards2.PressedNumber = pNumber;
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

            cardsRemaining.Text = "Number of cards remaining: " + (Cards.List_orderOfCardsShown.Count - pNumber).ToString();
        }

        public void AddTo_list_orderOfCardsPressed (List<string> list_cardsPressed, string correspondingString)
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
                if (Cards.List_orderOfCardsShown.Count - pNumber == 0)          //if there are no more cards remaining, we do not add additional 
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



  /*  class RectanglePressed
    {
        Rectangle bigRectangle;
        Rectangle smallRectangle;
        TextBlock textBlock;

        List<Rectangle> list_BigRectangles;
        List<Rectangle> list_SmallRectangles;
        List<TextBlock> list_TextBlocks;
        int pNumber;
      

        public RectanglePressed(Rectangle big, Rectangle small, TextBlock text,
            List<Rectangle> list_BigRects, List<Rectangle> list_SmallRects, List<TextBlock> list_Textblocks, int pressed)
        {
            bigRectangle = big;
            smallRectangle = small;
            textBlock = text;

            list_BigRectangles = list_BigRects;
            list_SmallRectangles = list_SmallRects;
            list_TextBlocks = list_Textblocks;
            pNumber = pressed;
        }

        public void MainOperation()
        {
            if (bigRectangle.StrokeThickness != 10)
            {
                pNumber++;
                Cards2.PressedNumber = pNumber;

                SolidColorBrush brush = new SolidColorBrush(Windows.UI.Colors.Yellow);
                smallRectangle.Opacity = 1;
                bigRectangle.Stroke = brush;
                bigRectangle.StrokeThickness = 10;

                textBlock.Opacity = 1;
                textBlock.Text = Cards2.PressedNumber.ToString();


                list_BigRectangles.Add(bigRectangle);
                list_SmallRectangles.Add(smallRectangle);
                list_TextBlocks.Add(textBlock);
            }
            else
            {
                //find position of current object in textBlocks, bigRectangles, and smallRectangles gerneric lists
                int position = -1;
                for (int i = 0; i < list_TextBlocks.Count; i++)
                {
                    if (list_TextBlocks[i] == textBlock)
                    {
                        position = i;
                        break;
                    }
                }

                //changes text of other rectangles and removes their textblocks from list 
                int originalTextBlocksCount = list_TextBlocks.Count;
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_TextBlocks[i].Text = "";
                    pNumber--;
                    Cards2.PressedNumber = pNumber;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_TextBlocks.RemoveAt(position);
                }



                //bigRectangles, changing opacity and removing from list
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_BigRectangles[i].StrokeThickness = 0;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_BigRectangles.RemoveAt(position);
                }



                //smallRectangles, changing opacity and removing from list
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_SmallRectangles[i].Opacity = 0;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    list_SmallRectangles.RemoveAt(position);
                }
            }
        }

        public void AddTo_list_orderOfCardsPressed (List<string> list_cardsPressed, string correspondingString)
        {
            int position = -1;
            for (int i = 0; i < list_TextBlocks.Count; i++)
            {
                if (list_TextBlocks[i] == textBlock)
                {
                    position = i;
                    break;
                }
            }

            int originalCardsPressedCount = list_cardsPressed.Count;

            if (bigRectangle.StrokeThickness != 10)
            {
                list_cardsPressed.Add(correspondingString);
            }
            else
            {

                for (int i = position; i < originalCardsPressedCount; i++)
                {
                    list_cardsPressed.RemoveAt(position);
                }

            }
        }
   * 
   
        /*   private void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

            RectanglePressed r = new RectanglePressed(BigRectangle1, SmallRectangle1, textblock1, bigRectangles, smallRectangles, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            r.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "One");
            r.MainOperation();


            #region Old Code
            /*        if (BigRectangle1.StrokeThickness != 10)
            {
                pressedNumber++;

                SolidColorBrush brush = new SolidColorBrush(Windows.UI.Colors.Yellow);
                SmallRectangle1.Opacity = 1;
                BigRectangle1.Stroke = brush;
                BigRectangle1.StrokeThickness = 10;

                textblock1.Opacity = 1;
                textblock1.Text = pressedNumber.ToString();

                textBlocks.Add(textblock1);
                bigRectangles.Add(BigRectangle1);
                smallRectangles.Add(SmallRectangle1);

            }
            else
            {
                //find position of current object in textBlocks, bigRectangles, and smallRectangles gerneric lists

                int position = 0; 

                for (int i = 0; i < textBlocks.Count; i++ )
                {
                    if (textBlocks[i] == textblock1)
                    {
                        position = i;
                      
                        break;
                    }
                }

                //changes text of other rectangles and removes their textblocks from list 
                int originalTextBlocksCount = textBlocks.Count;
                for (int i = position; i < originalTextBlocksCount; i++)
                    {
                        textBlocks[i].Text = ""; 
                        pressedNumber--; 
                    }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                   textBlocks.RemoveAt(position);    
                }



                //bigRectangles
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    bigRectangles[i].StrokeThickness = 0;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    bigRectangles.RemoveAt(position);
                }


                //smallRectangles
                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    smallRectangles[i].Opacity = 0;
                }

                for (int i = position; i < originalTextBlocksCount; i++)
                {
                    smallRectangles.RemoveAt(position);
                }

            }
     * 
     * 
           
        }

         #endregion
        private void BigRectangle2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RectanglePressed r = new RectanglePressed(BigRectangle2, SmallRectangle2, textblock2, bigRectangles, smallRectangles, list_textBlocks, pressedNumber);
            r.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "Two");
            r.MainOperation();


            #region Old Code
            /*
            if (BigRectangle2.StrokeThickness != 10)
            {
                pressedNumber++;

                SolidColorBrush brush = new SolidColorBrush(Windows.UI.Colors.Yellow);
                SmallRectangle2.Opacity = 1;
                BigRectangle2.Stroke = brush;
                BigRectangle2.StrokeThickness = 10;

                textblock2.Opacity = 1;
                textblock2.Text = pressedNumber.ToString();

                textBlocks.Add(textblock2);
                bigRectangles.Add(BigRectangle2);
                smallRectangles.Add(SmallRectangle2);

            }
            else
            {
                pressedNumber--;
                SmallRectangle2.Opacity = 0;  
                BigRectangle2.StrokeThickness = 0;

                textblock2.Opacity = 0;
                textblock2.Text = "";

            }
 * 
            #endregion
        }
      
        private void BigRectangle3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RectanglePressed r = new RectanglePressed(BigRectangle3, SmallRectangle3, textblock3, bigRectangles, smallRectangles, list_textBlocks, pressedNumber);
            r.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "Three");
            r.MainOperation();



            #region Old Code
            /*
            pressedNumber++;

            SolidColorBrush brush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            SmallRectangle3.Opacity = 1;
            BigRectangle3.Stroke = brush;
            BigRectangle3.StrokeThickness = 10;

            textblock3.Opacity = 1;
            textblock3.Text = pressedNumber.ToString();

            textBlocks.Add(textblock3);
            bigRectangles.Add(BigRectangle3);
            smallRectangles.Add(SmallRectangle3);
             * */
   
   
   
 

