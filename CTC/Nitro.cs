using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Nitro : TuningPart
    {
        public int NitroId { get; set; }
        public int TempAccelerationImpact { get; set; }
        public int Charges { get; set; }
        public int RechargeTime { get; set; }
    }
}
