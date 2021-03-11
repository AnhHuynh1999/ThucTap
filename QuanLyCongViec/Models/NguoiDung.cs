using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string TenNV { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string DiaChi { get; set; }
        public virtual CongViec CongViec { get; set; }
        public virtual DuAn DuAn { get; set; }
    }
}
