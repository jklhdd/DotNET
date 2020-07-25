using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding.Models
{
    class Book
    {
        private int id;
        private String name;
        private String author;
        private String imageURL;

        public Book()
        {
        }

        public Book(int id, string name, string author, string imageURL)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.imageURL = imageURL;
        }

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public int Id { get => id; set => id = value; }
    }
}
