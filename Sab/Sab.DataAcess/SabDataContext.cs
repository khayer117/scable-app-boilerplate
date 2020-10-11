using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sab.Domain.Product;

namespace Sab.DataAcess
{
    public class SabDataContext : DbContext
    {
        public SabDataContext(DbContextOptions<SabDataContext> options) : base(options)
        { 
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagProduct> TagProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Course>().ToTable("Course");

            modelBuilder.Entity<TagProduct>()
                .HasKey(tp => new { tp.ProductId, tp.TagId });

            modelBuilder.Entity<TagProduct>()
                .HasOne(tp => tp.Product)
                .WithMany(tp => tp.TagProducts)
                .HasForeignKey(tp => tp.ProductId);

            modelBuilder.Entity<TagProduct>()
                .HasOne(tp => tp.Tag)
                .WithMany(tp => tp.TagProducts)
                .HasForeignKey(tp => tp.TagId);
        }

    }
}

