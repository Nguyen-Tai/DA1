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
        public int Price { get; set; }

        [DisplayName("ĐVT")]
        [Required]
        [MaxLength(25)]
        public string Unit { get; set; }

        public string Image { get; set; }
        public int Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }


        public void AddData()
        {
            using (var ctx = new StoreContext())
            {
                var food = new Food();
                food.Name = Name;
                food.Unit = Unit;
                food.Price = Price;
                food.Category_ID = Category_ID;
                food.Image = Image;
                ctx.Foods.Add(food);
                ctx.SaveChanges();
            }
        }

        public void Update()
        {
            using (var ctx = new StoreContext())
            {
                var fQuery = (from fd in ctx.Foods
                              where fd.ID == ID
                              select fd).SingleOrDefault();
                if (fQuery != null)
                {
                    fQuery.Name = Name;
                    fQuery.Unit = Unit;
                    fQuery.Price = Price;
                    fQuery.Category_ID = Category_ID;
                    fQuery.Image = Image;
                    ctx.SaveChanges();
                }
            }               
        }

        public void DeleteData()
        {
            using (var ctx = new StoreContext())
            {
                var nvQuery = from fd in ctx.Foods
                              where fd.ID == ID
                              select fd;
                ctx.Foods.RemoveRange(nvQuery);
                ctx.SaveChanges();
            }
        }

        public static List<dynamic> GetFoodByCategory(int CategoryID)
        {
            using (var ctx = new StoreContext())
            {
                var list = (from t in ctx.Foods
                            join p in ctx.Categories on t.Category_ID equals p.ID
                            where t.Category_ID == CategoryID
                            select new
                            {
                                t.ID,
                                t.Name,
                                t.Price,
                                t.Unit,
                                CategoryName = p.Name,
                                t.Image
                            }).Distinct();
                return list.ToList<dynamic>();
            }
        }
    }
}
