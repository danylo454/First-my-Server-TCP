using BASE_MSQL.Initializer;
using BASE_MSQL.Models;
using Microsoft.EntityFrameworkCore;

class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PFI6MSV\SQLEXPRESS;Database=NP_Base;Integrated Security=True");
        }
    }
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Goods>();
        model.Seed();
    }
    public  DbSet<Goods> Goods { get; set; }
}
