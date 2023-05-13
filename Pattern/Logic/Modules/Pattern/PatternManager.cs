using Pattern.Logic.UI;
using Pattern.Logic.UI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pattern.Logic.Modules.Pattern
{
    /// <summary>
    /// Логическая составляющая "ну вот этого 3х3 квадрата в котором паттерны вводить короче".
    /// Тут содержится информация о доступных для взаимодействия клеток и прочей информации, которую можно конвертировать в отображаемую
    /// в консоли.
    /// </summary>
    internal class PatternManager
    {
        private PatternBox patternBox;
        private Dictionary<(int X, int Y), Cell> cellMap;
        //private Cell[,] cells;
        public Cell SelectedCell { get; set; }

        internal PatternManager(PatternBox box)
        {
            patternBox = box;
            cellMap = new Dictionary<(int X, int Y), Cell>();

            GenerateCells();

            /*patternBox
            elements.Add(new CellElement(this, 1, 1));
            elements.Add(new CellElement(this, 3, 1));
            elements.Add(new CellElement(this, 5, 1));
            elements.Add(new CellElement(this, 1, 3));
            elements.Add(new CellElement(this, 3, 3));
            elements.Add(new CellElement(this, 5, 3));
            elements.Add(new CellElement(this, 1, 5));
            elements.Add(new CellElement(this, 3, 5));
            elements.Add(new CellElement(this, 5, 5));*/
        }

        internal void TryMoveTo(ConsoleKey direction)
        {
            var patternManager = Program.GameManager.PatternBox.PatternManager;
            var currentOffset = SelectedCell.Element.Offset;

            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    if (currentOffset.Y - 2 >= 1)
                    {
                        ChangeSelectedCell(currentOffset.X, currentOffset.Y - 2);
                        return;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentOffset.X - 2 >= 1)
                    {
                        ChangeSelectedCell(currentOffset.X - 2, currentOffset.Y);
                        return;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentOffset.X + 2 <= 5)
                    {
                        ChangeSelectedCell(currentOffset.X + 2, currentOffset.Y);
                        return;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentOffset.Y + 2 <= 5)
                    {
                        ChangeSelectedCell(currentOffset.X, currentOffset.Y + 2);
                        return;
                    }
                    break;
            }

            //(int X, int Y) pos = (patternBox.Position.X + SelectedCell.Element.Offset.X,
            //                      patternBox.Position.Y + SelectedCell.Element.Offset.Y);
            
        }

        private void ChangeSelectedCell(int newX, int newY)
        {
            SelectedCell = cellMap[(newX, newY)];

            (int X, int Y) pos = (patternBox.Position.X + newX,
                                  patternBox.Position.Y + newY);
            Console.SetCursorPosition(pos.X, pos.Y);
        }

        private void GenerateCells()
        {
            for (int x = 1; x <= 5; x += 2)
            {
                for (int y = 1; y <= 5; y += 2)
                {
                    var cellElement = new CellElement(patternBox, x, y);
                    patternBox.AddElement(cellElement);
                    cellMap.Add(cellElement.Offset, cellElement.Cell);

                    //var value = (x * 3) + y + 1;
                }
            }

            SelectedCell = cellMap.Values.First();
        }

        /*private Cell[,] GenerateInitialArrayOfCells()
        {
            var arr = new Cell[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var value = (x * 3) + y + 1;
                    var left = (y == 0) ? DirectionInfo.Wall : DirectionInfo.Free;
                    var top = (x == 0) ? DirectionInfo.Wall : DirectionInfo.Free;
                    var right = (y == 2) ? DirectionInfo.Wall : DirectionInfo.Free;
                    var bottom = (x == 2) ? DirectionInfo.Wall : DirectionInfo.Free;
                    arr[x, y] = new Cell(value, new DirectionInfo[] { left, top, right, bottom });
                }
            }

            return arr;
        }*/
    }
}
