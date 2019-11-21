using QuanAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanAn.BL
{
    class BLMenu
    {
        public static List<dynamic> GetFoodByCategory(int CategoryID)
        {
            using (var ctx = new StoreContext())
            {
                var list = (from t in ctx.Foods
                                         join p in ctx.Categories on t.Category_ID equals p.ID                                       
                                         where t.Category_ID == CategoryID
                                         select new
                                         {
                                             t.ID ,
                                             t.Name,
                                             t.Price,
                                             t.Unit,
                                             CategoryName=p.Name                                          
                                         }).Distinct();
                return list.ToList<dynamic>();
            }
        }
        public static List<Category> GetListCategory()
        {
            using (var ctx = new StoreContext())
            {              
                return ctx.Categories.ToList();
            }
        }

    }
}
