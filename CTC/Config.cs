using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CTC
{
    internal class Config : DbContext
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

        public string ConnectionString { get; set; } = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=ctc;User id=ctcUser;Password=ctcUser;Trusted_Connection=True;Encrypt=False";

        public Config()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "ctc.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }
}
