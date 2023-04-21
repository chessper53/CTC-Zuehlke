using CTC;

namespace Unittests1
{
    [TestClass]
    public class dbConnectionTests
    {
        [TestMethod]
        public void Connection_SuccessfulConnectionToDatabase_DBContext()
        {
            //Arrange, Act and Assert
            DBContext config = new DBContext();
        }
        [TestMethod]
        public void UpdatedCar_SaveCarWithNewEngineInDB_UpdateCar()
        {
            //Arrange
            TuningController controller = new TuningController();
            CTCModel model = new CTCModel();
            Car car = model.Cars[0];
            Engine newEngine;
            //Make sure that the engine is different in every test -> min. 2 Engines in DB
            if (car.EngineId == 0)
            {
                newEngine = model.Engines[1];
            }
            else
            {
                newEngine = model.Engines[0];
            }

            //Act
            car.Engine = newEngine;
            car.EngineId = newEngine.EngineId;
            controller.UpdateCar(car);
            model.Cars = model.Db.Car.ToList();

            //Assert
            Assert.AreEqual(newEngine, model.Cars[0].Engine);
        }
    }
}
