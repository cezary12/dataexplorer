﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Lines.Queries
{
    public interface IGetScatterPlotYAxisGridLinesQuery
    {
        IEnumerable<CanvasLine> Execute(Size controlSize);
    }
}
