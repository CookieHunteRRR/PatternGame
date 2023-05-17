﻿using Pattern.Logic.UI;
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
        private int stepBetweenCells = 2; // количество рядов/столбцов между двумя клетками

        public Cell SelectedCell { get; set; }

        internal PatternManager(PatternBox box)
        {
            patternBox = box;
            cellMap = new Dictionary<(int X, int Y), Cell>();

            GenerateCells();
        }

        internal void TryMoveTo(ConsoleKey direction)
        {
            var currentOffset = SelectedCell.Element.Offset;

            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    ChangeSelectedCell(GetAppropriateOffset(currentOffset, (0, -2)));
                    return;
                case ConsoleKey.LeftArrow:
                    ChangeSelectedCell(GetAppropriateOffset(currentOffset, (-2, 0)));
                    return;
                case ConsoleKey.RightArrow:
                    ChangeSelectedCell(GetAppropriateOffset(currentOffset, (2, 0)));
                    return;
                case ConsoleKey.DownArrow:
                    ChangeSelectedCell(GetAppropriateOffset(currentOffset, (0, 2)));
                    return;
            }
        }

        internal Position GetAppropriateOffset(Position origOffset, (int X, int Y) toWhere)
        {
            bool isMovedByX = (toWhere.X == 0) ? false : true;
            var newOffset = new Position(origOffset.X + toWhere.X, origOffset.Y + toWhere.Y);

            if (isMovedByX) // для передвижения вправо/влево
            {
                // если новый оффсет выходит за рамки
                if (!IsOffsetValid(newOffset)) return origOffset;
                // проверяем, является ли нужная клетка не занятой
                if (CanCellBeSelected(newOffset)) return newOffset;
                // проверяем, является ли стоящая за нужной клетка не занятой
                newOffset.X += toWhere.X;
                if (CanCellBeSelected(newOffset)) return newOffset;
                newOffset.X -= toWhere.X;
                for (int x = newOffset.X; (x <= 5) && (x > 0); x += toWhere.X) // очень плохо
                {
                    for (int y = 1; y <= 5; y += stepBetweenCells)
                    {
                        if (y == newOffset.Y) continue;
                        if (CanCellBeSelected((x, y))) return new Position(x, y);
                    }
                }
            }
            else // для передвижения вверх/вниз
            {
                if (!IsOffsetValid(newOffset)) return origOffset;
                if (CanCellBeSelected(newOffset)) return newOffset;
                newOffset.X += toWhere.X;
                if (CanCellBeSelected(newOffset)) return newOffset;
                newOffset.X -= toWhere.X;
                /* Я все это забуду если не запишу
                 * В первом цикле newOffset.Y т.к. мы идем вверх/вниз не с начала, а с неизвестной позиции (т.е. может быть как 1, так 3, так и 5)
                 * Условие сложнее, т.к. опять же мы не знаем заранее, вверх мы идем или вниз, проверяем и то и другое
                 * y += toWhere.Y, по той же причине что и с условием. toWhere.Y по сути и есть направление
                 * Второй цикл соответственно поиск первой подходящей клетки, с пропуском того Y, по которому мы шли двумя функциями выше
                 */
                for (int y = newOffset.Y; (y <= 5) && (y > 0); y += toWhere.Y)
                {
                    for (int x = 1; x <= 5; x += stepBetweenCells)
                    {
                        if (x == newOffset.X) continue;
                        if (CanCellBeSelected((x, y))) return new Position(x, y);
                    }
                }
            }
            // Если все клетки недоступны - возвращаем изначальные координаты
            return origOffset;
        }

        private void ChangeSelectedCell(Position newOffset)
        {
            SelectedCell = cellMap[(newOffset.X, newOffset.Y)];
            Console.SetCursorPosition(newOffset.X, newOffset.Y);
        }

        private void GenerateCells()
        {
            for (int x = 1; x <= 5; x += 2)
            {
                for (int y = 1; y <= 5; y += 2)
                {
                    var cellElement = new CellElement(patternBox, x, y);
                    patternBox.AddElement(cellElement);
                    cellMap.Add((cellElement.Offset.X, cellElement.Offset.Y), cellElement.Cell);

                    //var value = (x * 3) + y + 1;
                }
            }

            SelectedCell = cellMap.Values.First();
        }

        private bool CanCellBeSelected(Position offset)
        {
            if (!IsOffsetValid(offset)) return false;
            if (cellMap[(offset.X, offset.Y)].IsUsed) return false;
            return true;
        }
        private bool CanCellBeSelected((int X, int Y) offset)
        {
            if (!IsOffsetValid(offset)) return false;
            if (cellMap[(offset.X, offset.Y)].IsUsed) return false;
            return true;
        }
        private bool IsOffsetValid(Position offset)
        {
            return cellMap.ContainsKey((offset.X, offset.Y));
        }
        private bool IsOffsetValid((int X, int Y) offset)
        {
            return cellMap.ContainsKey((offset.X, offset.Y));
        }
    }
}
