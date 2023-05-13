using Pattern.Logic.Modules.Pattern;
using Pattern.Logic.UI.Elements;
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
    internal class PatternBox : UIBox, IDisplayable
    {
        public PatternManager PatternManager { get; private set; }

        internal PatternBox(int x, int y) : base(x, y)
        {
            PatternManager = new PatternManager(this);
        }

        public new void Display()
        {
            //manager.DisplayAvailableCells();
            foreach (var element in elements)
            {
                Console.SetCursorPosition(this.Position.X + element.Offset.X,
                                          this.Position.Y + element.Offset.Y);
                Console.Write("*");
            }
        }
    }
}
