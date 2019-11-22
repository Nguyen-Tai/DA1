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

        [DisplayName("Họ tên")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
    }
}
