using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.models
{
    public class Contacts
    {
        private String fname;
        private String lname;
        private String phone;

        public Contacts()
        {
        }

        public Contacts(string fname, string lname, string phone)
        {
            this.fname = fname;
            this.lname = lname;
            this.phone = phone;
        }

        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
