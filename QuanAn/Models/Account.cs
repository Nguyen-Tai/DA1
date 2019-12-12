using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public int Employee_ID { get; set; }

        [ForeignKey("Employee_ID")]
        public virtual Employee Employee { get; set; }

        public bool IsUser(ref int EmployeeID)
        {
            using (var ctx = new StoreContext())
            {
                var q = (from p in ctx.Accounts
                         where p.Username == Username
                         && p.Password == Password && p.IsAdmin == IsAdmin
                         select p).SingleOrDefault();
                if (q != null)
                {
                    EmployeeID = q.Employee_ID;
                    return true;
                }
                else return false;
            }
            
        }

        public void AddData()
        {
            using (var ctx = new StoreContext())
            {
                var account = new Account();
                account.Username = Username;
                account.Password = Password;
                account.IsAdmin = IsAdmin;
                account.Employee_ID = Employee_ID;
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
            }
        }

        public void Update()
        {
            using (var ctx = new StoreContext())
            {
                var khQuery = (from ac in ctx.Accounts
                               where ac.Username == Username
                               select ac).SingleOrDefault();
                if (khQuery != null)
                {

                    khQuery.IsAdmin = IsAdmin;
                    ctx.SaveChanges();
                }
            }
                

        }

        public void DeleteData()
        {
            using (var ctx = new StoreContext())
            {
                var nvQuery = from ac in ctx.Accounts
                              where ac.Username == Username
                              select ac;
                ctx.Accounts.RemoveRange(nvQuery);
                ctx.SaveChanges();
            }

        }

    }
}
