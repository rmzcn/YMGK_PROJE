using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YuzTanima.Entities.Concrete;

namespace YuzTanima.DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Raporlar> Raporlar { get; set; }
        public DbSet<Birimler> Birimler { get; set; }
        public DbSet<CalisanKameralari> CalisanKameralari { get; set; }
        public DbSet<Calisanlar> Calisanlar { get; set; }
        public DbSet<CalisanYollari> CalisanYollari { get; set; }
        public DbSet<Kameralar> Kameralar { get; set; }
        public DbSet<KayitliOlmayanZiyaretciler> KayitliOlmayanZiyaretciler { get; set; }
        public DbSet<KayitliZiyaretciler> KayitliZiyaretciler { get; set; }
        public DbSet<RaporTipleri> RaporTipleri { get; set; }
        public DbSet<Ziyaretciler> Ziyaretciler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birimler>().HasKey(x => x.birimId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ymgk.database.windows.net;database=ymgk;User Id=ibolatkiran;password=ymgk.server2021");
        }
    }
}
