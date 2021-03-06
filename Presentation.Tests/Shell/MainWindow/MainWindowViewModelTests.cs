﻿using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Legend;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Property;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Shell.MainMenu;
using DataExplorer.Presentation.Shell.MainWindow;
using DataExplorer.Presentation.Shell.StatusBar;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainWindow
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _viewModel;
        private Mock<IMainMenuViewModel> _mockMainMenuViewModel;
        private Mock<INavigationPaneViewModel> _mockNavigationPaneViewModel;
        private Mock<IViewerPaneViewModel> _mockViewerViewModel;
        private Mock<IFilterPaneViewModel> _mockFilterPaneViewModel;
        private Mock<ILayoutPaneViewModel> _mockLayoutPaneViewModel;
        private Mock<ILegendPaneViewModel> _mockLegendPaneViewModel;
        private Mock<IPropertyPaneViewModel> _mockPropertyPaneViewModel;
        private Mock<IStatusBarViewModel> _mockStatusBarViewModel;

        [SetUp]
        public void SetUp()
        {
            _mockViewerViewModel = new Mock<IViewerPaneViewModel>();
            _mockMainMenuViewModel = new Mock<IMainMenuViewModel>();
            _mockNavigationPaneViewModel = new Mock<INavigationPaneViewModel>();
            _mockFilterPaneViewModel = new Mock<IFilterPaneViewModel>();
            _mockLayoutPaneViewModel = new Mock<ILayoutPaneViewModel>();
            _mockLegendPaneViewModel = new Mock<ILegendPaneViewModel>();
            _mockPropertyPaneViewModel = new Mock<IPropertyPaneViewModel>();
            _mockStatusBarViewModel = new Mock<IStatusBarViewModel>();

            _viewModel = new MainWindowViewModel(
                _mockMainMenuViewModel.Object,
                _mockNavigationPaneViewModel.Object,
                _mockViewerViewModel.Object,
                _mockFilterPaneViewModel.Object,
                _mockLayoutPaneViewModel.Object,
                _mockLegendPaneViewModel.Object,
                _mockPropertyPaneViewModel.Object,
                _mockStatusBarViewModel.Object);
        }

        [Test]
        public void TestGetMainMenuViewModelShouldReturnViewModel()
        {
            var result = _viewModel.MainMenuViewModel;
            Assert.That(result, Is.EqualTo(_mockMainMenuViewModel.Object));
        }

        [Test]
        public void TestGetNavigationPaneViewModelShouldReturnViewModel()
        {
            var result = _viewModel.NavigationPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockNavigationPaneViewModel.Object));
        }

        [Test]
        public void TestGetViewerViewModelShouldReturnViewModel()
        {
            var result = _viewModel.ViewerPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockViewerViewModel.Object));
        }

        [Test]
        public void TestGetFilterPaneViewModelShouldReturnViewModel()
        {
            var result = _viewModel.FilterPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockFilterPaneViewModel.Object));
        }

        [Test]
        public void TestGetLayoutPaneViewModelShouldReturnViewModel()
        {
            var result = _viewModel.LayoutPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockLayoutPaneViewModel.Object));
        }

        [Test]
        public void TestGetLegendPaneViewModelShouldReturnViewModel()
        {
            var result = _viewModel.LegendPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockLegendPaneViewModel.Object));
        }

        [Test]
        public void TestGetPropertyPaneViewModelShouldReturnViewModel()
        {
            var result = _viewModel.PropertyPaneViewModel;
            Assert.That(result, Is.EqualTo(_mockPropertyPaneViewModel.Object));
        }

        [Test]
        public void TestGetStatusBarViewModelShouldReturnViewModel()
        {
            var result = _viewModel.StatusBarViewModel;
            Assert.That(result, Is.EqualTo(_mockStatusBarViewModel.Object));
        }
    }
}
