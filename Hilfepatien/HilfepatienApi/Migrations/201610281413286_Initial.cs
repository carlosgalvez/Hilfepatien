namespace HilfepatienApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicina", "IdProveedor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicina", "IdProveedor", c => c.Int(nullable: false));
        }
    }
}
