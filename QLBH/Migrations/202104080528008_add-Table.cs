namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        IDChiTietHoaDon = c.Int(nullable: false, identity: true),
                        HoaDon_ID = c.Int(nullable: false),
                        HangHoa_ID = c.Int(nullable: false),
                        TongSoLuongBan = c.Int(nullable: false),
                        GiaBan = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDChiTietHoaDon)
                .ForeignKey("dbo.HangHoas", t => t.HangHoa_ID, cascadeDelete: true)
                .ForeignKey("dbo.HoaDons", t => t.HoaDon_ID, cascadeDelete: true)
                .Index(t => t.HoaDon_ID)
                .Index(t => t.HangHoa_ID);
            
            CreateTable(
                "dbo.HangHoas",
                c => new
                    {
                        IDHangHoa = c.Int(nullable: false, identity: true),
                        LoaiHang_ID = c.Int(nullable: false),
                        TenHang = c.String(nullable: false),
                        TongSoLuongHangTon = c.Int(nullable: false),
                        DacDiem = c.String(),
                        GiaNhap = c.Int(nullable: false),
                        GiaBan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDHangHoa)
                .ForeignKey("dbo.LoaiHangs", t => t.LoaiHang_ID, cascadeDelete: true)
                .Index(t => t.LoaiHang_ID);
            
            CreateTable(
                "dbo.ChiTietPhieuNhaps",
                c => new
                    {
                        IDChiTietPhieuNhap = c.Int(nullable: false, identity: true),
                        PhieuNhap_ID = c.Int(nullable: false),
                        HangHoa_ID = c.Int(nullable: false),
                        TongSoLuongNhap = c.Int(nullable: false),
                        ThueSuat = c.Int(nullable: false),
                        GiaNhap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDChiTietPhieuNhap)
                .ForeignKey("dbo.HangHoas", t => t.HangHoa_ID, cascadeDelete: true)
                .ForeignKey("dbo.PhieuNhaps", t => t.PhieuNhap_ID, cascadeDelete: true)
                .Index(t => t.PhieuNhap_ID)
                .Index(t => t.HangHoa_ID);
            
            CreateTable(
                "dbo.PhieuNhaps",
                c => new
                    {
                        IDPhieuNhap = c.Int(nullable: false, identity: true),
                        NgayNhap = c.Int(nullable: false),
                        NCC_ID = c.Int(nullable: false),
                        NhanVien_ID = c.Int(nullable: false),
                        LyDoNhap = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDPhieuNhap)
                .ForeignKey("dbo.NhaCungCaps", t => t.NCC_ID, cascadeDelete: true)
                .ForeignKey("dbo.NhanViens", t => t.NhanVien_ID, cascadeDelete: true)
                .Index(t => t.NCC_ID)
                .Index(t => t.NhanVien_ID);
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        IDNCC = c.Int(nullable: false, identity: true),
                        TenNCC = c.String(nullable: false),
                        DiaChi = c.String(),
                        SDTNcc = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.IDNCC);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        IdKhachHang = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 50),
                        SDTKh = c.String(nullable: false, maxLength: 10),
                        TaiKhoan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdKhachHang);
            
            CreateTable(
                "dbo.LoaiHangs",
                c => new
                    {
                        IDLoaiHang = c.Int(nullable: false, identity: true),
                        TenLoaiHang = c.String(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiHang);
            
            AddColumn("dbo.NhanViens", "SDTNv", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.HoaDons", "NgayLap", c => c.String(nullable: false));
            AlterColumn("dbo.HoaDons", "TienDaTT", c => c.String(nullable: false));
            CreateIndex("dbo.HoaDons", "KhachHang_ID");
            AddForeignKey("dbo.HoaDons", "KhachHang_ID", "dbo.KhachHangs", "IdKhachHang", cascadeDelete: true);
            DropColumn("dbo.NhanViens", "SDT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanViens", "SDT", c => c.String(nullable: false, maxLength: 10));
            DropForeignKey("dbo.HangHoas", "LoaiHang_ID", "dbo.LoaiHangs");
            DropForeignKey("dbo.PhieuNhaps", "NhanVien_ID", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "KhachHang_ID", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietHoaDons", "HoaDon_ID", "dbo.HoaDons");
            DropForeignKey("dbo.PhieuNhaps", "NCC_ID", "dbo.NhaCungCaps");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "PhieuNhap_ID", "dbo.PhieuNhaps");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "HangHoa_ID", "dbo.HangHoas");
            DropForeignKey("dbo.ChiTietHoaDons", "HangHoa_ID", "dbo.HangHoas");
            DropIndex("dbo.HoaDons", new[] { "KhachHang_ID" });
            DropIndex("dbo.PhieuNhaps", new[] { "NhanVien_ID" });
            DropIndex("dbo.PhieuNhaps", new[] { "NCC_ID" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "HangHoa_ID" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "PhieuNhap_ID" });
            DropIndex("dbo.HangHoas", new[] { "LoaiHang_ID" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "HangHoa_ID" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "HoaDon_ID" });
            AlterColumn("dbo.HoaDons", "TienDaTT", c => c.String());
            AlterColumn("dbo.HoaDons", "NgayLap", c => c.String());
            DropColumn("dbo.NhanViens", "SDTNv");
            DropTable("dbo.LoaiHangs");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.PhieuNhaps");
            DropTable("dbo.ChiTietPhieuNhaps");
            DropTable("dbo.HangHoas");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
