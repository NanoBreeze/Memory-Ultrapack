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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory_App_v1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test : Page
    {
        public Test()
        {
            this.InitializeComponent();
        }

        //numbers
        private void gridNumbers_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkNumbers.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectNumbers.Fill = new SolidColorBrush(Colors.White);
            borderNumbers.Opacity = 1;
        }

        private void gridNumbers_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderNumbers.Opacity = 0;
            rectNumbers.Opacity = 0.5;
            rectNumbers.Fill = new SolidColorBrush(Colors.Black);
            tbkNumbers.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridNumbers_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridNumbers.Background = new SolidColorBrush(Colors.Blue);
        }

        private void gridNumbers_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test_Numbers));
        }

        //letters
        private void gridLetters_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkLetters.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectLetters.Fill = new SolidColorBrush(Colors.White);
            borderLetters.Opacity = 1;
        }

        private void gridLetters_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderLetters.Opacity = 0;
            rectLetters.Opacity = 0.5;
            rectLetters.Fill = new SolidColorBrush(Colors.Black);
            tbkLetters.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridLetters_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridLetters.Background = new SolidColorBrush(Colors.Blue);
        }

        private void gridLetters_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test_Letters));
        }

        //symbols
        private void gridSymbols_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkSymbols.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectSymbols.Fill = new SolidColorBrush(Colors.White);
            borderSymbols.Opacity = 1;
        }

        private void gridSymbols_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderSymbols.Opacity = 0;
            rectSymbols.Opacity = 0.5;
            rectSymbols.Fill = new SolidColorBrush(Colors.Black);
            tbkSymbols.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridSymbols_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridSymbols.Background = new SolidColorBrush(Colors.Blue);
        }

        private void gridSymbols_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test_Symbols));
        }

        //cards
        private void gridCards_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkCards.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectCards.Fill = new SolidColorBrush(Colors.White);
            borderCards.Opacity = 1;
        }

        private void gridCards_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderCards.Opacity = 0;
            rectCards.Opacity = 0.5;
            rectCards.Fill = new SolidColorBrush(Colors.Black);
            tbkCards.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridCards_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridCards.Background = new SolidColorBrush(Colors.Blue);
        }

        private void gridCards_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Test_Cards));
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
