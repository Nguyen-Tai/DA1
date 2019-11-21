using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Employee")]
    public class Employee : Person
    {
        public DateTime HireDate { get; set; }
        
    }
}
