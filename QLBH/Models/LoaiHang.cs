using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class LoaiHang
    {
        [Key]
        public int IDLoaiHang { get; set; }
        [Required, MinLength(10)]
        public string TenLoaiHang { get; set; }
        public string GhiChu { get; set; }
        public ICollection<HangHoa> HangHoas { get; set; }

    }
}