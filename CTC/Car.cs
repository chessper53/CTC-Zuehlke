using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Car
    {
        public int CarId { get; set; }
        public string Image { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string ColourOutside { get; set; }
        public string TrimColour { get; set; }
        public int PowerInHp { get; set; }
        public int Acceleration { get; set; }
        public int TopSpeedInKmh { get; set; }
        public int HandlingRange { get; set; }
        public int BreakingForce { get; set; }
        public int Weight { get; set; }
        public int Rating { get; set; }
        public double Value { get; set; }
        public int BumperId { get; set; }
        public Bumper Bumper { get; set; }
        public int ExhaustId { get; set; }
        public Exhaust Exhaust { get; set; }
        public int NitroId { get; set; }
        public Nitro Nitro { get; set; }
        public int TyreId { get; set; }
        public Tyre Tyre { get; set; }
        public int RearSpoilerId { get; set; }
        public RearSpoiler RearSpoiler { get; set;}
        public int RimId { get; set; }
        public Rim Rim { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int BreakId { get; set; }
        public Break Break { get; set; }
    }
}
