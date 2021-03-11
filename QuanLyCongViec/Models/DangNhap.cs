using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class DangNhap
    {
        [Required(ErrorMessage ="Username Không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Không được để trống")]
        public string Password { get; set; }
    }
}
