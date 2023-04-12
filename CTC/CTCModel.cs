using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class CTCModel
    {
        public List<Bumper > Bumpers { get; set; }
        public List<Exhaust> Exhausts { get; set; }
        public List<Nitro> Nitros { get; set; }
        public List<Tyre> Tyres { get; set; }
        public List<RearSpoiler> RearSpoilers { get; set; }
        public List<Rim> Rims { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Break> Breaks { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Car> Cars { get; set; }
    }
}
