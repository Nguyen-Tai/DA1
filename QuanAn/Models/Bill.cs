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

        public int Customer_ID { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual Customer Customer { get; set; }

        public int Employee_ID { get; set; }

        [ForeignKey("Employee_ID")]
        public virtual Employee Employee { get; set; }

    }
}
