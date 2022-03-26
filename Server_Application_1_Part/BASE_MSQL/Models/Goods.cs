using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_MSQL.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Models { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
