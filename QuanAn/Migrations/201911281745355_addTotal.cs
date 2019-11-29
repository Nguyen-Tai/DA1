namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill", "Total", c => c.Int(nullable: false));
            Sql(@" Create FUNCTION dbo.TotalByBill
                    (@Bill_ID INT) 
                    RETURNS INT
                    AS
                    BEGIN
	                Declare @total int
	                select @total= Sum(a.Total) from (select 
                        CAST(Food.Price as int)*CAST(Detail.Amount as int) as Total
                        from [dbo].Food,[dbo].Detail,[dbo].Bill
                    where Detail.Bill_ID=Bill.ID and Detail.Food_ID=Food.ID  and Bill.ID=@Bill_ID) a
                    RETURN @total
            END");
            Sql(@"create trigger [dbo].[CapNhatFoodVaoBill]
                ON [dbo].Detail after insert,update as
            begin 
	            Update Bill
	            set Bill.Total= dbo.TotalByBill(inserted.Bill_ID) 
	            from Bill Join inserted on Bill.ID=inserted.Bill_ID
             end");
            Sql(@"create trigger [dbo].[DelFoodKhoaBill]
            ON [dbo].Detail for delete as
            begin 
	        Update Bill
	        set Bill.Total= dbo.TotalByBill(deleted.Bill_ID) 
	        from Bill Join deleted on Bill.ID=deleted.Bill_ID
            end");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bill", "Total");
            Sql("Drop function TotalByBill");
            Sql("Drop trigger DelFoodKhoaBill");
            Sql("Drop trigger CapNhatFoodVaoBill");

        }
    }
}
