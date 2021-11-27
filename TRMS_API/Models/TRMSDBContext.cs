using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TRMS_API.Models
{
    public partial class TRMSDBContext : DbContext
    {
        public TRMSDBContext()
        {
        }

        public TRMSDBContext(DbContextOptions<TRMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblProject> TblProject { get; set; }
        public virtual DbSet<TblRequest> TblRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DBconnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__TblEmplo__AFB3EC0DEC56BB32");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__TblEmploye__l_id__3A81B327");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__TblLogin__A7C7B6F8B7C108DB");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(20);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__TblProje__11F14DA50C5CE5F9");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("projectName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__TblReque__E3C5DE31554EED88");

                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.Property(e => e.CauseTravel)
                    .HasColumnName("causeTravel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("date");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDays).HasColumnName("noOfDays");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TblRequest)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__TblReques__empId__3E52440B");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblRequest)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__TblReques__proje__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
