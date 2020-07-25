using System;
using System.ComponentModel;

namespace Session3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Date of Join")]
        public DateTime DateOfJoin { get; set; }
    }
}