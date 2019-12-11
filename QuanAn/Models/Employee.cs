using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Employee")]
    public class Employee : Person
    {
        public DateTime HireDate { get; set; }
        public void AddData()
        {
            using (var ctx = new StoreContext())
            {
                var employee = new Employee();
                employee.Name = Name;
                employee.DOB = DOB;
                employee.Address = Address;
                employee.Phone = Phone;
                employee.Sex = Sex;
                employee.HireDate = HireDate;
                employee.Image = Image;
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
            }
        }

        public void Update()
        {
            using (var ctx = new StoreContext())
            {
                var khQuery = (from emp in ctx.Employees
                               where emp.ID == ID
                               select emp).SingleOrDefault();
                if (khQuery != null)
                {
                    khQuery.Name = Name;
                    khQuery.DOB = DOB;
                    khQuery.Address = Address;
                    khQuery.Phone = Phone;
                    khQuery.Sex = Sex;
                    khQuery.HireDate = HireDate;
                    khQuery.Image = Image;
                    ctx.SaveChanges();
                }
            }
                
        }

        public void DeleteData()
        {
            using (var ctx = new StoreContext())
            {
                var nvQuery = from emp in ctx.Employees
                              where emp.ID == ID
                              select emp;
                ctx.Employees.RemoveRange(nvQuery);
                ctx.SaveChanges();
            }
               
        }


        
    }
}
