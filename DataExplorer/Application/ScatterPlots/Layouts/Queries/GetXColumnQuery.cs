﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots.Layouts.Queries
{
    public class GetXColumnQuery : IGetXColumnQuery
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetXColumnQuery(
            IViewRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Query()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.XAxisColumn;

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
