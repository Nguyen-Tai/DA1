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
        
    }
}
