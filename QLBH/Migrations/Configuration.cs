namespace QLBH.Migrations
{
    using QLBH.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QLBH.Models.DbConnect>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QLBH.Models.DbConnect context)
        {
            context.KhachHangs.AddOrUpdate
                (K => K.TenKhachHang,
                new KhachHang
                {
                    TenKhachHang = "Anh",
                    DiaChi = "So 24",
                    SDTKh = "0210000000",
                },
                new KhachHang
                {
                    TenKhachHang = "Banh",
                    DiaChi = "So 25",
                    SDTKh = "0210000001",
                },            
                new KhachHang
                {
                    TenKhachHang = "Canh",
                    DiaChi = "So 26",
                    SDTKh = "0210000002",
                }
              );
        }
    }
}
