using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("DuAn")]

    public class DuAn
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string TenDA { get; set; }
        public ICollection<NguoiDung> NguoiDungs { get; set; }
        public ICollection<CongViec> CongViecs { get; set; }
       
    }
}
