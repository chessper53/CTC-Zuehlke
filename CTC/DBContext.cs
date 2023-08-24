using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CTC
{
    internal class DBContext : DbContext
    {
        // Establishes the connection to our database.
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

        // this connection string is not safe. I changed it in order to test it on another device
        public string ConnectionString { get; set; } = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ctc;User id=root;Trusted_Connection=True;Encrypt=False";

        public DBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }
}
