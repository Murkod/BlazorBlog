using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Blog.Server.Models;

namespace Blog.Server.Context
{
    public partial class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("BlogDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Author>(entity =>
                {
                    entity.HasKey(e => e.AuthorID);
                    entity.Property(e => e.AuthorID).ValueGeneratedOnAdd();
                    entity.Property(e => e.Login).HasMaxLength(50).IsRequired();
                    entity.Property(e => e.PasswordHash).HasMaxLength(100).IsRequired();
                    entity.Property(e => e.AddTime).HasColumnType("datetime");
                    entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                    entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                    entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                });

                modelBuilder.Entity<Category>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<Post>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Description).HasMaxLength(200).IsRequired();
                    entity.Property(e => e.Title).HasMaxLength(200).IsRequired();
                    entity.Property(e => e.Date).HasColumnType("datetime");
                    entity.Property(e => e.Content).HasMaxLength(4000).IsRequired();
                    entity.Property(e => e.Image).HasMaxLength(500).IsRequired();

                    entity.HasOne(e => e.Author)
                        .WithMany()
                        .HasForeignKey(e => e.AuthorID)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Post_Author_AuthorID");

                    entity.HasOne(e => e.Category)
                        .WithMany()
                        .HasForeignKey(e => e.CategoryID)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Post_Category_CategoryID");
                });

            }
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

