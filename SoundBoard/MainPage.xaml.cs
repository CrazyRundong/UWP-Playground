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
using SoundBoard.Models;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace SoundBoard
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<SoundItem> Sounds { get; set; }
        private List<MenuItem> SelectionItem { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Sounds = SoundItemManager.GenerateSounds();
            SelectionItem = MenuItemManager.GetMenuItems();
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void SearchSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void MainContent_OnDrop(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainContent_OnDragOver(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var itemSelected = e.ClickedItem as MenuItem;
            Sounds.Clear();
            Sounds = SoundItemManager.GenerateSounds(itemSelected.Category);
        }
    }
}