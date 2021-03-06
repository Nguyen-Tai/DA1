﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.Models
{
    [Table("Category")]
    public class Category
    {

        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public static List<Category> GetListCategory()
        {
            using (var ctx = new StoreContext())
            {
                return ctx.Categories.ToList();
            }
        }
    }
}
