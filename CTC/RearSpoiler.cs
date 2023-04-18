using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class RearSpoiler : TuningPart
    {
        public int? RearSpoilerId { get; set; }
        public int Weight { get; set; }
        public int ImpactHandling { get; set; }

        public RearSpoiler()
        {

        }
        public RearSpoiler(int? rearSpoilerId, int weight, int impactHandling, string type, int impactRating, double price)
        {
            RearSpoilerId = rearSpoilerId;
            Weight = weight;
            ImpactHandling = impactHandling;
            Type = type;
            ImpactRating = impactRating;
            Price = price;
        }
    }
}
