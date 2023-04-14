using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal class TuningController : Controller
    {
        public List<Bumper> ReadBumpers()
        {
            return Model.Bumpers;
        }
        public List<Exhaust> ReadExhaust()
        {
            return Model.Exhausts;
        }
        public List<Nitro> ReadNitro()
        {
            return Model.Nitros;
        }
        public List<Tyre> ReadTyre()
        {
            return Model.Tyres;
        }
        public List<RearSpoiler> ReadRearSpoiler()
        {
            return Model.RearSpoilers;
        }
        public List<Rim> ReadRim()
        {
            return Model.Rims;
        }
        public List<Engine> ReadEngine()
        {
            return Model.Engines;
        }
        public List<Break> ReadBreak()
        {
            return Model.Breaks;
        }
        public void UpdateCar(Car car)
        {
            Car result = Model.Db.Car.Where(c => c.CarId == car.CarId).First();
            Model.Db.Entry(result).CurrentValues.SetValues(car);
            Model.Db.SaveChanges();
            Model.Cars = Model.Db.Car.ToList();
        }
    }
}
