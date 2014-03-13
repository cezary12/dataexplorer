﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Commands
{
    public class UpdateCsvFileSourceCommandHandler 
        : ICommandHandler<UpdateCsvFileSourceCommand>
    {
        private readonly ISourceRepository _repository;
        private readonly ICsvFileDataAdapter _dataAdapter;
        private readonly ISourceMapFactory _factory;
        private readonly IEventBus _eventBus;

        public UpdateCsvFileSourceCommandHandler(
            ISourceRepository repository, 
            ICsvFileDataAdapter dataAdapter, 
            ISourceMapFactory factory, 
            IEventBus eventBus)
        {
            _repository = repository;
            _dataAdapter = dataAdapter;
            _factory = factory;
            _eventBus = eventBus;
        }

        public void Execute(UpdateCsvFileSourceCommand command)
        {
            var source = _repository.GetSource<CsvFileSource>();

            source.FilePath = command.FilePath;

            var columns = _dataAdapter.GetColumns(source);

            var maps = columns
                .Select(p => _factory.Create(p))
                .ToList();

            source.SetMaps(maps);

            _eventBus.Raise(new CsvFileSourceChangedEvent());
        }
    }
}
