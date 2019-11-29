namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullToTal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bill", "Total", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bill", "Total", c => c.Int(nullable: false));
        }
    }
}
