using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI
{
    internal class UIManager
    {
        public PatternBox PatternBox { get; private set; }
        public InputBox InputBox { get; private set; }

        public UIManager()
        {
            PatternBox = new PatternBox(0, 0);
            InputBox = new InputBox(0, 8);
        }

        public void CreateUI()
        {
            PatternBox.InitialDisplay();
            InputBox.InitialDisplay();

            var selCellPos = PatternBox.PatternManager.SelectedCell.GetConsolePosition();
            Console.SetCursorPosition(selCellPos.X, selCellPos.Y);
        }

        public void UpdateUI()
        {
            PatternBox.Display();
            InputBox.Display();

            var selCellPos = PatternBox.PatternManager.SelectedCell.GetConsolePosition();
            Console.SetCursorPosition(selCellPos.X, selCellPos.Y);
        }
    }
}
