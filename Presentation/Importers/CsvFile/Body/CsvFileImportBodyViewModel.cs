﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Importers.CsvFile.Body
{
    public class CsvFileImportBodyViewModel : 
        BaseViewModel,
        ICsvFileImportBodyViewModel,
        IEventHandler<CsvFileSourceChangedEvent>
    {
        private readonly IQueryBus _queryBus;

        public CsvFileImportBodyViewModel(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public List<SourceMapViewModel> MapViewModels
        {
            get { return GetMapViewModels(); }
        }

        private List<SourceMapViewModel> GetMapViewModels()
        {
            return _queryBus.Execute(new GetCsvFileSourceMapsQuery())
                .Select(p => new SourceMapViewModel(p))
                .ToList();
        }

        public void Handle(CsvFileSourceChangedEvent args)
        {
            OnPropertyChanged(() => MapViewModels);
        }
    }
}