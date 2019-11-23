namespace QuanAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreProc : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
           "dbo.Report",
            p => new
            {
                ID_Bill = p.Int(),
            },
           body:
               @"select Food.Name,Food.Unit,Food.Price, Detail.Amount, 
                CAST(Food.Price as int)*CAST(Detail.Amount as int) as Total, Bill.BillDate, Bill.ID ,Employee.Name as [Employee],Customer.Name as[Customer]
                from [dbo].Food,[dbo].Detail,[dbo].Bill,[dbo].Employee,[dbo].Customer
                where Detail.Bill_ID=Bill.ID and Detail.Food_ID=Food.ID and Bill.Customer_ID=Customer.ID and Bill.Employee_ID=Employee.ID and Bill.ID=@ID_Bill"
           );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Report");
        }
    }
}
