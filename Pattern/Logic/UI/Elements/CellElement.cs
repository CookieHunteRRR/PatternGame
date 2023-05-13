using Pattern.Logic.Modules.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI.Elements
{
    internal class CellElement : UIBoxElement
    {
        public Cell Cell { get; private set; }

        public CellElement(UIBox parentBox, int x, int y) : base(parentBox, x, y)
        {
            Cell = new Cell(this);
        }
    }
}
