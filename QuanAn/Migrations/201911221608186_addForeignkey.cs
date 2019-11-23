namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer");
            DropForeignKey("dbo.Bill", "Employee_ID", "dbo.Employee");
            DropForeignKey("dbo.Detail", "Bill_ID", "dbo.Bill");
            DropForeignKey("dbo.Detail", "Food_ID", "dbo.Food");
            DropIndex("dbo.Bill", new[] { "Customer_ID" });
            DropIndex("dbo.Bill", new[] { "Employee_ID" });
            DropIndex("dbo.Detail", new[] { "Bill_ID" });
            DropIndex("dbo.Detail", new[] { "Food_ID" });
            AlterColumn("dbo.Bill", "Customer_ID", c => c.Int(nullable: true));
            AlterColumn("dbo.Bill", "Employee_ID", c => c.Int(nullable: true));
            AlterColumn("dbo.Detail", "Bill_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Detail", "Food_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bill", "Customer_ID");
            CreateIndex("dbo.Bill", "Employee_ID");
            CreateIndex("dbo.Detail", "Bill_ID");
            CreateIndex("dbo.Detail", "Food_ID");
            AddForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Bill", "Employee_ID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Detail", "Bill_ID", "dbo.Bill", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Detail", "Food_ID", "dbo.Food", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detail", "Food_ID", "dbo.Food");
            DropForeignKey("dbo.Detail", "Bill_ID", "dbo.Bill");
            DropForeignKey("dbo.Bill", "Employee_ID", "dbo.Employee");
            DropForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.Detail", new[] { "Food_ID" });
            DropIndex("dbo.Detail", new[] { "Bill_ID" });
            DropIndex("dbo.Bill", new[] { "Employee_ID" });
            DropIndex("dbo.Bill", new[] { "Customer_ID" });
            AlterColumn("dbo.Detail", "Food_ID", c => c.Int());
            AlterColumn("dbo.Detail", "Bill_ID", c => c.Int());
            AlterColumn("dbo.Bill", "Employee_ID", c => c.Int());
            AlterColumn("dbo.Bill", "Customer_ID", c => c.Int());
            CreateIndex("dbo.Detail", "Food_ID");
            CreateIndex("dbo.Detail", "Bill_ID");
            CreateIndex("dbo.Bill", "Employee_ID");
            CreateIndex("dbo.Bill", "Customer_ID");
            AddForeignKey("dbo.Detail", "Food_ID", "dbo.Food", "ID");
            AddForeignKey("dbo.Detail", "Bill_ID", "dbo.Bill", "ID");
            AddForeignKey("dbo.Bill", "Employee_ID", "dbo.Employee", "ID");
            AddForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer", "ID");
        }
    }
}
