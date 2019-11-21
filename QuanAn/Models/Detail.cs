using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Detail")]
    public class Detail
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        
        public virtual Bill Bill { get; set; }
        
        public virtual Food Food { get; set; }
    }
}
