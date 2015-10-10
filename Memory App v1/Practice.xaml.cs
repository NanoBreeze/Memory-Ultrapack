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
    public sealed partial class Practice : Page
    {
        public Practice()
        {
            this.InitializeComponent();
        }

        private void gridNLS_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            tbkNLS.Foreground = new SolidColorBrush(Color.FromArgb(255, 159, 99, 42));
            rectNLS.Fill = new SolidColorBrush(Colors.White);
            borderNLS.Opacity = 1;
        }

        private void gridNLS_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            borderNLS.Opacity = 0;
            rectNLS.Opacity = 0.5;
            rectNLS.Fill = new SolidColorBrush(Colors.Black);
            tbkNLS.Foreground = new SolidColorBrush(Colors.White);
        }

        private void gridNLS_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            gridNLS.Background = new SolidColorBrush(Colors.DarkGreen);
        }

        private void gridNLS_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(NumbersLettersSymbols));
        }

        

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
            gridCards.Background = new SolidColorBrush(Colors.DarkGreen);
        }

        private void gridCards_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Cards));
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
