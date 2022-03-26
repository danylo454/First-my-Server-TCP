using BASE_MSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_MSQL.Classes
{
    public class GoodsRepository
    {
        public void AddGoods(Goods goods)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Goods.Add(goods);
                context.SaveChanges();
            }
        }
        public static List<Goods> GetAllGoods()
        {
            using (AppDbContext context = new AppDbContext())
            {
                List<Goods> goods = context.Goods.ToList();
                return goods;
            }
        }
    }
}
