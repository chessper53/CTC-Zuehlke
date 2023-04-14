using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class CTCModel
    {
        public Config Db { get; set; }
        public List<Bumper > Bumpers { get; set; }
        public List<Exhaust> Exhausts { get; set; }
        public List<Nitro> Nitros { get; set; }
        public List<Tyre> Tyres { get; set; }
        public List<RearSpoiler> RearSpoilers { get; set; }
        public List<Rim> Rims { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Break> Breaks { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Car> Cars { get; set; }

        public CTCModel()
        {
            Db = new Config();
            Bumpers = Db.Bumper.ToList();
            Exhausts = Db.Exhaust.ToList();
            Nitros = Db.Nitro.ToList();
            Tyres = Db.Tyre.ToList();
            RearSpoilers = Db.RearSpoiler.ToList();
            Rims = Db.Rim.ToList();
            Engines = Db.Engine.Include("Brand").ToList();
            Breaks = Db.Break.ToList();
            Brands = Db.Brand.ToList();
            Cars = Db.Car.Include("Brand").Include("Bumper").Include("Exhaust").Include("Nitro").Include("Tyre").Include("RearSpoiler").Include("Rim").Include("Engine").Include("Break").ToList();
        }
    }
}
