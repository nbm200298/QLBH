using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class NhaCungCap
    {
        [Key]
        public int IDNCC { get; set; }
        [Required]
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        [Required, MinLength(8), MaxLength(10)]
        public string SDTNcc { get; set; }
        public ICollection<PhieuNhap> PhieuNhaps { get; set; }

    }
}