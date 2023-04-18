using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class CarController : Controller
    {
        public List<Car> ReadCars()
        {
            //Placeholder
            return Model.Cars;
        }
        public void ReloadCars()
        {
            Model = new CTCModel();
        }
    }
}
