﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Renderers.Plots
{
    [TestFixture]
    public class PlotRendererTests
    {
        private PlotRenderer _renderer;
        private Mock<IViewResizer> _mockResizer;
        private Mock<IScaleComputer> _mockComputer;
        private Mock<IGeometryCalculator> _mockCalculator;
        private Mock<IGeometryFactory> _mockFactory;
        private Size _controlSize;
        private Rect _viewExtent;
        private PlotDto _plot;
        private List<PlotDto> _plots;
        private CanvasCircle _circle;
        private CanvasLabel _label;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _plot = new PlotDto()
            {
                Id = 1, 
                X = 1d, 
                Y = 2d, 
                Color = new Domain.Colors.Color(0, 0, 0),
                Label = "Test"
            };
            _plots = new List<PlotDto> { _plot };
            _circle = new CanvasCircle();
            _label = new CanvasLabel();

            _mockResizer = new Mock<IViewResizer>();
            _mockResizer.Setup(p => p.ResizeView(_controlSize, _viewExtent))
                .Returns(_viewExtent);

            _mockComputer = new Mock<IScaleComputer>();
            _mockComputer.Setup(p => p.ComputeScale(_controlSize, _viewExtent)).Returns(1d);

            _mockCalculator = new Mock<IGeometryCalculator>();

            _mockFactory = new Mock<IGeometryFactory>();
            _mockFactory.Setup(p => p.CreateCircle(_plot.Id, It.IsAny<Rect>(), It.IsAny<Color>()))
                .Returns(_circle);
            _mockFactory.Setup(p => p.CreateLabel(_plot.Id, It.IsAny<Point>(), _plot.Label))
                .Returns(_label);

            _renderer = new PlotRenderer(
                _mockResizer.Object,
                _mockComputer.Object,
                _mockCalculator.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestRenderPlotsShouldReturnCircle()
        {
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, Has.Member(_circle));
        }

        [Test]
        public void TestRenderPlotsShouldReturnLabel()
        {
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, Has.Member(_label));
        }

        [Test]
        public void TestRenderPlotsShouldNotReturnLabelIfLabelIsNull()
        {
            _plot.Label = null;
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, !Has.Member(_label));
        }

        [Test]
        public void TestRenderPlotsShouldNotReturnLabelIfLabelIsEmpty()
        {
            _plot.Label = string.Empty;
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, !Has.Member(_label));
        }
    }
}