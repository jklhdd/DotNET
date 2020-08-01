﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBASP.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}