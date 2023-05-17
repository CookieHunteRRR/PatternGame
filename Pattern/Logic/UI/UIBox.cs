using Pattern.Logic.Modules.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI
{
    internal class UIBox : IDisplayable
    {
        public Position Position { get; set; }

        protected List<UIBoxElement> elements;

        public UIBox(int x, int y)
        {
            elements = new List<UIBoxElement>();
            Position = new Position(x, y);
        }

        public void AddElement(UIBoxElement element)
        {
            elements.Add(element);
        }

        public virtual void InitialDisplay()
        {

        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}
