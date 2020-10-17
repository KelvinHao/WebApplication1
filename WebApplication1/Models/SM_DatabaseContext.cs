using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class SM_DatabaseContext : DbContext
    {
        public SM_DatabaseContext()
        {
        }

        public SM_DatabaseContext(DbContextOptions<SM_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBrand> TblBrand { get; set; }
        public virtual DbSet<TblFeedback> TblFeedback { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductDetail> TblProductDetail { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=SM_Database;User ID=sa;Password=hao");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBrand>(entity =>
            {
                entity.Property(e => e.BrandId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblFeedback>(entity =>
            {
                entity.Property(e => e.FeedbackId).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblFeedback)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFeedback_tblProduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblFeedback)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFeedback_tblUser");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProduct_tblBrand");
            });

            modelBuilder.Entity<TblProductDetail>(entity =>
            {
                entity.HasKey(e => e.PrDetailId)
                    .HasName("PK_tblProductDetails");

                entity.Property(e => e.PrDetailId).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProductDetail_tblProduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblProductDetail)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProductDetail_tblUser");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_tblRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
