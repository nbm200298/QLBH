using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int IDChiTietHoaDon { get; set; }
        public int HoaDon_ID { get; set; }
        //[ForeignKey("HoaDon_ID")]
        //public HoaDon HoaDon { get; set; }

        public int HangHoa_ID { get; set; }
        //[ForeignKey("HangHoa_ID")]
        //public HangHoa HangHoa { get; set; }
        public int TongSoLuongBan { get; set; }
        [Required]
        public int GiaBan { get; set; }
        [Required]
        public int ThanhTien { get; set; }
        [ForeignKey("HoaDon_ID")]
        public HoaDon HoaDon { get; set; }
        [ForeignKey("HangHoa_ID")]
        public HangHoa HangHoa { get; set; }
    }
}