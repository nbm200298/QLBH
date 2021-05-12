using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH.Models;

namespace QLBH.Areas.Admin.Controllers
{
    public class HangHoasController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/HangHoas
        public ActionResult Index()
        {
            var hangHoas = db.HangHoas.Include(h => h.LoaiHang);
            return View(hangHoas.ToList());
        }

        // GET: Admin/HangHoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Create
        public ActionResult Create()
        {
            ViewBag.LoaiHang_ID = new SelectList(db.LoaiHangs, "IDLoaiHang", "TenLoaiHang");
            return View();
        }

        // POST: Admin/HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHangHoa,LoaiHang_ID,TenHang,TongSoLuongHangTon,DacDiem,GiaNhap,GiaBan")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiHang_ID = new SelectList(db.LoaiHangs, "IDLoaiHang", "TenLoaiHang", hangHoa.LoaiHang_ID);
            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiHang_ID = new SelectList(db.LoaiHangs, "IDLoaiHang", "TenLoaiHang", hangHoa.LoaiHang_ID);
            return View(hangHoa);
        }

        // POST: Admin/HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHangHoa,LoaiHang_ID,TenHang,TongSoLuongHangTon,DacDiem,GiaNhap,GiaBan")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiHang_ID = new SelectList(db.LoaiHangs, "IDLoaiHang", "TenLoaiHang", hangHoa.LoaiHang_ID);
            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: Admin/HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
