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
            Console.SetCursorPosition(0, 0);
            while (_isRunning)
            {
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
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
