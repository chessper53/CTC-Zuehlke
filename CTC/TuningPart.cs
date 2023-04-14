using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class TuningPart
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public int ImpactRating { get; set; }
    }
}
