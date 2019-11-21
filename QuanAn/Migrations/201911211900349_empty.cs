namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Food", "Category_ID", "dbo.Category");
            DropIndex("dbo.Food", new[] { "Category_ID" });
            AlterColumn("dbo.Food", "Category_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Food", "Category_ID");
            AddForeignKey("dbo.Food", "Category_ID", "dbo.Category", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Food", "Category_ID", "dbo.Category");
            DropIndex("dbo.Food", new[] { "Category_ID" });
            AlterColumn("dbo.Food", "Category_ID", c => c.Int());
            CreateIndex("dbo.Food", "Category_ID");
            AddForeignKey("dbo.Food", "Category_ID", "dbo.Category", "ID");
        }
    }
}
