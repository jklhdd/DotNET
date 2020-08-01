using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataValidate.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bạn phải nhập tên!")]
        [StringLength(30,MinimumLength = 6, ErrorMessage = "Tên phải từ 6 đến 30 kí tự!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mail!")]
        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$",ErrorMessage = "Địa chỉ email không hợp lệ!")]
        public string Mail { get; set; }
        [Range(10,60,ErrorMessage ="Tuổi phải từ 10 đến 60")]
        public int Age { get; set; }

        [Required]
        [StringLength(10,MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateOfBirth { get; set; }


    }
}