using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Nitro : TuningPart
    {
        public int? NitroId { get; set; }
        public int TempAccelerationImpact { get; set; }
        public int Charges { get; set; }
        public int RechargeTime { get; set; }

        public Nitro()
        {

        }
        public Nitro(int? nitroId, int tempAccelerationImpact, int charges, int rechargeTime, string type, int impactRating, int price)
        {
            NitroId = nitroId;
            TempAccelerationImpact = tempAccelerationImpact;
            Charges = charges;
            RechargeTime = rechargeTime;
            Type = type;
            ImpactRating = impactRating;
            Price = price;
        }
    }
}
