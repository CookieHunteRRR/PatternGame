using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.UI
{
    internal class InputBox : UIBox
    {
        private int currentInputXOffset;

        //private StringBuilder currentInput;
        private List<string> enteredPatterns;
        //public string SelectedCellValue { get; set; }
        public int CellCount { get; set; }
        public bool PassedCenter { get; set; }

        public InputBox(int x, int y) : base(x, y)
        {
            //currentInput = new StringBuilder();
            enteredPatterns = new List<string>();
        }

        public void AddToCurrentInput(string input, bool isFinal)
        {
            //currentInput.Append(input);
            //if (!isFinal) currentInput.Append("-");
        }

        public void ResetInputs()
        {
            enteredPatterns.Clear();

            //currentInput.Clear();
            
            //SelectedCellValue = string.Empty;
            CellCount = 0;
            PassedCenter = false;
        }

        public override void InitialDisplay()
        {
            var patternManager = Program.GameManager.UIManager.PatternBox.PatternManager;

            Console.SetCursorPosition(base.Position.X, base.Position.Y);
            string inputString = "Ввод: ";
            currentInputXOffset = inputString.Length;
            Console.Write(inputString + patternManager.SelectedCell.Value);

            ResetInputs();
        }

        public new void Display()
        {
            var patternManager = Program.GameManager.UIManager.PatternBox.PatternManager;

            Console.SetCursorPosition(base.Position.X + currentInputXOffset, base.Position.Y);
            //Console.Write(currentInput.ToString());
            Console.Write(patternManager.SelectedCell.Value);
            if (CellCount > 0) Console.Write($" x{CellCount}");
            if (PassedCenter) Console.Write("+");
            int currentY = Console.GetCursorPosition().Top;
            foreach (string pattern in enteredPatterns)
            {
                currentY++;
                Console.SetCursorPosition(base.Position.X, currentY);
                Console.Write(pattern);
            }
        }
    }
}
