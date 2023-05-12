using Pattern.Logic.Modules.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI
{
    /// <summary>
    /// Визуальная составляющая "ну вот этого 3х3 квадрата в котором паттерны вводить короче". Логика находится в Modules.Pattern.
    /// </summary>
    internal class PatternBox : IDisplayable
    {
        private PatternManager manager;

        internal PatternBox()
        {
            manager = new PatternManager();
        }

        public void Display()
        {
            manager.DisplayAvailableCells();
        }
    }
}
