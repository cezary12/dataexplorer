﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Sizes.Factories;
using DataExplorer.Domain.Maps.SizeMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Sizes.Factories
{
    [TestFixture]
    public class FloatSizeLegendFactoryTests
    {
        private FloatSizeLegendFactory _factory;
        private Mock<SizeMap> _mockSizeMap;
        private List<double?> _values;
        private double? _value;
        private double? _size;
        private double _lowerSize;
        private double _upperSize;

        [SetUp]
        public void SetUp()
        {
            _values = new List<double?>();
            _value = 1d;
            _size = 0d;
            _lowerSize = 0d;
            _upperSize = 1d;

            _mockSizeMap = new Mock<SizeMap>();
            _mockSizeMap.Setup(p => p.Map(It.IsAny<double?>()))
                .Returns(_size);
            _mockSizeMap.Setup(p => p.MapInverse(It.IsAny<double>()))
                .Returns(_value);

            _factory = new FloatSizeLegendFactory();
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesLessThanFour()
        {
            AssertResult(3, 3);
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesAreEqualToFour()
        {
            AssertResult(4, 4);
        }

        [Test]
        public void TestCreateShouldCreateContinuousItemsIfValuesAreGreaterThanFour()
        {
            AssertResult(5, 3);
        }

        private void AssertResult(int valueCount, int expectedItemCount)
        {
            for (var i = 0; i < valueCount; i++)
                _values.Add(_value + i);

            var results = _factory.Create(_mockSizeMap.Object, _values, _lowerSize, _upperSize);
            Assert.That(results.Count(), Is.EqualTo(expectedItemCount));
            Assert.That(results.First().Size, Is.EqualTo(_size));
            Assert.That(results.First().Label, Is.EqualTo("1.00"));
        }
    }
}
