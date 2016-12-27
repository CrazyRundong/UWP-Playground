using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Adeptly_Adaptive_Challenge.Models;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Adeptly_Adaptive_Challenge
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NewsItem> _news;

        public MainPage()
        {
            this.InitializeComponent();
            _news = ItemFactory.getNewsItems();
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
        }

        private void DisplaySubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO(Rundong): very stupid code, modify it!
            if (FinaSec.IsSelected)
            {
                ItemFactory.FilterItem("Financial", _news);
                Title.Text = "Financial";
            }
            else if (FoodSec.IsSelected)
            {
                ItemFactory.FilterItem("Food", _news);
                Title.Text = "Food";
            }
        }
    }
}