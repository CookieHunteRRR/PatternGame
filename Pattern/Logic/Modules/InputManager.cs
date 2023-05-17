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
            var uiManager = Program.GameManager.UIManager;
            var patternManager = uiManager.PatternBox.PatternManager;

            /*var cursorPos = patternManager.SelectedCell.GetConsolePosition();
            Console.SetCursorPosition(cursorPos.X, cursorPos.Y);*/
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
                    case ConsoleKey.Enter:
                        if (patternManager.PatternBuilder is null)
                        {
                            patternManager.EnterEditMode();
                        }
                        else patternManager.ExitEditMode(true);
                        break;
                    case ConsoleKey.Backspace:
                        if (patternManager.PatternBuilder is not null)
                            patternManager.ExitEditMode(false);
                        break;
                    case ConsoleKey.Escape:
                        _isRunning = false;
                        break;
                    default:
                        break;
                }
                uiManager.UpdateUI();
            }
        }
    }
}
