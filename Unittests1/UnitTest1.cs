using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using CTC;

namespace Unittests1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReplacementTuningPart_SuccessfulReplaceEngineFromCarWithOtherObject_SetEngine()
        {
            //Arrange
            CTCModel model = new CTCModel();
            Car car = model.Cars.First();
            Engine replacementEngin;
            //Make sure that every test uses a different engine
            if(car.EngineId == 0)
            {
                replacementEngin = model.Engines[1];
            }
            else
            {
                replacementEngin = model.Engines[0];
            }

            //Act
            car.Engine = replacementEngin;

            //Assert
            Assert.AreEqual(car.Engine, replacementEngin);
        }
        [TestMethod]
        public void CalculationValue_ValueFromCarPlusAllPartsEqualsSum_GetCalcValue()
        {
            //Arrange
            Car car = new Car();
            car.Engine = new Engine();
            car.Exhaust = new Exhaust();
            car.Bumper = new Bumper();
            car.RearSpoiler = new RearSpoiler();
            car.Rim = new Rim();
            car.Tyre = new Tyre();
            car.Break = new Break();
            car.Nitro = new Nitro();

            car.Engine.Price = 10;
            car.Exhaust.Price = 10;
            car.Bumper.Price = 10;
            car.RearSpoiler.Price = 10;
            car.Rim.Price = 10;
            car.Tyre.Price = 10;
            car.Break.Price = 10;
            car.Nitro.Price = 10;

            double expectedResult = car.Value + car.Engine.Price + car.Exhaust.Price + car.Bumper.Price + car.RearSpoiler.Price + car.Rim.Price + car.Tyre.Price + car.Break.Price + car.Nitro.Price;

            Console.WriteLine(car.Value);
            //Act
            double actualResult = car.GetCalcValue();
            bool result = Math.Abs(actualResult - expectedResult) < 0.01;

            //Assert
            Assert.IsTrue(result);
        }
        /*
        [TestMethod]
        public void Model_ListSuccessfulFilledWithDBContent()
        {
            //Arrange
            //Act
            //Assert
        }
        */
    }
}