using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Rim : TuningPart
    {
        public int RimId { get; set; }
        public int Weight { get; set; }
        public string colour { get; set; }
    }
}
