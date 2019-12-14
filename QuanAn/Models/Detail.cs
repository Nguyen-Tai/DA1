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
        
        public int Bill_ID { get; set; }

        [ForeignKey("Bill_ID")]
        public virtual Bill Bill { get; set; }

        public int Food_ID { get; set; }

        [ForeignKey("Food_ID")]
        public virtual Food Food { get; set; }

        public static int AddOrUpdateDetail(int IDFood, int IDBill, int SoLuong)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Details.Where(x => x.Food_ID == IDFood).Where(x => x.Bill_ID == IDBill).FirstOrDefault();
                if (dt != null)
                {
                    dt.Amount = SoLuong;
                    ctx.SaveChanges();
                    return dt.ID;
                }
                else
                {
                    var dtAdd = new Detail()
                    {
                        Food_ID = IDFood,
                        Bill_ID = IDBill,
                        Amount = SoLuong
                    };
                    ctx.Details.Add(dtAdd);
                    ctx.SaveChanges();
                    return dtAdd.ID;

                }
            }
        }
        public static void DeleteDetail(int ID_Food, int ID_Bill)
        {
            using (var ctx = new StoreContext())
            {
                var dt = ctx.Details.Where(x => x.Food_ID == ID_Food).Where(x => x.Bill_ID == ID_Bill).FirstOrDefault();
                ctx.Details.Remove(dt);
                ctx.SaveChanges();
            }
        }
    }
}
