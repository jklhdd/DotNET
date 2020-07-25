using SQLLite.DataAssets;
using SQLLite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
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

namespace SQLLite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static string path = Path.Combine(ApplicationData.Current.LocalFolder.Path,"db.sqlite");
        ObservableCollection<Contacts> Contacts;
        DatabaseHelperClass databaseHelper;
        public MainPage()
        {
            this.InitializeComponent();
            databaseHelper = new DatabaseHelperClass(path);
            Contacts = databaseHelper.GetContacts();
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contacts newcontact = new Contacts()
                {
                    Name = txtName.Text,
                    PhoneNumber = txtPhone.Text,
                    CreationDate = DateTime.Now.ToString()
                };
                databaseHelper.Insert(newcontact);
                Contacts.Add(newcontact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Contacts;
            txtName.Text = item.Name;
            txtPhone.Text = item.PhoneNumber;
            AddContactButton.Visibility = Visibility.Collapsed;
            UpdateContactButton.Visibility = Visibility.Visible;
        }

        private void UpdateContactButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contacts newitem = new Contacts()
                {
                    Name = txtName.Text,
                    PhoneNumber = txtPhone.Text,
                    CreationDate = DateTime.Now.ToString()
                };
                databaseHelper.UpdateContacts(newitem);
                Contacts = databaseHelper.GetContacts();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
