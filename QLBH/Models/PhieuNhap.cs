using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class PhieuNhap
    {
        [Key]
        public int IDPhieuNhap { get; set; }
        [Required]
        public int NgayNhap { get; set; }
        public int NCC_ID { get; set; }
        //[ForeignKey("NCC_ID")]
        //public NhaCungCap NhaCungCap { get; set; }
        public int NhanVien_ID { get; set; }
        //[ForeignKey("NhanVien_ID")]
        //public NhanVien NhanVien { get; set; }
        [Required]
        public string LyDoNhap { get; set; }
        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        [ForeignKey("NCC_ID")]
        public NhaCungCap NhaCungCap { get; set; }
        [ForeignKey("NhanVien_ID")]
        public NhanVien NhanVien { get; set; }
    }
}