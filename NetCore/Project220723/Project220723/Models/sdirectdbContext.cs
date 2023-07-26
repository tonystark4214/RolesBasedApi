using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project220723.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PraveenActivity> PraveenActivities { get; set; } = null!;
        public virtual DbSet<PraveenLoginCredential> PraveenLoginCredentials { get; set; } = null!;
        public virtual DbSet<PraveenProfessor> PraveenProfessors { get; set; } = null!;
        public virtual DbSet<PraveenResearcher> PraveenResearchers { get; set; } = null!;
        public virtual DbSet<PraveenRole> PraveenRoles { get; set; } = null!;
        public virtual DbSet<PraveenUserRoleMapper> PraveenUserRoleMappers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;User ID=sdirectdb;Password=sdirectdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PraveenActivity>(entity =>
            {
                entity.ToTable("PraveenActivity");

                entity.Property(e => e.ApiName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PraveenLoginCredential>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__PraveenL__1788CC4C598FDDAF");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PraveenProfessor>(entity =>
            {
                entity.HasKey(e => e.ProfId)
                    .HasName("PK__PraveenP__0A883611A2ACEE4E");

                entity.ToTable("PraveenProfessor");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProfEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProfName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProfUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PraveenResearcher>(entity =>
            {
                entity.HasKey(e => e.ResId)
                    .HasName("PK__PraveenR__297882F6C665017C");

                entity.ToTable("PraveenResearcher");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ResName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ResUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PraveenRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__PraveenR__8AFACE1A5E79E7D8");

                entity.Property(e => e.RolesName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PraveenUserRoleMapper>(entity =>
            {
                entity.ToTable("PraveenUserRoleMapper");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PraveenUserRoleMappers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PraveenUs__RoleI__6049CB61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PraveenUserRoleMappers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PraveenUs__UserI__5F55A728");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
