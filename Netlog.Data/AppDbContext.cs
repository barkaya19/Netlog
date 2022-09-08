using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Netlog.Data.Entities;

//namespace Netlog.Data
//{
//    public class AppDbContext:DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {

//        }

//        public DbSet<Delivery> Deliverys { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<Product> Products { get; set; }
//    }
//}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-TS4E8J1;Initial Catalog=NetlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        return new AppDbContext(optionsBuilder.Options);
    }
}

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Delivery> Deliverys { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
}

