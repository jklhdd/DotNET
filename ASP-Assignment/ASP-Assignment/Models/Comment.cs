using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_Assignment.Models
{
    public class Comment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookId { get; set; }

        [Required(ErrorMessage = "Nội dung bình luận không được để trống!")]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public int IsActive { get; set; }
    }
}