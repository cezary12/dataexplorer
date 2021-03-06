﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Maps.LabelMaps;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Domain.Maps
{
    public class MapFactory : IMapFactory
    {
        private readonly IAxisMapFactory _axisMapFactory;
        private readonly IColorMapFactory _colorMapFactory;
        private readonly ISizeMapFactory _sizeMapFactory;
        private readonly ILabelMapFactory _labelMapFactory;

        public MapFactory(
            IAxisMapFactory axisMapFactory, 
            IColorMapFactory colorMapFactory,
            ISizeMapFactory sizeMapFactory, 
            ILabelMapFactory labelMapFactory)
        {
            _axisMapFactory = axisMapFactory;
            _colorMapFactory = colorMapFactory;
            _sizeMapFactory = sizeMapFactory;
            _labelMapFactory = labelMapFactory;
        }

        public AxisMap CreateAxisMap(Column column, double targetMin, double targetMax, SortOrder sortOrder)
        {
            return _axisMapFactory.Create(column, targetMin, targetMax, sortOrder);
        }

        public ColorMap CreateColorMap(Column column, ColorPalette colorPalette, SortOrder sortOrder)
        {
            return _colorMapFactory.Create(column, colorPalette, sortOrder);
        }

        public SizeMap CreateSizeMap(Column column, double targetMin, double targetMax, SortOrder sortOrder)
        {
            return _sizeMapFactory.Create(column, targetMin, targetMax, sortOrder);
        }

        public LabelMap CreateLabelMap(Column column)
        {
            return _labelMapFactory.Create(column);
        }
    }
}
