using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class DangKy
    {
        [Required(ErrorMessage = "User name Không được để trống")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Không được để trống")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Không được để trống")]
        public string Password { get; set; }

    }
}
