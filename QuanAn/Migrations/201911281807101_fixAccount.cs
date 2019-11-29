namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Employee_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Account", "Employee_ID");
            AddForeignKey("dbo.Account", "Employee_ID", "dbo.Employee", "ID", cascadeDelete: true);
            DropColumn("dbo.Account", "Name");
            DropColumn("dbo.Account", "DOB");
            DropColumn("dbo.Account", "Phone");
            DropColumn("dbo.Account", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "Sex", c => c.String());
            AddColumn("dbo.Account", "Phone", c => c.String());
            AddColumn("dbo.Account", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Account", "Name", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Account", "Employee_ID", "dbo.Employee");
            DropIndex("dbo.Account", new[] { "Employee_ID" });
            DropColumn("dbo.Account", "Employee_ID");
        }
    }
}
