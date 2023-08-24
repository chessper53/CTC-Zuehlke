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
            // Returns all cars.
            return Model.Cars;
        }
        public void ReloadCars()
        {
            // Returns all cars in order to refresh them.
            Model = new CTCModel();
        }
    }
}
