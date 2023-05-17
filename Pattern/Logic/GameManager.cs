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
        public UIManager UIManager { get; private set; }
        
        public GameManager()
        {
            InputManager = new InputManager();
            UIManager = new UIManager();
        }

        public void StartGame()
        {
            UIManager.CreateUI();
            InputManager.HandleInput();
        }
    }
}
