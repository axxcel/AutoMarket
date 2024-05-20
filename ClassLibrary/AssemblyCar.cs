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
    /// Представляет сборку автомобиля.
    /// </summary>
    public class AssemblyCar
    {
        /// <summary>
        /// Автомобиль.
        /// </summary>
        public Car Car { get; set; } 

        /// <summary>
        /// Бортовой компьютер.
        /// </summary>
        public Additives Computer { get; set; } = new Additives();

        /// <summary>
        /// Тонировка.
        /// </summary>
        public Additives Tinting { get; set; } = new Additives();

        /// <summary>
        /// Обогрев ветрового стекла.
        /// </summary>
        public Additives GlassHeating { get; set; } = new Additives();
        /// <summary>
        /// Цена собранного автомобиля.
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Цена собранного автомобиля без скидки.
        /// </summary>
        public int OldPrice { get; set; }
        /// <summary>
        /// Скидка собранного автомобиля.
        /// </summary>
        public int Discount { get; set; }
    }
}
