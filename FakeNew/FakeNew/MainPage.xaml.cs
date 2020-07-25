using FakeNew.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FakeNew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NewItem> newItems;
        public MainPage()
        {
            this.InitializeComponent();
            newItems = new ObservableCollection<NewItem>();            
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        

        private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Financial.IsSelected)
            {
                FakeNew.Reposition.NewsManagement.GetNews("Financial", newItems);
            }
            if (Food.IsSelected)
            {
                FakeNew.Reposition.NewsManagement.GetNews("Food", newItems);
            }
        }

        private void NewsItemsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var news = e.ClickedItem as NewItem;
            if (news != null)
            {
                MyFrame.Navigate(typeof(NewsDetail), news);
            }
        }
    }
}
