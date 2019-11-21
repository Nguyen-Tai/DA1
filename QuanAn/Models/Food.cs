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
    [Table("Food")]
    public class Food
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Họ tên")]
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [DisplayName("Đơn giá")]
        [Required]
        public float Price { get; set; }

        [DisplayName("ĐVT")]
        [Required]
        [MaxLength(25)]
        public string Unit { get; set; }      
        public virtual Category Category { get; set; }
    }
}
