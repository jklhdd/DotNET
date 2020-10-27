using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Assignment.Models
{
    public class Category
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được bỏ trống!")]
        public string CateName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}