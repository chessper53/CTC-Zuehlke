using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CTC
{
    internal class DBContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Break> Break { get; set; }
        public DbSet<Bumper> Bumper { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Exhaust> Exhaust { get; set; }
        public DbSet<Nitro> Nitro { get; set; }
        public DbSet<RearSpoiler> RearSpoiler { get; set; }
        public DbSet<Rim> Rim { get; set; }
        public DbSet<Tyre> Tyre { get; set; }

        public string DbPath { get; set; }

        public string ConnectionString { get; set; } = "Data Source=192.168.55.44\\MSSQLSERVER01;Initial Catalog=ctc;User id=caspar;Password=caspar20052.0;Trusted_Connection=False;Encrypt=False";

        public DBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }
}
