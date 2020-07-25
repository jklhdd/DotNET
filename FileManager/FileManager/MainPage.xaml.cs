using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FileManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string filename = "text.txt";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void WriteFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var folder = ApplicationData.Current.LocalFolder;
                var file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file,data.Text);
                var message = new MessageDialog("Write file compelete!");
                await message.ShowAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.GetFileAsync(filename);
            var text = await FileIO.ReadTextAsync(file);
            var message = new MessageDialog(text);
            await message.ShowAsync();
        }

        private async void GetImage_Click(object sender, RoutedEventArgs e)
        {
            var pictures = await KnownFolders.PicturesLibrary.GetFilesAsync();
            if (pictures.Any())
            {
                var pic = pictures.First();
                using (var fileStream = await pic.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(fileStream);
                    DisplayImage.Source = bitmapImage;
                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStar­tLocation = PickerLocationId.Pic­turesLibrary;

            picker.FileTypeFilte­r.Add(".jpg");
            picker.FileTypeFilte­r.Add(".png");
            picker.FileTypeFilte­r.Add(".gif");

            var file = await picker.PickSingleFil­eAsync();
            if (file != null)
            {
                using (var fileStream = await file.OpenAsync(FileA­ccessMode.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourc­eAsync(fileStream);
                    DisplayImage.Source = bitmapImage;
                }
            }
        }

        private async void SaveImage_ClickAsync(object sender, RoutedEventArgs e)
        {
            var saveFilePicker = new FileSavePicker()
            {
                SuggestedStartLocati­on = PickerLocationId.Doc­umentsLibrary
            };
            saveFilePicker.FileT­ypeChoices.Add("Plai­n Text", new List<string>() { ".txt " });
            saveFilePicker.Sugge­stedFileName = "New Document";


            var file = await saveFilePicker.PickS­aveFileAsync();

            if (file != null)
            {
                await FileIO.WriteTextAsyn­c(file, data.Text);

                var message = new MessageDialog("Save file succesfully!");
                await message.ShowAsync();
            }
        }
    }
}
