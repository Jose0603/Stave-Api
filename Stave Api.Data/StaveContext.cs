using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Stave_Api.Data.Models;

namespace Stave_Api.Data;

public partial class StaveContext : DbContext
{
    public StaveContext()
    {
    }

    public StaveContext(DbContextOptions<StaveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF54F2BCED4");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.AdditionalInfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("additional_info");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.MainImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("main_img");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.PartNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("part_number");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__product___DC9AC95510612911");

            entity.ToTable("product_images");

            entity.HasIndex(e => e.ProductId, "idx_product_images_product_id");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.AltText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("alt_text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
