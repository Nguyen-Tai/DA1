namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food", "Image", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "Image");
        }
    }
}
