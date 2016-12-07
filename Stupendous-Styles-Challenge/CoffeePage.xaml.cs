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
        private string _coffeeRoast = String.Empty;
        private string _coffeeSweeter = String.Empty;
        private string _coffeeCream = String.Empty;

        private void RoastNone_Click(object sender, RoutedEventArgs e) {
            CoffeeText.Text = _coffeeText;
        }

        private void RoastFark_Click(object sender, RoutedEventArgs e) {
            _coffeeRoast = RoastFark.Text;
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }

        private void RoastMedium_Click(object sender, RoutedEventArgs e) {
            _coffeeRoast = RoastMedium.Text;
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }

        private void SweeterNone_Click(object sender, RoutedEventArgs e) {
            _coffeeSweeter = $"with {SweeterNone.Text} sugar";
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }

        private void SweeterSuger_Click(object sender, RoutedEventArgs e) {
            _coffeeSweeter = $"with {SweeterSuger.Text} sugar";
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }

        private void CreamNone_Click(object sender, RoutedEventArgs e) {
            _coffeeCream = $"and {CreamNone.Text} cream";
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }

        private void Cream5Milk_Click(object sender, RoutedEventArgs e) {
            _coffeeCream = $"and {Cream5Milk.Text} cream";
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }

        private void CreamFullMilk_Click(object sender, RoutedEventArgs e) {
            _coffeeCream = $"and {CreamFullMilk.Text} cream";
            CoffeeText.Text = $"{_coffeeText} {_coffeeRoast}, {_coffeeSweeter}, {_coffeeCream}";
        }
    }
}
