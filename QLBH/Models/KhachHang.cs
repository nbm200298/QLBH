using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required, EmailAddress]
        public string Email { get; set; }
        public string role { get; set; }
        [Required]
        public string MatKhau { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("MatKhau")]
        public string Confirm_MatKhau { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}