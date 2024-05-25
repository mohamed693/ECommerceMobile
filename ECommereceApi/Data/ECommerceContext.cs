﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ECommereceApi.Models;
namespace ECommereceApi.Data;

public partial class ECommerceContext : DbContext
{
    public ECommerceContext()
    {
    }

    public ECommerceContext(DbContextOptions<ECommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<NotificationMessage> NotificationMessages { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCart> ProductCarts { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductOffer> ProductOffers { get; set; }

    public virtual DbSet<ProductSubCategory> ProductSubCategories { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }
    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WebInfo> Web_Infos { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_User");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasMany(d => d.Subs).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategorySubCategory",
                    r => r.HasOne<SubCategory>().WithMany()
                        .HasForeignKey("SubId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CategorySubCategory_SubCategory"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CategorySubCategory_Category"),
                    j =>
                    {
                        j.HasKey("CategoryId", "SubId");
                        j.ToTable("CategorySubCategory");
                        j.HasIndex(new[] { "SubId" }, "IX_CategorySubCategory_SubId");
                    });
        });
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_User");
        });

        modelBuilder.Entity<NotificationMessage>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.NotificationMessages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationMessage_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            modelBuilder.Entity<WishList>()
                .HasKey(wl => new { wl.UserId, wl.ProductId });


            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

        });

        modelBuilder.Entity<ProductCart>(entity =>
        {
            entity.Property(e => e.ProductAmount).HasDefaultValue(1);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCarts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCart_Product1");

            entity.HasOne(d => d.User).WithMany(p => p.ProductCarts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCart_User");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Product");
        });

        modelBuilder.Entity<ProductOffer>(entity =>
        {
            entity.HasOne(d => d.Offer).WithMany(p => p.ProductOffers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductOffer_Offer");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductOffers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductOffer_Product");
        });

        modelBuilder.Entity<ProductSubCategory>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.ProductSubCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSubCategory_Product");

            entity.HasOne(d => d.Sub).WithMany(p => p.ProductSubCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSubCategory_SubCategory");
        });
        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rates_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rates_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}