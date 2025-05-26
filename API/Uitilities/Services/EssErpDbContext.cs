using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Uitilities.Services;

public partial class EssErpDbContext : DbContext
{
    public EssErpDbContext()
    {
    }

    public EssErpDbContext(DbContextOptions<EssErpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdmissionGpatable> AdmissionGpatables { get; set; }

    public virtual DbSet<BarangayTable> BarangayTables { get; set; }

    public virtual DbSet<CampusTable> CampusTables { get; set; }

    public virtual DbSet<DivisionTable> DivisionTables { get; set; }

    public virtual DbSet<DocumentFileTable> DocumentFileTables { get; set; }

    public virtual DbSet<EducBgtable> EducBgtables { get; set; }

    public virtual DbSet<FathersTable> FathersTables { get; set; }

    public virtual DbSet<GuardianTable> GuardianTables { get; set; }

    public virtual DbSet<LevelTable> LevelTables { get; set; }

    public virtual DbSet<MothersTable> MothersTables { get; set; }

    public virtual DbSet<MunicipalityTable> MunicipalityTables { get; set; }

    public virtual DbSet<NationalityTable> NationalityTables { get; set; }

    public virtual DbSet<ProvincesTable> ProvincesTables { get; set; }

    public virtual DbSet<ReligionTable> ReligionTables { get; set; }

    public virtual DbSet<StrandTable> StrandTables { get; set; }

    public virtual DbSet<StudentAppTable> StudentAppTables { get; set; }

    public virtual DbSet<StudentTable> StudentTables { get; set; }

    public virtual DbSet<UsersTable> UsersTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=erp-db.cavlaw09wtuu.ap-southeast-1.rds.amazonaws.com;Database=EssErpDb;User ID=admin;Password=EssAdmin1234;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionGpatable>(entity =>
        {
            entity.HasKey(e => e.SubjectId);

            entity.ToTable("AdmissionGPATable");

            entity.Property(e => e.ActiveStatus).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");

            entity.HasOne(d => d.Student).WithMany(p => p.AdmissionGpatables)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdmissionGPATable_StudentTable");
        });

        modelBuilder.Entity<BarangayTable>(entity =>
        {
            entity.HasKey(e => e.BrgyId);

            entity.ToTable("BarangayTable");
        });

        modelBuilder.Entity<CampusTable>(entity =>
        {
            entity.HasKey(e => e.CampusId);

            entity.ToTable("CampusTable");
        });

        modelBuilder.Entity<DivisionTable>(entity =>
        {
            entity.HasKey(e => e.DivId);

            entity.ToTable("DivisionTable");
        });

        modelBuilder.Entity<DocumentFileTable>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.ToTable("DocumentFileTable");
        });

        modelBuilder.Entity<EducBgtable>(entity =>
        {
            entity.HasKey(e => e.EducBgId);

            entity.ToTable("EducBGTable");
        });

        modelBuilder.Entity<FathersTable>(entity =>
        {
            entity.HasKey(e => e.FatherId);

            entity.ToTable("FathersTable");

            entity.Property(e => e.IsAlumnae).HasColumnName("isAlumnae");

            entity.HasOne(d => d.Student).WithMany(p => p.FathersTables)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FathersTable_StudentTable");
        });

        modelBuilder.Entity<GuardianTable>(entity =>
        {
            entity.HasKey(e => e.GuardianId);

            entity.ToTable("GuardianTable");

            entity.Property(e => e.IsVerified).HasColumnName("isVerified");

            entity.HasOne(d => d.Student).WithMany(p => p.GuardianTables)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GuardianTable_StudentTable");
        });

        modelBuilder.Entity<LevelTable>(entity =>
        {
            entity.HasKey(e => e.LevelId);

            entity.ToTable("LevelTable");
        });

        modelBuilder.Entity<MothersTable>(entity =>
        {
            entity.HasKey(e => e.MotherId);

            entity.ToTable("MothersTable");

            entity.Property(e => e.IsAlumnae).HasColumnName("isAlumnae");

            entity.HasOne(d => d.Student).WithMany(p => p.MothersTables)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MothersTable_StudentTable");
        });

        modelBuilder.Entity<MunicipalityTable>(entity =>
        {
            entity.HasKey(e => e.MunicipalityId);

            entity.ToTable("MunicipalityTable");
        });

        modelBuilder.Entity<NationalityTable>(entity =>
        {
            entity.HasKey(e => e.NationalityId);

            entity.ToTable("NationalityTable");
        });

        modelBuilder.Entity<ProvincesTable>(entity =>
        {
            entity.HasKey(e => e.ProvinceId);

            entity.ToTable("ProvincesTable");
        });

        modelBuilder.Entity<ReligionTable>(entity =>
        {
            entity.HasKey(e => e.ReligionId);

            entity.ToTable("ReligionTable");
        });

        modelBuilder.Entity<StrandTable>(entity =>
        {
            entity.HasKey(e => e.StrandId);

            entity.ToTable("StrandTable");
        });

        modelBuilder.Entity<StudentAppTable>(entity =>
        {
            entity.HasKey(e => e.AppId);

            entity.ToTable("StudentAppTable");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAppTables)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentAppTable_StudentTable");
        });

        modelBuilder.Entity<StudentTable>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("StudentTable");
        });

        modelBuilder.Entity<UsersTable>(entity =>
        {
            entity.ToTable("UsersTable");

            entity.HasOne(d => d.User).WithMany(p => p.UsersTables)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersTable_StudentTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
