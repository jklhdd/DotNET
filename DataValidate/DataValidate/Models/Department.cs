﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataValidate.Models
{
    public class Department
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}