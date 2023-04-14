using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Tyre : TuningPart
    {
        public int TyreId { get; set; }
        public int Weight { get; set; }
        public int ImpactHandling { get; set; }
        public int ImpactBreakingForce { get; set; }
    }
}
