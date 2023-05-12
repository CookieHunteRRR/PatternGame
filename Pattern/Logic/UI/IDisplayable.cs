using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI
{
    /// <summary>
    /// Интерфейс, определяющий, что объект можно вывести в консоль
    /// </summary>
    internal interface IDisplayable
    {
        /// <summary>
        /// Метод, который будет непосредственно выводить содержимое чего-либо в консоль
        /// </summary>
        public void Display();
    }
}
