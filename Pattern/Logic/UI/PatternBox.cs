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
    internal class PatternBox : UIBox
    {
        public PatternManager PatternManager { get; private set; }

        internal PatternBox(int x, int y) : base(x, y)
        {
            PatternManager = new PatternManager(this);
        }

        public override void InitialDisplay()
        {
            //manager.DisplayAvailableCells();
            foreach (var element in elements)
            {
                Console.SetCursorPosition(this.Position.X + element.Offset.X,
                                          this.Position.Y + element.Offset.Y);
                //Console.Write(element);
                if (element is CellElement)
                {
                    Console.Write(((CellElement)element).Cell.Value);
                }
            }
        }

        public void CutConnections()
        {
            var _x = this.Position.X + 6;
            var _y = this.Position.Y + 6;

            for (int y = this.Position.Y + 1; y <= _y; y++)
            {
                for (int x = this.Position.X + 1; x <= _x; x++)
                {
                    if (y % 2 != 0)
                    {
                        if (x % 2 != 0) continue;
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write((char)UtilityChars.None);
                }
            }
        }

        public new void Display()
        {
            foreach (var command in PatternManager.RegisteredConnections)
            {
                var toDisplay = GetAppropriateConnection(command);
                Console.SetCursorPosition(toDisplay.pos.X, toDisplay.pos.Y);
                Console.Write(toDisplay.connection);
            }
            if (PatternManager.PatternBuilder != null)
            {
                foreach (var command in PatternManager.PatternBuilder.Commands)
                {
                    var toDisplay = GetAppropriateConnection(command);
                    Console.SetCursorPosition(toDisplay.pos.X, toDisplay.pos.Y);
                    Console.Write(toDisplay.connection);
                }
            }
        }

        public ((int X, int Y) pos, char connection) GetAppropriateConnection(PatternCommand comm)
        {
            var moveValue = comm.To.Element.Offset - comm.From.Element.Offset;
            char c = (char)UtilityChars.None;

            // определяем символ
            if (moveValue.X != 0)
            {
                if (moveValue.X > 0) c = (char)UtilityChars.RightArrow;
                else c = (char)UtilityChars.LeftArrow;
            }
            else // значит мы пошли по Y
            {
                if (moveValue.Y > 0) c = (char)UtilityChars.DownArrow;
                else c = (char)UtilityChars.UpArrow;
            }

            // определяем координату в консоли в которую нужно пихнуть символ
            var charOffset = comm.From.Element.Offset + (moveValue / 2);
            var charCoord = this.Position + charOffset;
            return ((charCoord.X, charCoord.Y), c);
        }
    }
}
