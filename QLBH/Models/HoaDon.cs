using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class HoaDon
    {
        [Key]
        public int IDHoaDon { get; set; }
        [Required]
        public string NgayLap { get; set; }
        public int KhachHang_ID { get; set; }
        //[ForeignKey("KhachHang_ID")]
        //public KhachHang KhachHang { get; set; }
        public int NhanVien_ID { get; set; }
        //[ForeignKey("NhanVien_ID")]
        //public NhanVien NhanVien { get; set; }
        [Required]
        public int TongTienTT { get; set; }
        [Required]
        public string TienDaTT { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        [ForeignKey("KhachHang_ID")]
        public KhachHang KhachHang { get; set; }
        [ForeignKey("NhanVien_ID")]
        public NhanVien NhanVien { get; set; }
    }
}