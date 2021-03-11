using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("CongViec")]
    public class CongViec
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string TenCV { get; set; }
        public virtual DuAn DuAn { get; set; }
        [ForeignKey("NguoiDung")]
        public int IdNguoiDung { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
