using System;

namespace ClassLibrary
{
    [TestClass]
    public class AssemblyCarBuilderTests
    {
        [TestMethod]
        public void ShouldSetupPrice()
        {
            // Arrange
            Car car = new Car
            {
                price = 10000,
                oldPrice = 12000,
                discount = 12000-10000
            };
            AssemblyCarBuilder assemblyCarBuilder = new(car);

            // Act
            assemblyCarBuilder.SetupPrice();
            AssemblyCar assemblyCar = assemblyCarBuilder.GetCar();

            // Assert
            Assert.AreEqual(car.price, assemblyCar.Price);
            Assert.AreEqual(car.oldPrice, assemblyCar.OldPrice);
            Assert.AreEqual(car.discount, assemblyCar.Discount);
        }

        [TestMethod]
        public void ShouldBuildComputer()
        {
            // Arrange
            Car car = new Car();
            Additives comp = new();
            comp.name = "Бортовой компьютер";
            comp.price = 5000;
            AssemblyCarBuilder assemblyCarBuilder = new(car);

            // Act
            assemblyCarBuilder.BuildComputer();
            AssemblyCar assemblyCar = assemblyCarBuilder.GetCar();
            assemblyCar.Computer.name = "Бортовой компьютер";
            assemblyCar.Computer.price = 5000;


            // Assert
            Assert.AreEqual(comp.name, assemblyCar.Computer.name);
            Assert.AreEqual(comp.price, assemblyCar.Computer.price);
        }

        [TestMethod]
        public void ShouldBuildTinting()
        {
            // Arrange
            Car car = new Car();
            Additives ting = new();
            ting.name = "Легкая тонировка стекол";
            ting.price = 5000;
            AssemblyCarBuilder assemblyCarBuilder = new(car);

            // Act
            assemblyCarBuilder.BuildComputer();
            AssemblyCar assemblyCar = assemblyCarBuilder.GetCar();
            assemblyCar.Computer.name = "Легкая тонировка стекол";
            assemblyCar.Computer.price = 5000;


            // Assert
            Assert.AreEqual(ting.name, assemblyCar.Computer.name);
            Assert.AreEqual(ting.price, assemblyCar.Computer.price);
        }

        [TestMethod]
        public void ShouldBuildGlassHeating()
        {
            // Arrange
            Car car = new Car();
            Additives glass = new();
            glass.name = "Подогрев ветрового стекол";
            glass.price = 5000;
            AssemblyCarBuilder assemblyCarBuilder = new(car);

            // Act
            assemblyCarBuilder.BuildComputer();
            AssemblyCar assemblyCar = assemblyCarBuilder.GetCar();
            assemblyCar.Computer.name = "Подогрев ветрового стекол";
            assemblyCar.Computer.price = 5000;


            // Assert
            Assert.AreEqual(glass.name, assemblyCar.Computer.name);
            Assert.AreEqual(glass.price, assemblyCar.Computer.price);
        }
    }
}
