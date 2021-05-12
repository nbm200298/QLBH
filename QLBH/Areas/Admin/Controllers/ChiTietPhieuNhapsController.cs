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
    public class ChiTietPhieuNhapsController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/ChiTietPhieuNhaps
        public ActionResult Index()
        {
            var chiTietPhieuNhaps = db.ChiTietPhieuNhaps.Include(c => c.Hanghoa).Include(c => c.PhieuNhaps);
            return View(chiTietPhieuNhaps.ToList());
        }

        // GET: Admin/ChiTietPhieuNhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhap);
        }

        // GET: Admin/ChiTietPhieuNhaps/Create
        public ActionResult Create()
        {
            ViewBag.HangHoa_ID = new SelectList(db.HangHoas, "IDHangHoa", "TenHang");
            ViewBag.PhieuNhap_ID = new SelectList(db.PhieuNhaps, "IDPhieuNhap", "LyDoNhap");
            return View();
        }

        // POST: Admin/ChiTietPhieuNhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChiTietPhieuNhap,PhieuNhap_ID,HangHoa_ID,TongSoLuongNhap,ThueSuat,GiaNhap")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HangHoa_ID = new SelectList(db.HangHoas, "IDHangHoa", "TenHang", chiTietPhieuNhap.HangHoa_ID);
            ViewBag.PhieuNhap_ID = new SelectList(db.PhieuNhaps, "IDPhieuNhap", "LyDoNhap", chiTietPhieuNhap.PhieuNhap_ID);
            return View(chiTietPhieuNhap);
        }

        // GET: Admin/ChiTietPhieuNhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.HangHoa_ID = new SelectList(db.HangHoas, "IDHangHoa", "TenHang", chiTietPhieuNhap.HangHoa_ID);
            ViewBag.PhieuNhap_ID = new SelectList(db.PhieuNhaps, "IDPhieuNhap", "LyDoNhap", chiTietPhieuNhap.PhieuNhap_ID);
            return View(chiTietPhieuNhap);
        }

        // POST: Admin/ChiTietPhieuNhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChiTietPhieuNhap,PhieuNhap_ID,HangHoa_ID,TongSoLuongNhap,ThueSuat,GiaNhap")] ChiTietPhieuNhap chiTietPhieuNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HangHoa_ID = new SelectList(db.HangHoas, "IDHangHoa", "TenHang", chiTietPhieuNhap.HangHoa_ID);
            ViewBag.PhieuNhap_ID = new SelectList(db.PhieuNhaps, "IDPhieuNhap", "LyDoNhap", chiTietPhieuNhap.PhieuNhap_ID);
            return View(chiTietPhieuNhap);
        }

        // GET: Admin/ChiTietPhieuNhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            if (chiTietPhieuNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhap);
        }

        // POST: Admin/ChiTietPhieuNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = db.ChiTietPhieuNhaps.Find(id);
            db.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
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
