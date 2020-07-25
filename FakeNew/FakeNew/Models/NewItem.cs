using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNew.Models
{
    public class NewItem
    {
        private int id;
        private string category;
        private string headline;
        private string subhead;
        private string dateline;
        private string image;

        public NewItem()
        {

        }
        public NewItem(int id, string category, string headline, string subhead, string dataline, string image)
        {
            this.id = id;
            this.category = category;
            this.headline = headline;
            this.subhead = subhead;
            this.dateline = dataline;
            this.image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Category { get => category; set => category = value; }
        public string Headline { get => headline; set => headline = value; }
        public string Subhead { get => subhead; set => subhead = value; }
        public string Dataline { get => dateline; set => dateline = value; }
        public string Image { get => image; set => image = value; }
    }
}
