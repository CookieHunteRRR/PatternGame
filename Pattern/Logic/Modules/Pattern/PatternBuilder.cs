using Pattern.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules.Pattern
{
    internal class PatternBuilder
    {
        private HashSet<Cell> usedCells;
        private PatternManager patternManager;
        private Cell startingCell;

        public List<PatternCommand> Commands { get; private set; }

        public PatternBuilder(Cell startingPoint)
        {
            usedCells = new HashSet<Cell>();
            Commands = new List<PatternCommand>();
            patternManager = Program.GameManager.UIManager.PatternBox.PatternManager;

            startingCell = startingPoint;
            startingCell.IsUsed = true;
            startingCell.IsStartingPoint = true;
            usedCells.Add(startingPoint);
        }

        /// <summary>
        /// По чудесной причине (см. ConnectCells в PatternManager) true в этом методе возвращается не в случае успешного выполнения кода, а в случае
        /// когда курсору консоли нужно перейти на позицию to
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool AddToPattern(Cell from, Cell to)
        {
            // проверяем, не пытается ли игрок вернуться на шаг назад
            if (Commands.Count > 0)
            {
                if (Commands[Commands.Count - 1].From.Equals(to))
                {
                    from.ResetCell();
                    usedCells.Remove(from);
                    // какие то жуткие костыли
                    var info = Program.GameManager.UIManager.PatternBox.GetAppropriateConnection(Commands[Commands.Count - 1]);
                    Commands.RemoveAt(Commands.Count - 1);
                    Console.SetCursorPosition(info.pos.X, info.pos.Y);
                    Console.Write(' ');
                    
                    //var toPos = to.GetConsolePosition();
                    //Console.SetCursorPosition(toPos.X, toPos.Y);
                    return true;
                }
            }

            // проверяем, не пытается ли игрок попасть в уже задействованную клетку
            if (usedCells.Contains(to)) return false;
            if (patternManager.UsedCells.Contains(to)) return false;

            from.IsUsed = true;
            to.IsUsed = true;

            usedCells.Add(from);
            usedCells.Add(to);
            Commands.Add(new PatternCommand(from, to));
            return true;
        }

        public void Apply()
        {
            patternManager.UsedCells.Add(startingCell);
            foreach (var command in Commands)
            {
                patternManager.UsedCells.Add(command.To);
                patternManager.RegisteredConnections.Add(command);
            }

            usedCells.Clear();
            Commands.Clear();
        }

        public void Reset()
        {
            startingCell.ResetCell();
            foreach (var command in Commands)
            {
                command.To.ResetCell();
            }

            Program.GameManager.UIManager.PatternBox.CutConnections();
            usedCells.Clear();
            Commands.Clear();
        }
    }
}
