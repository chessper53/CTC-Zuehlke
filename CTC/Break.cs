using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Break : TuningPart
    {
        public int BreakId { get; set; }
        public int Weight { get; set; }
        public int ImpactBreakingForce { get; set; }
    }
}
