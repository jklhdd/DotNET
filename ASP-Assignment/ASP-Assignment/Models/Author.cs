using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Assignment.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên tác giả không được bỏ trống!")]
        public string AuthorName { get; set; }
        public string History { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}