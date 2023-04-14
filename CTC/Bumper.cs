using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Bumper : TuningPart
    {
        public int BumperId { get; set; }
        public int Weight { get; set; }
    }
}
