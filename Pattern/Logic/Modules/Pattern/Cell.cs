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
        public int Value { get; set; }
        //private DirectionInfo[] defaultDirections;

        public bool IsStartingPoint { get; set; }
        public bool IsUsed { get; set; }
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

            ResetCell();
        }

        internal void ResetCell()
        {
            IsStartingPoint = false;
            IsUsed = false;
        }

        /*internal (int X, int Y) GetConsolePosition()
        {
            var patBoxPos = Program.GameManager.PatternBox.Position;
            var selCellOff = Element.Offset;

            return (patBoxPos.X + selCellOff.X,
                    patBoxPos.Y + selCellOff.Y);
        }*/

        internal (int X, int Y) GetConsolePosition()
        {
            var patBoxPos = Program.GameManager.UIManager.PatternBox.Position;
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
            return $"{Value}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Cell)
            {
                Cell cell = (Cell)obj;
                if (cell.Value == this.Value) return true;
                else return false;
            }
            return false;
        }
    }
}
