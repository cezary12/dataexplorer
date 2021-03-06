﻿using System;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public abstract class AxisMap
    {
        protected readonly SortOrder _sortOrder;

        protected AxisMap()
        {
            _sortOrder = SortOrder.Descending;
        }

        protected AxisMap(SortOrder sortOrder)
        {
            _sortOrder = sortOrder;
        }

        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }

        public abstract double? Map(object value);

        public abstract object MapInverse(double? value);
    }
}
