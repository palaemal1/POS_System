using Microsoft.EntityFrameworkCore;
using Model.Entities;
namespace Model
{
    public partial class DataContent:DbContext
    {
        public DataContent(DbContextOptions<DataContent> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Product> Product { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<InventoryTransactions> InventoryTransactions { get; set; }

    }
}
