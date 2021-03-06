﻿using System.Collections.Generic;
using DataExplorer.Application.Application;
using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Exporters;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Clipboard.Commands
{
    [TestFixture]
    public class CopyDataToClipboardCommandHandlerTests
    {
        private CopyDataToClipboardCommandHandler _handler;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<ITabExporter> _mockTabExporter;
        private Mock<IClipboard> _mockClipboard;
        private List<Column> _columns;
        private List<Row> _rows;
        private string _text;

        [SetUp]
        public void SetUp()
        {
            _columns = new List<Column>();
            _rows = new List<Row>();
            _text = "Test";

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.GetAll()).Returns(_columns);

            _mockStateService = new Mock<IApplicationStateService>();
            _mockStateService.Setup(p => p.GetSelectedRows()).Returns(_rows);

            _mockTabExporter = new Mock<ITabExporter>();
            _mockTabExporter.Setup(p => p.Export(_columns, _rows)).Returns(_text);

            _mockClipboard = new Mock<IClipboard>();

            _handler = new CopyDataToClipboardCommandHandler(
                _mockColumnRepository.Object,
                _mockStateService.Object,
                _mockTabExporter.Object,
                _mockClipboard.Object);
        }

        [Test]
        public void TestCopyShouldCopyDataToClipboard()
        {
            _handler.Execute(new CopyDataToClipboardCommand());
            _mockClipboard.Verify(p => p.SetText(_text));
        }
    }
}
