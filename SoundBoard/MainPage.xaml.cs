using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        private List<MenuItem> SelectionItem { get; }

        public MainPage()
        {
            this.InitializeComponent();
            Sounds = SoundItemManager.GenerateSounds();
            SelectionItem = MenuItemManager.GetMenuItems();
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            Sounds.Clear();
            foreach (var item in SoundItemManager.GenerateSounds())
            {
                Sounds.Add(item);
            }
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MenuListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var itemSelected = e.ClickedItem as MenuItem;
            if (itemSelected == null) return;
            Sounds.Clear();
            foreach (var item in SoundItemManager.GenerateSounds(itemSelected.Category))
            {
                Sounds.Add(item);
            }
            BackButton.Visibility = Visibility.Visible;
        }

        private void SearchSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (String.IsNullOrEmpty(sender.Text)) return;
            var queryResult = Sounds.Where(p => p.Name.StartsWith(sender.Text)).Select(p => p.Name).ToList();
            sender.ItemsSource = queryResult;
        }

        private void SearchSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            SoundItemManager.FilterItemByName(Sounds, sender.Text);
            BackButton.Visibility = Visibility.Visible;
        }

        private void MainContent_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedItem = e.ClickedItem as SoundItem;
            if (selectedItem != null)
                MainBackgroundPlayer.Source = new Uri(this.BaseUri, selectedItem.AudioPath);
        }

        private async void MainContent_OnDrop(object sender, DragEventArgs e)
        {
            if (!e.DataView.Contains(StandardDataFormats.StorageItems)) return;
            var items = await e.DataView.GetStorageItemsAsync();

            if (!items.Any()) return;
            var storageFile = items[0] as StorageFile;
            if (storageFile == null) return;
            var contentType = storageFile.ContentType;

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            if (contentType != "audio/wav" && contentType != "audio/mpeg") return;
            StorageFile newFile =
                await storageFile.CopyAsync(
                    folder,
                    storageFile.Name,
                    NameCollisionOption.GenerateUniqueName);

            MainBackgroundPlayer.SetSource(
                await storageFile.OpenAsync(FileAccessMode.Read),
                contentType);

            MainBackgroundPlayer.Play();
        }

        private void MainContent_OnDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;

            if (e.DragUIOverride != null)
            {
                e.DragUIOverride.Caption = "drop to create a custom sound and tile";
                e.DragUIOverride.IsCaptionVisible = true;
                e.DragUIOverride.IsContentVisible = true;
                e.DragUIOverride.IsGlyphVisible = true;
            }
        }
    }
}