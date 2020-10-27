using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuthenticationWithWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }



    }
}