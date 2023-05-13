using Pattern.Logic.Modules;
using Pattern.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic
{
    internal class GameManager
    {
        public InputManager InputManager { get; private set; }
        public PatternBox PatternBox { get; private set; }
        
        public GameManager()
        {
            InputManager = new InputManager();
        }

        public void StartGame()
        {
            PatternBox = new PatternBox(0, 0);
            PatternBox.Display();

            InputManager.HandleInput();
        }
    }
}
