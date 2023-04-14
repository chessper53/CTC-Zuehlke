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
        public int ExhaustId { get; set; }
        public int ImpactAcceleration { get; set; }
        public int ImpactPowerInHp { get; set; }
    }
}
