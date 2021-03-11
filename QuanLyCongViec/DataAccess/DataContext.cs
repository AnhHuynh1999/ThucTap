using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace DataAccess
{
    public class DataContext:IdentityDbContext<NguoiSuDung>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<CongViec> CongViecs{ get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DuAn> DuAns { get; set; }
        public DbSet<NguoiSuDung> NguoiSuDungs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
