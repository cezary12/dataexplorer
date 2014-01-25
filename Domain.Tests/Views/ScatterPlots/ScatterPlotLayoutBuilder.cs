﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    public class ScatterPlotLayoutBuilder
    {
        private readonly ScatterPlotLayout _layout;

        public ScatterPlotLayoutBuilder()
        {
            _layout = new ScatterPlotLayout();    
        }

        public ScatterPlotLayoutBuilder WithXAxisColumn(Column column)
        {
            _layout.XAxisColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithYAxisColumn(Column column)
        {
            _layout.YAxisColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithColorColumn(Column column)
        {
            _layout.ColorColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithColorPalette(ColorPalette colorPalette)
        {
            _layout.ColorPalette = colorPalette;
            return this;
        }

        public ScatterPlotLayout Build()
        {
            return _layout;
        }
    }
}
