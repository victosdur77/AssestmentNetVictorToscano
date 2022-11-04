using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssestmentNET_VictorToscanoDuran.Entities
{
    public partial class victortoscanodatabaseContext : DbContext
    {
        public victortoscanodatabaseContext()
        {
        }

        public victortoscanodatabaseContext(DbContextOptions<victortoscanodatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Betis1986-;database=victortoscanodatabase", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claims");

                entity.HasIndex(e => e.VehicleId, "vehicle_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .HasColumnName("status");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("vehicle_id");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owners");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Drivelicense)
                    .HasMaxLength(45)
                    .HasColumnName("drivelicense");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(45)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .HasColumnName("lastname");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.HasIndex(e => e.OwnerId, "owner_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasMaxLength(45)
                    .HasColumnName("brand");

                entity.Property(e => e.Color)
                    .HasMaxLength(45)
                    .HasColumnName("color");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.Vin)
                    .HasMaxLength(45)
                    .HasColumnName("vin");

                entity.Property(e => e.Year)
                    .HasColumnType("datetime")
                    .HasColumnName("year");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("owner_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
