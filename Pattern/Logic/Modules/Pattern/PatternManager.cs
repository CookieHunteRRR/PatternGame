using Pattern.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules.Pattern
{
    /// <summary>
    /// Логическая составляющая "ну вот этого 3х3 квадрата в котором паттерны вводить короче".
    /// Тут содержится информация о доступных для взаимодействия клеток и прочей информации, которую можно конвертировать в отображаемую
    /// в консоли.
    /// </summary>
    internal class PatternManager
    {
        private Cell[,] cells;

        internal PatternManager()
        {
            cells = GenerateInitialArrayOfCells();
        }

        /// <summary>
        /// Переводит имеющуюся информацию о доступности клеток в отображаемый в консоли вид.
        /// </summary>
        public void DisplayAvailableCells()
        {
            for (int x = 0; x < cells.GetLength(0)+2; x++)
            {
                for (int y = 0; y < cells.GetLength(1)+2; y++)
                {
                    if (x % 2 == 0) // четные - строки с клетками
                    {
                        if (y % 2 == 0)
                        {
                            Console.Write(cells[x/2, y/2]);
                        }
                        else
                        {
                            Console.Write((char)UtilityChars.NoDirection);
                        }
                    }
                    else // нечетные - вспомогательные
                    {
                        if (y % 2 == 0)
                        {
                            Console.Write((char)UtilityChars.NoDirection);
                        }
                        else
                        {
                            Console.Write((char)UtilityChars.None);
                        }
                    }
                    
                }
                Console.WriteLine();
            }
        }

        private Cell[,] GenerateInitialArrayOfCells()
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
        }
    }
}
