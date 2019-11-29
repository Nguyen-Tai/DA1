namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.Bill", new[] { "Customer_ID" });
            AlterColumn("dbo.Bill", "Customer_ID", c => c.Int());
            CreateIndex("dbo.Bill", "Customer_ID");
            AddForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.Bill", new[] { "Customer_ID" });
            AlterColumn("dbo.Bill", "Customer_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bill", "Customer_ID");
            AddForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer", "ID", cascadeDelete: true);
        }
    }
}
