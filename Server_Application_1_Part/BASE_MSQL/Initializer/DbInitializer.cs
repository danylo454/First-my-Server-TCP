using BASE_MSQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_MSQL.Initializer
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().HasData(
                new Goods
                {
                    Id = 1,
                    Name = "Processor",
                    Models = "Intel Core I5",
                    Count = 6,
                    Price = 5120
                },
                 new Goods
                 {
                     Id = 2,
                     Name = "Processor",
                     Models = "Intel Core I7",
                     Count = 10,
                     Price = 9120
                 },
                 new Goods
                 {
                     Id = 3,
                     Name = "Processor",
                     Models = "Intel Core I8",
                     Count = 12,
                     Price = 11120
                 },
                   new Goods
                   {
                       Id = 4,
                       Name = "Processor",
                       Models = "Intel Core I9",
                       Count = 3,
                       Price = 13120
                   },
                    new Goods
                    {
                        Id = 5,
                        Name = "Processor",
                        Models = "AMD Ryzen 7",
                        Count = 5,
                        Price = 14134
                    },
                     new Goods
                     {
                         Id = 6,
                         Name = "Processor",
                         Models = "AMD Ryzen 5",
                         Count = 61,
                         Price = 10378
                     }
                );

        }
    }
}
