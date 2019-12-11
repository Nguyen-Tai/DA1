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

    }
}
