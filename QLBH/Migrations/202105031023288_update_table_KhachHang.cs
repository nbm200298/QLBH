namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_KhachHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "Email", c => c.String(nullable: false));
            AddColumn("dbo.KhachHangs", "MatKhau", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "TaiKhoan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "TaiKhoan", c => c.Int(nullable: false));
            DropColumn("dbo.KhachHangs", "MatKhau");
            DropColumn("dbo.KhachHangs", "Email");
        }
    }
}
