using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class NguoiSuDung : IdentityUser
    {
        public bool TinhTrang { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
    }
}
