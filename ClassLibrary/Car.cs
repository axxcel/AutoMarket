using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Библиотека классов, представляющая автомобили.
/// </summary>
namespace ClassLibrary
{
    /// <summary>
    /// Представляет автомобиль.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Марка автомобиля.
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        /// Кузов автомобиля.
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// Цена автомобиля.
        /// </summary>
        public int price { get; set; }

        /// <summary>
        /// Старая цена автомобиля.
        /// </summary>
        public int oldPrice { get; set; }

        /// <summary>
        /// Скидка на автомобиль.
        /// </summary>
        public int discount { get; set; }
    }
}
