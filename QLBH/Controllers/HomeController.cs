using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class HomeController : Controller
    {
        DbConnect db = new DbConnect();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        //Xử lí đăng nhập
        [HttpPost]

        public ActionResult Login(string Email,string matkhau)
        {
            if(ModelState.IsValid)
            {
                var Du_Lieu_Ma_hoa = GetMD5(matkhau);
                var Kiem_Tra_Tai_Khoan = db.KhachHangs.Where(s => s.Email.Equals(Email) && s.MatKhau.Equals(Du_Lieu_Ma_hoa)).ToList();
                if (Kiem_Tra_Tai_Khoan != null)
                {
                    Session["IdKhachHang"] = Kiem_Tra_Tai_Khoan.FirstOrDefault().IdKhachHang;
                    Session["TenKhachHang"] = Kiem_Tra_Tai_Khoan.FirstOrDefault().TenKhachHang;
                    var checkAdmin = Kiem_Tra_Tai_Khoan.FirstOrDefault().role;
                    if(checkAdmin == "admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.LoginError = "ĐĂNG NHẬP KHÔNG THÀNH CÔNG";
                    return RedirectToAction("Login");
                }    
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        //Chức năng đăng ký
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang K)
        {
            if(ModelState.IsValid)
            {
                var CheckEmail = db.KhachHangs.FirstOrDefault(M => M.Email == K.Email);
                if(CheckEmail == null)
                {
                    K.MatKhau = GetMD5(K.MatKhau);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(K);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.EmailError = "EMAIL ĐÃ TỒN TẠI";
                    return RedirectToAction("Register");
                }
            }
            return View();
        }
        //Mã hóa mật khẩu
        public static string GetMD5(string MatKhau)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(MatKhau);
            byte[] targetData = md5.ComputeHash(fromData);
            string Ma_Hoa_Mat_khau = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                Ma_Hoa_Mat_khau += targetData[i].ToString("x2");
            }
            return Ma_Hoa_Mat_khau;
        }

    }
}