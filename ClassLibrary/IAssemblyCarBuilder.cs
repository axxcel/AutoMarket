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
    /// Интерфейс строителя автомобилей.
    /// </summary>
    public interface IAssemblyCarBuilder
    {
        /// <summary>
        /// Добавляет компьютер.
        /// </summary>
        /// <returns>Возвращает текущего строителя автомобилей.</returns>
        void BuildComputer();

        /// <summary>
        /// Добавляет тонировку.
        /// </summary>
        /// <returns>Возвращает текущего строителя автомобилей.</returns>
        void BuildTinting();

        /// <summary>
        /// Добавляет подогрев стекол.
        /// </summary>Возвращает текущего строителя автомобилей.</returns>
        void BuildGlassHeating();

        /// <summary>
        /// Возвращает собранный автомобиль.
        /// </summary>
        /// <returns>Возвращает текущего строителя автомобилей.</returns>
        AssemblyCar GetCar();
    }
}