using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class Engine : TuningPart
    {
        public int EngineId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public int CylinderCount { get; set; }
        public int ImpactAcceleration { get; set; }
        public int ImpactTopSpeed { get; set; }
        public int PowerInHp { get; set; }
    }
}
