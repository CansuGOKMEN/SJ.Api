using Microsoft.EntityFrameworkCore;
using SJ.Api.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SJ.Api.Core.Context
{
    public class SJApiContext : DbContext
    {
        public SJApiContext(DbContextOptions options) : base(options) { }

        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<Result> Result { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
