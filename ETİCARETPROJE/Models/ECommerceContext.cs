using Microsoft.EntityFrameworkCore;

namespace ETİCARETPROJE.Models
{
    // Veritabanı bağlantısını sağlayacak sınıf
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedDate)
                .HasColumnType("datetime2"); // Sütun tipi güncelleniyor

            // Diğer model yapılandırmaları burada yer alabilir
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // Diğer yapılandırmalar
        }
    }
}
