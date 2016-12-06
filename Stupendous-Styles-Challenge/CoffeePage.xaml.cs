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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Stupendous_Styles_Challenge {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CoffeePage : Page {
        public CoffeePage() {
            this.InitializeComponent();
        }

        private string _coffeeText = "Coffee:\t";
        private string _coffeeRoast = "";
        private string _coffeeSweeter = "";
        private string _coffeeCream = "";

        private void RoastNone_Click(object sender, RoutedEventArgs e) {
            _coffeeRoast = "";

        }

        private void RoastFark_Click(object sender, RoutedEventArgs e) {
            _coffeeRoast = RoastFark.Text;

        }

        private void RoastMedium_Click(object sender, RoutedEventArgs e) {
            _coffeeRoast = RoastMedium.Text;

        }

        private void SweeterNone_Click(object sender, RoutedEventArgs e) {

        }

        private void SweeterSuger_Click(object sender, RoutedEventArgs e) {

        }

        private void CreamNone_Click(object sender, RoutedEventArgs e) {

        }

        private void Cream5Milk_Click(object sender, RoutedEventArgs e) {

        }

        private void CreamFullMilk_Click(object sender, RoutedEventArgs e) {

        }
    }
}
