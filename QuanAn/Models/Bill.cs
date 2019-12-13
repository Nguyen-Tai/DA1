using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public int ID { get; set; }
        public DateTime BillDate { get; set; }

        public int? Total { get; set; }

        public int? Customer_ID { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual Customer Customer { get; set; }

        public int Employee_ID { get; set; }

        [ForeignKey("Employee_ID")]
        public virtual Employee Employee { get; set; }

       public static int AddBill(int EmployeeID)
       {
            using (var ctx = new StoreContext())
            {
                var bill = new Bill()
                {
                    BillDate = DateTime.Now,
                    Employee_ID = EmployeeID,
                    Total = 0,
                };
                ctx.Bills.Add(bill);
                ctx.SaveChanges();
                return bill.ID;
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
        public static int TotalByBill(int Bill_ID)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Bills.Where(x => x.ID == Bill_ID).FirstOrDefault();
                if (dt.Total == null) return 0;
                return dt.Total.GetValueOrDefault();
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
        public static void DeleteDetail(int ID_Food, int ID_Bill)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Details.Where(x => x.Food_ID == ID_Food).Where(x => x.Bill_ID == ID_Bill).FirstOrDefault();
                ctx.Details.Remove(dt);
                ctx.SaveChanges();
            }
        }
        public static int AddOrUpdateDetail(int IDFood, int IDBill, int SoLuong)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Details.Where(x => x.Food_ID == IDFood).Where(x => x.Bill_ID == IDBill).FirstOrDefault();
                if (dt != null)
                {
                    dt.Amount = SoLuong;
                    ctx.SaveChanges();
                    return dt.ID;
                }
                else
                {
                    var dtAdd = new Detail()
                    {
                        Food_ID = IDFood,
                        Bill_ID = IDBill,
                        Amount = SoLuong
                    };
                    ctx.Details.Add(dtAdd);
                    ctx.SaveChanges();
                    return dtAdd.ID;

                }
            }
        }
        public static List<dynamic> LietKe(DateTime start, DateTime end)
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
        public static int? ThongKe(DateTime start, DateTime end)
        {
            using (var ctx = new StoreContext())
            {
                var total = ctx.Bills.Where(t => t.BillDate >= start).Where(t => t.BillDate <= end).Sum(t => t.Total);
                return total;
            }
        }
        public static void AddCustomerToBill(int CustomerID, int Bill_ID)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Bills.Where(x => x.ID == Bill_ID).FirstOrDefault();
                if (dt != null)
                {
                    dt.Customer_ID = CustomerID;
                    ctx.SaveChanges();
                }
            }
        }
        public static void ThanhToan(int ToTal, int Customer_ID)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Customers.Where(x => x.ID == Customer_ID).FirstOrDefault();
                if (dt != null)
                {
                    dt.Wallet = dt.Wallet - ToTal;
                    ctx.SaveChanges();
                }
            }
        }

    }
}
