using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Car
    {
        public int CarId { get; set; }
        public string Image { get; set; }
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
        public int Value { get; set; }
        public Bumper Bumper { get; set; }
        public Exhaust Exhaust { get; set; }
        public Nitro Nitro { get; set; }
        public Tyre Tyre { get; set; }
        public RearSpoiler RearSpoiler { get; set;}
        public Rim Rim { get; set; }
        public Engine Engine { get; set; }
        public Break Break { get; set; }
    }
}
