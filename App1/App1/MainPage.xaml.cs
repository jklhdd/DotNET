using App1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();

            var ID = id.Text;
            var Name = name.Text;
            var Date = dob.Date;

            string message = string.Empty;
            Regex regex = new Regex(@"^[\d]+$");

            if (ID == "")
            {
                message += "ID must not empty!";
            }
            else if (!regex.IsMatch(ID))
            {
                message += "ID must be number!";
            }
            if(Name == "")
            {
                message += "Name must not empty!";
            }

            if (dob.SelectedDate > DateTime.Now)
            {
                message += "Invalid date of birth!";
            }

            if (message != string.Empty)
            {
                MessageDialog dialog = new MessageDialog(message);
                await dialog.ShowAsync();
            }

            else
            {
                student.Id = Int32.Parse(ID);
                student.Name = Name;
                student.DateOfBirth = Date;
            }

            Frame.Navigate(typeof(studentDetailPage), student);
        }
    }
}
