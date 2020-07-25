using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding.Models
{
    class BookManagement
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book(1,"El-melloi2","Makoto","ms-appx:///Assets/Book1.png"),
                new Book(){ Id = 2, Name = "Combat baker", Author = "SOW", ImageURL = "ms-appx:///Assets/Book2.png"},
            };
        }
    }
}
