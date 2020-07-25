using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class Student
    {
        private int id;
        private string name;
        private DateTimeOffset dateOfBirth;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTimeOffset DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    }
}
