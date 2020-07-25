using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UMPSoundBoard.Models;
using UMPSoundBoard.Repository;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UMPSoundBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;
        private List<MenuItem> MenuItems;
        private List<String> suggestion;
        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);

            MenuItems = new List<MenuItem>()
            {
                new MenuItem(){IconFind="ms-appx:///Assets/Icons/animals.png",Category=SoundCategory.Animals},
                new MenuItem(){IconFind="ms-appx:///Assets/Icons/cartoon.png",Category=SoundCategory.Cartoons},
                new MenuItem(){IconFind="ms-appx:///Assets/Icons/warning.png",Category=SoundCategory.Warnings},
                new MenuItem(){IconFind="ms-appx:///Assets/Icons/taunt.png",Category=SoundCategory.Taunts},
            };
            Back.Visibility = Visibility.Collapsed;
        }

        private void MenuListItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as MenuItem;
            CategoryTextBlock.Text = item.Category.ToString();
            SoundManager.GetSoundsByCategory(Sounds, item.Category);
            Back.Visibility = Visibility.Visible;
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CategoryTextBlock.Text = "All sounds";
            SoundManager.GetAllSounds(Sounds);
            MenuItemListView.SelectedItem = null;
            Back.Visibility = Visibility.Collapsed;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Sound;
            if(item != null)
            {
                Media.Source = new Uri(this.BaseUri,item.AudioFile);
                Media.Play();
            }
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "Copy";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                Sound addSound = new Sound("UserAdd", SoundCategory.UserADD);
                addSound.ImageFile = "ms-appx:///Assets/Images/user_add.png";
                var sounds = await e.DataView.GetStorageItemsAsync();
                if (sounds.Any())
                {
                    var storageFile = sounds[0] as StorageFile;
                    var contentType = storageFile.ContentType;

                    string root = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
                    string path = root + @"\Assets\Audio";
                    StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(path);

                    if(contentType == "audio/wav" )
                    {
                        StorageFile newFile = await storageFile.CopyAsync(folder,storageFile.Name,NameCollisionOption.GenerateUniqueName);
                        Media.SetSource(await storageFile.OpenAsync(FileAccessMode.Read), contentType);
                        addSound.AudioFile = newFile.Path;
                    }    
                }
                Sounds.Add(addSound);
            }
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            
            var allSounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(allSounds);
            suggestion = Sounds.Where(x => x.Name.ToLower().Contains(sender.Text.ToLower())).Select(x => x.Name).ToList();
            SearchBox.ItemsSource = suggestion;
        }

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            SoundManager.GetSoundByName(Sounds,sender.Text);
            CategoryTextBlock.Text = "Search by " + sender.Text;
            MenuItemListView.SelectedItem = null;
            Back.Visibility = Visibility.Visible;
            SearchBox.Text = string.Empty;
        }
    }
}
