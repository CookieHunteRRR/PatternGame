using Pattern.Logic.UI;
using Pattern.Logic.UI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules.Pattern
{
    internal class Cell
    {
        public CellElement Element { get; private set; }
        private int value;
        //private DirectionInfo[] defaultDirections;

        public bool IsStartingPoint { get; private set; }
        //public DirectionInfo[] Directions { get; private set; } // 0 - лево, 1 - верх, 2 - право, 3 - низ

/*        internal Cell(int v, DirectionInfo[] cellInfo)
        {
            value = v;
            defaultDirections = cellInfo;
            Directions = new DirectionInfo[4];

            RestoreDefaultValues();
        }*/

        internal Cell(CellElement element)
        {
            Element = element;
        }

        internal (int X, int Y) GetConsolePosition()
        {
            var patBoxPos = Program.GameManager.PatternBox.Position;
            var selCellOff = Element.Offset;

            return (patBoxPos.X + selCellOff.X,
                    patBoxPos.Y + selCellOff.Y);
        }

        /*public void RestoreDefaultValues()
        {
            IsStartingPoint = false;
            for (int i = 0; i < defaultDirections.Length; i++)
            {
                Directions[i] = defaultDirections[i];
            }
        }*/

        public override string ToString()
        {
            return $"{value}";
        }
    }
}
