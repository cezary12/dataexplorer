﻿using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers.Grid
{
    public interface IYAxisGridLineRenderer
    {
        IEnumerable<CanvasLine> Render(IEnumerable<AxisGridLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
