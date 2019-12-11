using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Customer")]
    public class Customer : Person
    {
        public int Wallet { get; set; }

        public void AddData()
        {
            using (var ctx = new StoreContext())
            {
                var customer = new Customer();
                customer.Name = Name;
                customer.DOB = DOB;
                customer.Address = Address;
                customer.Phone = Phone;
                customer.Sex = Sex;
                customer.Wallet = Wallet;
                customer.Image = Image;
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }

        public void Update()
        {
            using (var ctx = new StoreContext())
            {
                var khQuery = (from cus in ctx.Customers
                               where cus.ID == ID
                               select cus).SingleOrDefault();
                if (khQuery != null)
                {
                    khQuery.Name = Name;
                    khQuery.DOB = DOB;
                    khQuery.Address = Address;
                    khQuery.Phone = Phone;
                    khQuery.Sex = Sex;
                    khQuery.Wallet = Wallet;
                    khQuery.Image = Image;
                    ctx.SaveChanges();
                }
            }

        }

        public void DeleteData()
        {
            using (var ctx = new StoreContext())
            {
                var nvQuery = from cus in ctx.Customers
                              where cus.ID == ID
                              select cus;
                ctx.Customers.RemoveRange(nvQuery);
                ctx.SaveChanges();
            }

        }
    }
}
