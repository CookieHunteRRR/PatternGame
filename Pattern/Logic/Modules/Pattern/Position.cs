using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules.Pattern
{
    internal struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position(Position pos)
        {
            X = pos.X;
            Y = pos.Y;
        }

        public Position GetAsCellOffset()
        {
            var patBoxPos = Program.GameManager.UIManager.PatternBox.Position;

            return new Position(patBoxPos.X - this.X, patBoxPos.Y - this.Y);
        }

        // overload
        public static Position operator +(Position pos1, Position pos2) => new Position(pos1.X + pos2.X, pos1.Y + pos2.Y);
        public static Position operator +(Position pos1, (int X, int Y) pos2) => new Position(pos1.X + pos2.X, pos1.Y + pos2.Y);
        public static Position operator -(Position pos1, Position pos2) => new Position(pos1.X - pos2.X, pos1.Y - pos2.Y);
        public static Position operator /(Position pos1, int times) => new Position(pos1.X / times, pos1.Y / times);
    }
}
