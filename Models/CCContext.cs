using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CannabisChoice.Models
{
    public partial class CCContext : DbContext
    {
        public CCContext()
        {
        }

        public CCContext(DbContextOptions<CCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<StrainInfo> StrainInfo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ANDREDELL\\SQLSERVER2019;Initial Catalog=CC;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Strain)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.StrainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_StrainInfo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Review_Users");
            });

            modelBuilder.Entity<StrainInfo>(entity =>
            {
                entity.Property(e => e.Terpenes).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
