using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Wallet
{
    public partial class mainContext : DbContext
    {
        public mainContext()
        {
        }

        public mainContext(DbContextOptions<mainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Operation> Operations { get; set; } = null!;
        public virtual DbSet<WalletDb> WalletDbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=E:\\VSProjects\\Wallet\\main.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operations");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Summ).HasColumnName("summ");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Vid).HasColumnName("vid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<WalletDb>(entity =>
            {
                entity.ToTable("wallet_db");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
