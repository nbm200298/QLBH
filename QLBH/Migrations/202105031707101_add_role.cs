namespace QLBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHangs", "role");
        }
    }
}
