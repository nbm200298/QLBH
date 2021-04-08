using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class KhachHang
    {
        [Key]
        public int IdKhachHang { get; set; }
        [Required, MaxLength(50)]
        public string TenKhachHang { get; set; }
        [Required, MaxLength(50)]
        public string DiaChi { get; set; }
        [Required, MinLength(8), MaxLength(10)]
        public string SDTKh { get; set; }
        public int TaiKhoan { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}