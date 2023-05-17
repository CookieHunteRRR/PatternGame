using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules.Pattern
{
    internal class PatternCommand
    {
        public Cell From { get; private set; }
        public Cell To { get; private set; }

        public PatternCommand(Cell from, Cell to)
        {
            From = from;
            To = to;
        }
    }
}
