using FakeNew.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNew.Reposition
{
    class NewsManagement
    {
        private static List<NewItem> GetNewsItems()
        {
            return new List<NewItem>()
            {
                new NewItem(1,"Food","Headline1","Subhead1","22/06/2020","ms-appx:///Assets/1.jpg"),
                new NewItem(2,"Financial","Headline2","Subhead2","22/06/2020","ms-appx:///Assets/2.png"),
                new NewItem(3,"Food","Headline3","Subhead3","22/06/2020","ms-appx:///Assets/2.png"),
                new NewItem(4,"Financial","Headline4","Subhead4","22/06/2020","ms-appx:///Assets/1.jpg"),
                new NewItem(5,"Financial","Headline5","Subhead5","22/06/2020","ms-appx:///Assets/3.png"),
                new NewItem(6,"Food","Headline6","Subhead6","22/06/2020","ms-appx:///Assets/3.png"),

            };
        }

        public static void GetNews(string category, ObservableCollection<NewItem> newItems)
        {
            if(newItems.Count != 0)
            {
                newItems.Clear();
            }
            foreach (var item in GetNewsItems())
            {
                if(item.Category == category)
                {
                    newItems.Add(item);
                }
            }
        }
    }
}
