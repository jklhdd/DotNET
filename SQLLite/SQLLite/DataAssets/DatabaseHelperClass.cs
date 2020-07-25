using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using SQLLite.Models;

namespace SQLLite.DataAssets
{
    public class DatabaseHelperClass
    {
        SQLiteConnection conn;
        public DatabaseHelperClass(string path)
        {
            try
            {
                if (!CheckFileExists(path).Result)
                {
                    this.conn = new SQLiteConnection(new SQLitePlatformWinRT(), path);
                    conn.CreateTable<Contacts>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Insert(Contacts contact)
        {
            conn.RunInTransaction(() =>
            {
                conn.Insert(contact);
            });
        }
        public Contacts GetContactById(int Id)
        {
            
            return conn.Query<Contacts>("SELECT * FROM Contacts WHERE id = " + Id).FirstOrDefault();
        }

        public ObservableCollection<Contacts> GetContacts()
        {
            var contacts = conn.Table<Contacts>().ToList();
            var contactsList = new ObservableCollection<Contacts>(contacts);
            return contactsList;
        }

        public void UpdateContacts(int id)
        {
            try
            {
                var contact = conn.Query<Contacts>("SELECT * FROM Contacts WHERE id = " + id).FirstOrDefault();
                conn.Update(contact);
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
