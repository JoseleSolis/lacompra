using LaCompra.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaCompra.Infrastructure.Persistence;

public sealed class LaCompraDbContext(DbContextOptions<LaCompraDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<ShoppingItem> ShoppingItems => Set<ShoppingItem>();
    public DbSet<ShoppingItemImage> ShoppingItemImages => Set<ShoppingItemImage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(80).IsRequired();
            entity.HasIndex(x => x.Name).IsUnique();
        });
        modelBuilder.Entity<ShoppingItem>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Description).HasMaxLength(500).IsRequired();
            entity.Property(x => x.Quantity).HasPrecision(10, 3);
            entity.HasMany(x => x.Images).WithOne(x => x.ShoppingItem)
                .HasForeignKey(x => x.ShoppingItemId).OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<ShoppingItemImage>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.RelativePath).HasMaxLength(500).IsRequired();
        });
    }
}
