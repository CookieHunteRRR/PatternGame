using Pattern.Logic.Modules.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI
{
    internal class UIBoxElement : IDisplayable
    {
        public Position Offset { get; set; }

        protected UIBox ParentBox { get; private set; }

        public UIBoxElement(UIBox parentBox, int x, int y)
        {
            ParentBox = parentBox;
            Offset = new Position(x, y);
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}
