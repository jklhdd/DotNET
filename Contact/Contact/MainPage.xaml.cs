using Contact.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Contact
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Contacts> Contacts;
        public MainPage()
        {
            this.InitializeComponent();
            Contacts = new ObservableCollection<Contacts>
            {
                new Contacts("Nguyen","A","12345678"),
                new Contacts("Nguyen","B","87654321"),
                new Contacts("Nguyen","C","11223344")
            };
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Contacts contact = new Contacts();
            contact.Fname = fname.Text;
            contact.Lname = lname.Text;
            contact.Phone = phone.Text;
            MessageDialog message;
            if(contact.Fname == "")
            {
                message = new MessageDialog("First name not null");
            }
            else if(contact.Lname == "")
            {
                message = new MessageDialog("Last name not null");
            }
            else if(contact.Phone == "")
            {
                message = new MessageDialog("First name not null");
            }
            Contacts.Add(contact);
        }
    }
}
