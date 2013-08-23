﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.ScatterPlots
{
    public interface IScatterPlotRenderer
    {
        List<Plot> RenderPlots(List<Row> rows, ScatterPlotLayout layout);
    }
}