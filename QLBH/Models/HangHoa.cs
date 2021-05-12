using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class HangHoa
    {
        [Key]
        public int IDHangHoa { get; set; }
        public int LoaiHang_ID { get; set; }
        //[ForeignKey("LoaiHang_ID")]
        //public LoaiHang LoaiHang { get; set; }
        [Required]
        public string TenHang { get; set; }
        public int TongSoLuongHangTon { get; set; }
        public string DacDiem { get; set; }
        [Required]
        public int GiaNhap { get; set; }
        [Required]
        public int GiaBan { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        [ForeignKey("LoaiHang_ID")]
        public LoaiHang LoaiHang { get; set; }
    }
}