using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Библиотека классов, представляющая сборку автомобилей.
/// </summary>
namespace ClassLibrary
{
    /// <summary>
    /// Реализация интерфейса сборщика автомобилей.
    /// </summary>
    public class AssemblyCarBuilder : IAssemblyCarBuilder
    {
        /// <summary>
        /// Собираемый автомобиль.
        /// </summary>
        private AssemblyCar _assemblyCar;

        /// <summary>
        /// Автомобиль.
        /// </summary>
        private Car _car;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AssemblyCarBuilder"/>.
        /// </summary>
        /// <param name="car">Автомобиль.</param>
        public AssemblyCarBuilder(Car car)
        {
            _car = car;
            _assemblyCar = new();
        }
        public void SetupPrice()
        {
            _assemblyCar.Price = _car.price;
            _assemblyCar.OldPrice = _car.oldPrice;
            _assemblyCar.Discount = _car.discount;
        }

        /// <summary>
        /// Добавляет компьютер.
        /// </summary>
        public void BuildComputer()
        {
            _assemblyCar.Computer.name = "Бортовой компьютер";
            _assemblyCar.Computer.price = 5000;
            _assemblyCar.Price += _assemblyCar.Computer.price;
            _assemblyCar.OldPrice += _assemblyCar.Computer.price;
        }

        /// <summary>
        /// Добавляет тонировку.
        /// </summary>
        public void BuildTinting()
        {
            _assemblyCar.Tinting.name = "Легкая тонировка стекол";
            _assemblyCar.Tinting.price = 5000;
            _assemblyCar.Price += _assemblyCar.Tinting.price;
            _assemblyCar.OldPrice += _assemblyCar.Tinting.price;
        }

        /// <summary>
        /// Добавляет подогрев стекол.
        /// </summary>
        public void BuildGlassHeating()
        {
            _assemblyCar.GlassHeating.name = "Подогрев ветрового стекол";
            _assemblyCar.GlassHeating.price = 50000;
            _assemblyCar.Price += _assemblyCar.GlassHeating.price;
            _assemblyCar.OldPrice += _assemblyCar.GlassHeating.price;
        }

        /// <summary>
        /// Возвращает собранный автомобиль.
        /// </summary>
        /// <returns>Собранный автомобиль.</returns>
        public AssemblyCar GetCar()
        {
            AssemblyCar assemblyCar = _assemblyCar;
            return _assemblyCar;
        }
    }
}