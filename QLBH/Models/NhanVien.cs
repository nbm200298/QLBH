using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class NhanVien
    {
        [Key]
        public int IDNhanVien { get; set; }
        [Required, MaxLength(50)]
        public string TenNhanVien { get; set; }
        [Required, MaxLength(50)]
        public string DiaChi { get; set; }
        [Required, MinLength(8), MaxLength(10)]
        public string SDTNv { get; set; }
        public string Email { get; set; }
        public string ViTri { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        public ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}