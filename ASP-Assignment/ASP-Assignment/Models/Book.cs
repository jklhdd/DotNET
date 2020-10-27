using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

namespace ASP_Assignment.Models
{
       
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được bỏ trống!")]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Summary { get; set; }
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Giá tiền không được bỏ trống!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Số lượng không được bỏ trống!")]
        public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }
        public int IsActive { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}