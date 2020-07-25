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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace helloworld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class splitview : Page
    {
        public splitview()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mysplitpane.IsPaneOpen = !Mysplitpane.IsPaneOpen;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Mysplitpane.IsPaneOpen = !Mysplitpane.IsPaneOpen;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentDialog1 contentDialog1 = new ContentDialog1();
            var result = await contentDialog1.ShowAsync();
            switch (result)
            {
                case ContentDialogResult.None: break;
                case ContentDialogResult.Primary: break;
                case ContentDialogResult.Secondary: break;
            }
        }
    }
}
