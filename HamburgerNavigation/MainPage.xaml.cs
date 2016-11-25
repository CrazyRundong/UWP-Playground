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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace HamburgerNavigation {
  /// <summary>
  /// 可用于自身或导航至 Frame 内部的空白页。
  /// </summary>
  public sealed partial class MainPage : Page {
    public MainPage() {
      this.InitializeComponent();
      ContentFrame.Navigate(typeof(PageFinnancial));
      BckButton.Visibility = Visibility.Collapsed;
      Title.Text = "Financial";
      FinaSec.IsSelected = true;
    }

    private void NavButton_Click(object sender, RoutedEventArgs e) {
      Menu.IsPaneOpen = !Menu.IsPaneOpen;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (FinaSec.IsSelected) {
        ContentFrame.Navigate(typeof(PageFinnancial));
        Title.Text = "Financial";
        BckButton.Visibility = Visibility.Collapsed;
      } else if (FoodSec.IsSelected) {
        ContentFrame.Navigate(typeof(PageFood));
        Title.Text = "Food";
        BckButton.Visibility = Visibility.Visible;
      }
    }

    private void BckButton_Click(object sender, RoutedEventArgs e) {
      if (ContentFrame.CanGoBack) {
        FinaSec.IsSelected = true;
      }
    }
  }
}
