namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        Customer_ID = c.Int(),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Customer_ID)
                .ForeignKey("dbo.Employee", t => t.Employee_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Wallet = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 25),
                        Sex = c.String(nullable: false, maxLength: 3),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 25),
                        Sex = c.String(nullable: false, maxLength: 3),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Detail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Bill_ID = c.Int(),
                        Food_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bill", t => t.Bill_ID)
                .ForeignKey("dbo.Food", t => t.Food_ID)
                .Index(t => t.Bill_ID)
                .Index(t => t.Food_ID);
           
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Price = c.Single(nullable: false),
                        Unit = c.String(nullable: false, maxLength: 25),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detail", "Food_ID", "dbo.Food");
            DropForeignKey("dbo.Food", "Category_ID", "dbo.Category");
            DropForeignKey("dbo.Detail", "Bill_ID", "dbo.Bill");
            DropForeignKey("dbo.Bill", "Employee_ID", "dbo.Employee");
            DropForeignKey("dbo.Bill", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.Food", new[] { "Category_ID" });
            DropIndex("dbo.Detail", new[] { "Food_ID" });
            DropIndex("dbo.Detail", new[] { "Bill_ID" });
            DropIndex("dbo.Bill", new[] { "Employee_ID" });
            DropIndex("dbo.Bill", new[] { "Customer_ID" });
            DropTable("dbo.Food");
            DropTable("dbo.Detail");
            DropTable("dbo.Category");
            DropTable("dbo.Employee");
            DropTable("dbo.Customer");
            DropTable("dbo.Bill");
            DropTable("dbo.Account");
        }
    }
}
