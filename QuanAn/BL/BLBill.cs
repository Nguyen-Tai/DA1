using QuanAn.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.BL
{
    class BLBill
    {

        public static int AddBill(int EmployeeID)
        {
            using (var ctx = new StoreContext())
            {
                var bill = new Bill()
                {
                    BillDate = DateTime.Now,
                    Employee_ID = EmployeeID,
                    Total = 0,
                   // Customer_ID = 1
                };
                ctx.Bills.Add(bill);
                ctx.SaveChanges();
                return bill.ID;
            }
        }
        public static List<dynamic> LietKe(DateTime start,DateTime end)
        {
            using (var ctx = new StoreContext())
            {
                var list = (from b in ctx.Bills
                           join nv in ctx.Employees on b.Employee_ID equals nv.ID
                            where b.BillDate >= start && b.BillDate <= end
                            select new
                           {
                                b.ID,
                                b.BillDate,
                                nv.Name,
                                b.Total
                            }).Distinct();
                return list.ToList<dynamic>();
            }
        }
        public static int? ThongKe(DateTime start,DateTime end)
        {
            using (var ctx = new StoreContext())
            {      
                var total = ctx.Bills.Where(t => t.BillDate >= start ).Where(t => t.BillDate <= end).Sum(t => t.Total);
                return total;
            }
        }

        public static void DeleteBillIfNotExist(int ID_Bill)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Details.Where(x => x.Bill_ID == ID_Bill).FirstOrDefault();
                if (dt == null)
                {
                    var bill = ctx.Bills.FirstOrDefault(x => x.ID == ID_Bill);
                    ctx.Bills.Remove(bill);
                    ctx.SaveChanges();
                }
            }
        }
        public static List<dynamic> GetBill(int ID_Bill)
        {
            using (var ctx = new StoreContext())
            {
               
                    var list = (from dt in ctx.Details.AsEnumerable()
                                join b in ctx.Bills on dt.Bill_ID equals b.ID
                                join f in ctx.Foods.AsEnumerable() on dt.Food_ID equals f.ID
                                where b.ID == ID_Bill
                                select new
                                {
                                    f.Name,
                                    f.Unit,
                                    f.Price,
                                    dt.Amount,
                                    Total = Convert.ToInt32(f.Price) * Convert.ToInt32(dt.Amount)
                                }).Distinct();
                    return list.ToList<dynamic>();            
            }
        } 
    }
}
