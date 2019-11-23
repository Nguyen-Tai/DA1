using QuanAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.BL
{
    class BLBill
    {
        public static int AddBill()
        {
            using (var ctx = new StoreContext())
            {
                var bill = new Bill()
                {
                    BillDate = DateTime.Now,
                    Customer_ID = 1,
                    Employee_ID = 1
                };
                ctx.Bills.Add(bill);
                ctx.SaveChanges();
                return bill.ID;
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
