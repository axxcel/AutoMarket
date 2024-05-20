using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;
using System.Runtime.ConstrainedExecution;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_SetsCarAndAssemblyCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var assemblyCarBuilder = new AssemblyCarBuilder(car);

            // Assert
            Assert.AreEqual(car, assemblyCarBuilder._car);
            Assert.IsNotNull(assemblyCarBuilder._assemblyCar);
        }
    }
}
