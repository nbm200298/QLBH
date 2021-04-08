using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int IDChiTietPhieuNhap { get; set; }
        public int PhieuNhap_ID { get; set; }
        [ForeignKey("PhieuNhap_ID")]
        public PhieuNhap PhieuNhaps { get; set; }
        public int HangHoa_ID { get; set; }
        //[ForeignKey("HangHoa_ID")]
        //public HangHoa Hanghoa { get; set; }
        [Required, MinLength(10)]
        public int TongSoLuongNhap { get; set; }
        public int ThueSuat { get; set; }
        [Required]
        public int GiaNhap { get; set; }
        [ForeignKey("HangHoa_ID")]
        public HangHoa Hanghoa { get; set; }
    }
}