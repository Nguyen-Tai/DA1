namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food", "Price", c => c.Single(nullable: false));
        }
    }
}
