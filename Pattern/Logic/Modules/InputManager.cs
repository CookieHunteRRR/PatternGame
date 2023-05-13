using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules
{
    internal class InputManager
    {
        private bool _isRunning = true;

        public void HandleInput()
        {
            var patternManager = Program.GameManager.PatternBox.PatternManager;

            var cursorPos = patternManager.SelectedCell.GetConsolePosition();
            Console.SetCursorPosition(cursorPos.Y, cursorPos.Y);
            while (_isRunning)
            {
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        patternManager.TryMoveTo(input.Key);
                        break;
                    case ConsoleKey.Escape:
                        _isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
