﻿using System;
using System.Collections.Generic;
using DataExplorer.Application;
using DataExplorer.Domain.Sources;
using DataExplorer.Persistence.Sources;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Sources
{
    [TestFixture]
    public class SourceRepositoryTests
    {
        private SourceRepository _repository;
        private Mock<IDataContext> _mockContext;
        private Dictionary<Type, Source> _sources;
            
        [SetUp]
        public void SetUp()
        {
            _sources = new Dictionary<Type, Source>();
            _mockContext = new Mock<IDataContext>();
            _mockContext.Setup(p => p.Sources).Returns(_sources); 
            _repository = new SourceRepository(_mockContext.Object);
        }

        [Test]
        public void TestGetSourceShouldReturnCsvFileSource()
        {
            var source = new CsvFileSource();
            _sources.Add(source.GetType(), source);
            var result = _repository.GetSource<CsvFileSource>();
            Assert.That(result, Is.EqualTo(source));
        }

        [Test]
        public void TestGetSourceShouldCreateNewSourceIfNoMatchExists()
        {
            _repository.GetSource<CsvFileSource>();
            Assert.That(_sources.ContainsKey(typeof(CsvFileSource)));
        }

        [Test]
        public void TestSetSourceShouldSetSetSource()
        {
            var source = new CsvFileSource();
            _repository.SetSource<CsvFileSource>(source);
            Assert.That(_sources[source.GetType()], Is.EqualTo(source));
        }
    }
}
