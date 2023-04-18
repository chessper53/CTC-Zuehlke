using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Exhaust : TuningPart
    {
        public int? ExhaustId { get; set; }
        public int ImpactAcceleration { get; set; }
        public int ImpactPowerInHp { get; set; }

        public Exhaust()
        {

        }
        public Exhaust(int? exhaustId, int impactAcceleration, int impactPowerInHp, string type, int impactRating, double price)
        {
            ExhaustId = exhaustId;
            ImpactAcceleration = impactAcceleration;
            ImpactPowerInHp = impactPowerInHp;
            Type = type;
            ImpactRating = impactRating;
            Price = price;
        }
    }
}
