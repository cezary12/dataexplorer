﻿using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.FilterTrees.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Tests.FilterTrees;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Navigation.NavigationTree
{
    [TestFixture]
    public class NavigationTreeViewModelTests
    {
        private NavigationTreeViewModel _viewModel;
        private Mock<IMessageBus> _service;
        private bool _wasTreeNodeViewModelChangedRaised;
        private FakeFilterTreeNode _fakeFilterTreeNode;
        private List<FilterTreeNode> _filterTreeNodes;

        [SetUp]
        public void SetUp()
        {
            _fakeFilterTreeNode = new FakeFilterTreeNode();
            _filterTreeNodes = new List<FilterTreeNode> { _fakeFilterTreeNode };

            _service = new Mock<IMessageBus>();
            _service.Setup(p => p.Execute(It.IsAny<GetRootFilterTreeNodesQuery>()))
                .Returns(_filterTreeNodes);

            _viewModel = new NavigationTreeViewModel(_service.Object);
            _viewModel.PropertyChanged += (s, e) =>
                { if (e.PropertyName == "TreeNodeViewModels") _wasTreeNodeViewModelChangedRaised = true; };

        }

        [Test]
        public void TestHandleCsvFileImportingEventShouldClearRootNodeViewModels()
        {
            _viewModel.Handle(new CsvFileImportingEvent());
            Assert.That(_viewModel.TreeNodeViewModels.Count(), Is.EqualTo(0));
            Assert.That(_wasTreeNodeViewModelChangedRaised, Is.True);
        }

        [Test]
        public void TestHandleCsvFileImportedEventShouldCreateRootNodeViewModels()
        {
            _viewModel.Handle(new CsvFileImportedEvent());
            var results = _viewModel.TreeNodeViewModels;
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(_wasTreeNodeViewModelChangedRaised, Is.True);
        }

        [Test]
        public void TestHandleProjectOpeningEventShouldClearRootNodeViewModels()
        {
            _viewModel.Handle(new ProjectOpeningEvent());
            Assert.That(_viewModel.TreeNodeViewModels.Count(), Is.EqualTo(0));
            Assert.That(_wasTreeNodeViewModelChangedRaised, Is.True);
        }

        [Test]
        public void TestHandleProjectOpenedEventShouldCreateRootNodeViewModels()
        {
            _viewModel.Handle(new CsvFileImportedEvent());
            var results = _viewModel.TreeNodeViewModels;
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(_wasTreeNodeViewModelChangedRaised, Is.True);
        }
    }


}
