using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Logic.Modules.Pattern
{
    /// <summary>
    /// Используется для определения связи между двумя клетками
    /// </summary>
    internal enum DirectionInfo
    {
        Wall, // дефолтное значение / стена, в сторону которой нельзя идти
        Free, // в эту сторону есть незанятая доступная клетка
        Blocked, // в этой стороне есть занятая или заблокированная клетка
        PointIn, // из этой стороны в эту клетку идет стрелка (x←•)
        PointOut // в эту сторону из этой клетки идет стрелка (x→•)
    }
}
