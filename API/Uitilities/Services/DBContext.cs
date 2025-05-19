using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Uitilities.Services
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<BarangayTable> BarangayTable { get; set; }
        public DbSet<CampusTable> CampusTable { get; set; }
        public DbSet<DivisionTable> DivisionTable { get; set; }
        public DbSet<EducBGTable> EducBGTable { get; set; }
        public DbSet<FathersTable> FathersTable { get; set; }
        public DbSet<GuardianTable> GuardianTable { get; set; }
        public DbSet<LevelTable> LevelTable { get; set;  }
        public DbSet<MothersTable> MothersTable { get; set; }
        public DbSet<MunicipalityTable> MunicipalityTable { get; set; }
        public DbSet<NationalityTable> NationalityTable { get; set; }
        public DbSet<ProvincesTable> ProvincesTable { get; set; }
        public DbSet<ReligionTable> ReligionTable { get; set; }
        public DbSet<StrandTable> StrandTable { get; set; }
        public DbSet<StudentAppTable> StudentAppTable { get; set; }
        public DbSet<StudentDocsTable> StudentDocstable { get; set; }
        public DbSet<StudentAppFilesTable> StudentAppFilesTable { get; set; }
        public DbSet<StudentTable> StudentTable { get; set; }
        public DbSet<UserTable> UsersTable { get; set; }
    }
}
