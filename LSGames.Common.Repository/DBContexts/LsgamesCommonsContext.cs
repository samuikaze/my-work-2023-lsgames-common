using System;
using System.Collections.Generic;
using LSGames.Common.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace LSGames.Common.Repository.DBContexts;

public partial class LsgamesCommonsContext : DbContext
{
    public LsgamesCommonsContext(DbContextOptions<LsgamesCommonsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsType> NewsTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPlatform> ProductPlatforms { get; set; }

    public virtual DbSet<ProductPlatformMapper> ProductPlatformMappers { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PRIMARY");

            entity.ToTable("faqs", tb => tb.HasComment("常見問題"));

            entity.Property(e => e.FaqId)
                .HasComment("常見問題 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("faq_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedUserId)
                .HasComment("建立使用者帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("created_user_id");
            entity.Property(e => e.FaqAnswer)
                .HasMaxLength(1024)
                .HasComment("常見問題-解答")
                .HasColumnName("faq_answer");
            entity.Property(e => e.FaqQuestion)
                .HasMaxLength(128)
                .HasComment("常見問題-問題")
                .HasColumnName("faq_question");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedUserId)
                .HasComment("最後更新使用者帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("updated_user_id");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PRIMARY");

            entity.ToTable("news", tb => tb.HasComment("最新消息"));

            entity.HasIndex(e => e.NewsTypeId, "FK_news_types_TO_news");

            entity.Property(e => e.NewsId)
                .HasComment("最新消息 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("news_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedUserId)
                .HasComment("建立帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("created_user_id");
            entity.Property(e => e.DeletedAt)
                .HasComment("刪除時間")
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedUserId)
                .HasComment("刪除帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("deleted_user_id");
            entity.Property(e => e.NewsContent)
                .HasMaxLength(1024)
                .HasComment("最新消息內容")
                .HasColumnName("news_content");
            entity.Property(e => e.NewsTitle)
                .HasMaxLength(20)
                .HasComment("最新消息標題")
                .HasColumnName("news_title");
            entity.Property(e => e.NewsTypeId)
                .HasComment("最新消息種類 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("news_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedUserId)
                .HasComment("最後更新帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("updated_user_id");

            entity.HasOne(d => d.NewsType).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_news_types_TO_news");
        });

        modelBuilder.Entity<NewsType>(entity =>
        {
            entity.HasKey(e => e.NewsTypeId).HasName("PRIMARY");

            entity.ToTable("news_types", tb => tb.HasComment("最新消息種類"));

            entity.Property(e => e.NewsTypeId)
                .HasComment("最新消息種類 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("news_type_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedUserId)
                .HasComment("建立帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("created_user_id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasComment("最新消息種類名稱")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedUserId)
                .HasComment("最後更新帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("updated_user_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products", tb => tb.HasComment("作品一覽"));

            entity.HasIndex(e => e.ProductTypeId, "FK_product_types_TO_products");

            entity.Property(e => e.ProductId)
                .HasComment("作品 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("作品建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .HasComment("作品說明")
                .HasColumnName("description");
            entity.Property(e => e.ProductTitle)
                .HasMaxLength(64)
                .HasComment("作品名稱")
                .HasColumnName("product_title");
            entity.Property(e => e.ProductTypeId)
                .HasComment("作品分類 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_type_id");
            entity.Property(e => e.ProductUrl)
                .HasMaxLength(1024)
                .HasComment("作品連結")
                .HasColumnName("product_url");
            entity.Property(e => e.ReleaseDate)
                .HasComment("作品釋出日期")
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.UpdatedAt)
                .HasComment("作品最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VisualImage)
                .HasMaxLength(96)
                .HasComment("作品視覺圖")
                .HasColumnName("visual_image");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_types_TO_products");
        });

        modelBuilder.Entity<ProductPlatform>(entity =>
        {
            entity.HasKey(e => e.ProductPlatformId).HasName("PRIMARY");

            entity.ToTable("product_platforms", tb => tb.HasComment("作品平台"));

            entity.Property(e => e.ProductPlatformId)
                .HasComment("作品平台 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_platform_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductPlatformName)
                .HasMaxLength(32)
                .HasComment("作品平台名稱")
                .HasColumnName("product_platform_name");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ProductPlatformMapper>(entity =>
        {
            entity.HasKey(e => e.ProductPlatformMapperId).HasName("PRIMARY");

            entity.ToTable("product_platform_mapper", tb => tb.HasComment("作品與平台"));

            entity.HasIndex(e => e.ProductPlatformId, "FK_product_platforms_TO_product_platform_mapper");

            entity.HasIndex(e => e.ProductId, "FK_products_TO_product_platform_mapper");

            entity.Property(e => e.ProductPlatformMapperId)
                .HasComment("作品與平台 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_platform_mapper_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductId)
                .HasComment("作品 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductPlatformId)
                .HasComment("作品平台 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_platform_id");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPlatformMappers)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_TO_product_platform_mapper");

            entity.HasOne(d => d.ProductPlatform).WithMany(p => p.ProductPlatformMappers)
                .HasForeignKey(d => d.ProductPlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_platforms_TO_product_platform_mapper");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PRIMARY");

            entity.ToTable("product_types", tb => tb.HasComment("作品分類"));

            entity.Property(e => e.ProductTypeId)
                .HasComment("作品分類 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("product_type_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("作品分類建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(32)
                .HasComment("作品分類名稱")
                .HasColumnName("product_type_name");
            entity.Property(e => e.UpdatedAt)
                .HasComment("作品分類最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
