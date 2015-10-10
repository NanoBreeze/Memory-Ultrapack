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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1.Games
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level12Answer : Page
    {
        bool advanceToC3 = true;
        ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;


         DispatcherTimer dispatcherTimer = new DispatcherTimer();        //waits 20 seconds in order to initialize images' heights to canvas' ActualHeight

        static int pressedNumber = 0;  //displays digit in textblock

        //these lists keep track of the order of textblocks, so we can unclick the textblocks behind one when that one is clicked
        List<TextBlock> list_textBlocks = new List<TextBlock>();
        List<Image> list_images = new List<Image>();


        //this list keeps the corresponding string of the cards pressed (in order) so that the order may later be validated
        List<string> list_orderOfCardsPressed = new List<string>();


        public Level12Answer()
        {
            this.InitializeComponent();

            tbkNumberOfCardsRemaining.Text = "Number of cards remaining: " + Level12.List_images.Count;
             dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            

            image_S1.Height = canvas.ActualHeight / 4;
            image_S2.Height = canvas.ActualHeight / 4;
            image_S3.Height = canvas.ActualHeight / 4;
            image_S4.Height = canvas.ActualHeight / 4;
            image_S5.Height = canvas.ActualHeight / 4;

            canvas.Width = image_S1.Height / 1.4 * 14;

            tbxNumber1_Answer.FontSize = tbxNumber1_Answer.ActualHeight * 0.8;
        }

          #region spades
        private void image_S1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk1, image_S1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S1");
            i.MainOperation();
        }

        private void tbk1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk1, image_S1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S1");
            i.MainOperation();
        }


        private void image_S2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk2, image_S2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S2");
            i.MainOperation();
        }

        private void tbk2_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk2, image_S2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S2");
            i.MainOperation();
        }

        private void image_S3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk3, image_S3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S3");
            i.MainOperation();
        }

        private void tbk3_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk3, image_S3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S3");
            i.MainOperation();
        }

        private void image_S4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk4, image_S4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S4");
            i.MainOperation();
        }

        private void tbk4_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk4, image_S4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S4");
            i.MainOperation();
        }

        private void image_S5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk5, image_S5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S5");
            i.MainOperation();
        }

        private void tbk5_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk5, image_S5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S5");
            i.MainOperation();
        }

        private void image_S6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk6, image_S6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S6");
            i.MainOperation();
        }

        private void tbk6_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk6, image_S6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S6");
            i.MainOperation();
        }

        private void image_S7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk7, image_S7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S7");
            i.MainOperation();
        }

        private void tbk7_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk7, image_S7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S7");
            i.MainOperation();
        }

        private void image_S8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk8, image_S8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S8");
            i.MainOperation();
        }

        private void tbk8_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk8, image_S8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S8");
            i.MainOperation();
        }

        private void image_S9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk9, image_S9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S9");
            i.MainOperation();
        }

        private void tbk9_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk9, image_S9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S9");
            i.MainOperation();
        }

        private void image_S10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk10, image_S10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S10");
            i.MainOperation();
        }

        private void tbk10_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk10, image_S10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S10");
            i.MainOperation();
        }

        private void image_S11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk11, image_S11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S11");
            i.MainOperation();
        }

        private void tbk11_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk11, image_S11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S11");
            i.MainOperation();
        }

        private void image_S12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk12, image_S12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S12");
            i.MainOperation();
        }

        private void tbk12_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk12, image_S12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S12");
            i.MainOperation();
        }

        private void image_S13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk13, image_S13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S13");
            i.MainOperation();
        }

        private void tbk13_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ImagePressed12 i = new ImagePressed12(tbk13, image_S13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
            i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "S13");
            i.MainOperation();
        }
          #endregion

          #region hearts
          private void image_H1_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH1, image_H1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H1");
              i.MainOperation();
          }

          private void tbkH1_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH1, image_H1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H1");
              i.MainOperation();
          }


          private void image_H2_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH2, image_H2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H2");
              i.MainOperation();
          }

          private void tbkH2_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH2, image_H2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H2");
              i.MainOperation();
          }

          private void image_H3_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH3, image_H3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H3");
              i.MainOperation();
          }

          private void tbkH3_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH3, image_H3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H3");
              i.MainOperation();
          }

          private void image_H4_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH4, image_H4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H4");
              i.MainOperation();
          }

          private void tbkH4_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH4, image_H4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H4");
              i.MainOperation();
          }

          private void image_H5_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH5, image_H5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H5");
              i.MainOperation();
          }

          private void tbkH5_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH5, image_H5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H5");
              i.MainOperation();
          }

          private void image_H6_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH6, image_H6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H6");
              i.MainOperation();
          }

          private void tbkH6_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH6, image_H6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H6");
              i.MainOperation();
          }

          private void image_H7_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH7, image_H7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H7");
              i.MainOperation();
          }

          private void tbkH7_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH7, image_H7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H7");
              i.MainOperation();
          }

          private void image_H8_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH8, image_H8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H8");
              i.MainOperation();
          }

          private void tbkH8_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH8, image_H8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H8");
              i.MainOperation();
          }

          private void image_H9_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH9, image_H9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H9");
              i.MainOperation();
          }

          private void tbkH9_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH9, image_H9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H9");
              i.MainOperation();
          }

          private void image_H10_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH10, image_H10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H10");
              i.MainOperation();
          }

          private void tbkH10_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH10, image_H10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H10");
              i.MainOperation();
          }

          private void image_H11_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH11, image_H11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H11");
              i.MainOperation();
          }

          private void tbkH11_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH11, image_H11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H11");
              i.MainOperation();
          }

          private void image_H12_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH12, image_H12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H12");
              i.MainOperation();
          }

          private void tbkH12_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH12, image_H12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H12");
              i.MainOperation();
          }

          private void image_H13_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH13, image_H13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H13");
              i.MainOperation();
          }

          private void tbkH13_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkH13, image_H13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "H13");
              i.MainOperation();
          }
          #endregion

          #region clubs
          private void image_C1_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC1, image_C1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C1");
              i.MainOperation();
          }

          private void tbkC1_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC1, image_C1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C1");
              i.MainOperation();
          }


          private void image_C2_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC2, image_C2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C2");
              i.MainOperation();
          }

          private void tbkC2_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC2, image_C2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C2");
              i.MainOperation();
          }

          private void image_C3_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC3, image_C3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C3");
              i.MainOperation();
          }

          private void tbkC3_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC3, image_C3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C3");
              i.MainOperation();
          }

          private void image_C4_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC4, image_C4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C4");
              i.MainOperation();
          }

          private void tbkC4_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC4, image_C4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C4");
              i.MainOperation();
          }

          private void image_C5_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC5, image_C5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C5");
              i.MainOperation();
          }

          private void tbkC5_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC5, image_C5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C5");
              i.MainOperation();
          }

          private void image_C6_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC6, image_C6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C6");
              i.MainOperation();
          }

          private void tbkC6_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC6, image_C6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C6");
              i.MainOperation();
          }

          private void image_C7_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC7, image_C7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C7");
              i.MainOperation();
          }

          private void tbkC7_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC7, image_C7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C7");
              i.MainOperation();
          }

          private void image_C8_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC8, image_C8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C8");
              i.MainOperation();
          }

          private void tbkC8_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC8, image_C8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C8");
              i.MainOperation();
          }

          private void image_C9_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC9, image_C9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C9");
              i.MainOperation();
          }

          private void tbkC9_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC9, image_C9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C9");
              i.MainOperation();
          }

          private void image_C10_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC10, image_C10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C10");
              i.MainOperation();
          }

          private void tbkC10_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC10, image_C10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C10");
              i.MainOperation();
          }

          private void image_C11_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC11, image_C11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C11");
              i.MainOperation();
          }

          private void tbkC11_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC11, image_C11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C11");
              i.MainOperation();
          }

          private void image_C12_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC12, image_C12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C12");
              i.MainOperation();
          }

          private void tbkC12_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC12, image_C12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C12");
              i.MainOperation();
          }

          private void image_C13_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC13, image_C13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C13");
              i.MainOperation();
          }

          private void tbkC13_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkC13, image_C13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "C13");
              i.MainOperation();
          }
          #endregion

          #region diamonds
          private void image_D1_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD1, image_D1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D1");
              i.MainOperation();
          }

          private void tbkD1_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD1, image_D1, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D1");
              i.MainOperation();
          }


          private void image_D2_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD2, image_D2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D2");
              i.MainOperation();
          }

          private void tbkD2_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD2, image_D2, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D2");
              i.MainOperation();
          }

          private void image_D3_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD3, image_D3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D3");
              i.MainOperation();
          }

          private void tbkD3_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD3, image_D3, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D3");
              i.MainOperation();
          }

          private void image_D4_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD4, image_D4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D4");
              i.MainOperation();
          }

          private void tbkD4_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD4, image_D4, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D4");
              i.MainOperation();
          }

          private void image_D5_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD5, image_D5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D5");
              i.MainOperation();
          }

          private void tbkD5_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD5, image_D5, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D5");
              i.MainOperation();
          }

          private void image_D6_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD6, image_D6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D6");
              i.MainOperation();
          }

          private void tbkD6_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD6, image_D6, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D6");
              i.MainOperation();
          }

          private void image_D7_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD7, image_D7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D7");
              i.MainOperation();
          }

          private void tbkD7_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD7, image_D7, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D7");
              i.MainOperation();
          }

          private void image_D8_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD8, image_D8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D8");
              i.MainOperation();
          }

          private void tbkD8_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD8, image_D8, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D8");
              i.MainOperation();
          }

          private void image_D9_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD9, image_D9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D9");
              i.MainOperation();
          }

          private void tbkD9_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD9, image_D9, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D9");
              i.MainOperation();
          }

          private void image_D10_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD10, image_D10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D10");
              i.MainOperation();
          }

          private void tbkD10_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD10, image_D10, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D10");
              i.MainOperation();
          }

          private void image_D11_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD11, image_D11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D11");
              i.MainOperation();
          }

          private void tbkD11_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD11, image_D11, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D11");
              i.MainOperation();
          }

          private void image_D12_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD12, image_D12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D12");
              i.MainOperation();
          }

          private void tbkD12_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD12, image_D12, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D12");
              i.MainOperation();
          }

          private void image_D13_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD13, image_D13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D13");
              i.MainOperation();
          }

          private void tbkD13_PointerPressed(object sender, PointerRoutedEventArgs e)
          {
              ImagePressed12 i = new ImagePressed12(tbkD13, image_D13, list_images, list_textBlocks, pressedNumber, tbkNumberOfCardsRemaining);
              i.AddTo_list_orderOfCardsPressed(list_orderOfCardsPressed, "D13");
              i.MainOperation();
          }


          #endregion

          private void btnCheck_Click(object sender, RoutedEventArgs e)
          {

              int numberAllRight = 1;      

              //==check units

              tbkResult.Text = "";
              tbkResult.FontSize = Frame.ActualHeight / 30;

              //tbxNumber1_Answer,  note that i = 0 
              for (int i = 0; i < tbxNumber1_Answer.Text.Length; i++)
              {
                  if (tbxNumber1_Answer.Text[i].ToString() == Level12.UnitsShowns[i + 0])
                  {
                //      tbkResult.Text += "Correct ";
                  }
                  else
                  {
                    //  tbkResult.Text += "Incorrect ";
                      numberAllRight = 0;
                      advanceToC3 = false;
                  }
              }

              if (tbxNumber1_Answer.Text == "")
              {
                  numberAllRight = 2;
                  advanceToC3 = false;
              }

              //==checks if the cards user pressed are correct
              tbkResult.Text += "\n";

              for (int i = 0; i < list_orderOfCardsPressed.Count; i++)               //we base this for loop on the number of cards user pressed
              {
                  if (list_orderOfCardsPressed[i] == Level12.List_OrderOfCardsShown[i])
                  {
                      tbkResult.Text += "\nCard " + (i+1).ToString() + ": Correct";
                  }
                  else
                  {
                      tbkResult.Text += "\nCard " + (i + 1).ToString() + ": Incorrect || Correct Answer: " + Level12.List_OrderOfCardsShown[i];
                      advanceToC3 = false;
                  }
              }

              //if the user pressed a fewer number of cards than was shown, the check_tbkCheck writes "Missed"
              for (int i = list_orderOfCardsPressed.Count; i < Level12.List_OrderOfCardsShown.Count; i++)
              {
                  tbkResult.Text += "\nCard " + (i+1).ToString() + ": Missed || Correct Answer " + Level12.List_OrderOfCardsShown[i];
                  advanceToC3 = false;
              }

              tbkResult.Text += "\n";

              //adds responses
              if (numberAllRight == 1)
              {
                  tbkResult.Text += "Numbers: Correct";
                  tbxNumber1_Answer.Foreground = new SolidColorBrush(Colors.Green);
              }
              if (numberAllRight == 0)
              {
                  tbkResult.Text += "Numbers: Incorrect || Correct Answer: " + Level12.UnitsShowns[0] + Level12.UnitsShowns[1] + Level12.UnitsShowns[2]
                      + Level12.UnitsShowns[3] + Level12.UnitsShowns[4] + Level12.UnitsShowns[5] + Level12.UnitsShowns[6] + Level12.UnitsShowns[7]
                      + Level12.UnitsShowns[8] + Level12.UnitsShowns[9] + Level12.UnitsShowns[10] + Level12.UnitsShowns[11] + Level12.UnitsShowns[12]
                      + Level12.UnitsShowns[13];
                  tbxNumber1_Answer.Foreground = new SolidColorBrush(Colors.Red);
              }
              if (numberAllRight == 2)
              {
                  tbkResult.Text += "Numbers: Missed || Correct Answer: " + Level12.UnitsShowns[0] + Level12.UnitsShowns[1] + Level12.UnitsShowns[2]
                      + Level12.UnitsShowns[3] + Level12.UnitsShowns[4] + Level12.UnitsShowns[5] + Level12.UnitsShowns[6] + Level12.UnitsShowns[7]
                      + Level12.UnitsShowns[8] + Level12.UnitsShowns[9] + Level12.UnitsShowns[10] + Level12.UnitsShowns[11] + Level12.UnitsShowns[12]
                      + Level12.UnitsShowns[13];
              }

              if (advanceToC3)
              {
                  btnNextLevel.Visibility = Windows.UI.Xaml.Visibility.Visible;
                  strybtnNextLevel.Begin();
                  settings.Values["C3"] = 1;
              }
          }

          public static int PressedNumber
          {
              get { return pressedNumber; }
              set { pressedNumber = value; }
          }

          private void appbarbuttonBackToGamesPage_Click(object sender, RoutedEventArgs e)
          {
              Frame.Navigate(typeof(Game));
          }

          private void AppBarButton_Click(object sender, RoutedEventArgs e)
          {
              Frame.Navigate(typeof(Level12));
          }

          private void appbarbuttonMainMenu_Click(object sender, RoutedEventArgs e)
          {
              Frame.Navigate(typeof(MainPage));
          }

          private void btnNextLevel_Click(object sender, RoutedEventArgs e)
          {
              Frame.Navigate(typeof(Level13));
          }

        }

    class ImagePressed12
    {
        TextBlock textBlock;
        Image image;

        List<Image> list_images2 = new List<Image>();
        List<TextBlock> list_textBlocks2 = new List<TextBlock>();

        int pNumber;
        TextBlock cardsRemaining;

        public ImagePressed12(TextBlock t, Image i, List<Image> list_i, List<TextBlock> list_t, int pressed, TextBlock cRemaining)
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
                if (Level12.List_images.Count - pNumber == 0)          //if there are no more cards remaining, we do not add additional 
                //cards to list_cardsPressed
                {

                }
                else
                {
                    pNumber++;
                    Level12Answer.PressedNumber = pNumber;

                    image.Opacity = 0.4;
                    textBlock.Opacity = 1;
                    textBlock.Text = Level12Answer.PressedNumber.ToString();

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
                    Level12Answer.PressedNumber = pNumber;
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

            cardsRemaining.Text = "Number of cards remaining: " + (Level12.List_images.Count - pNumber).ToString();
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
                if (Level12.List_images.Count - pNumber == 0)          //if there are no more cards remaining, we do not add additional 
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
