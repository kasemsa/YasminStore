using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasminStore.Domain.Entities;

namespace YasminStore.Persistence
{
    public class YasminStoreDbContext : DbContext
    {
        public YasminStoreDbContext(DbContextOptions<YasminStoreDbContext> options)
            : base(options) { }

        // تعريف الجداول
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StoreCategory> StoreCategory { get; set; }
        public DbSet<StoreImages> StoreImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }




        // لو أضفت كائن User لاحقًا
        // public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // يمكن إضافة Fluent API هنا لو أردت تخصيص الجداول


            modelBuilder.Entity<StoreCategory>()
                .HasKey(sc => new { sc.StoreId, sc.CategoryId });

            modelBuilder.Entity<StoreCategory>()
                .HasOne(sc => sc.Store)
                .WithMany(s => s.StoreCategories)
                .HasForeignKey(sc => sc.StoreId);

            modelBuilder.Entity<StoreCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.StoreCategories)
                .HasForeignKey(sc => sc.CategoryId);



            // UserRole composite key إذا أردت
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.userRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.userRoles)
                .HasForeignKey(ur => ur.RoleId);


            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // مهم جداً

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
