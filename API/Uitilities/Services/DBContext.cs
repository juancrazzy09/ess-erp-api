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
        public DbSet<UserTable> UsersTable { get; set; }
    }
}
