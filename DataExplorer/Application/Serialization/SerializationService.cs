﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.Serialization
{
    public class SerializationService : ISerializationService
    {
        public Project GetProject()
        {
            // TODO: Remove this fake data
            var project = new Project()
            {
                Columns = GetColumns(),
                Rows = GetRows(),
                ScatterPlot = GetViews().Single()
            };

            return project;
        }

        private List<Column> GetColumns()
        {
            
            var column1 = new Column(1, 0, "X", typeof(Double), 0d, 1000d);
            var column2 = new Column(2, 1, "Y", typeof(Double), 0d, 1000d);
            var columns = new List<Column> { column1, column2 };
            return columns;
        }

        private List<Row> GetRows()
        {
            // TODO: Remove this fake data
            var row1 = new Row(new List<object>() { 0d, 0d });
            var row2 = new Row(new List<object>() { 1000d, 0d });
            var row3 = new Row(new List<object>() { 0d, 1000d });
            var row4 = new Row(new List<object>() { 1000d, 1000d });
            var rows = new List<Row> { row1, row2, row3, row4 };
            return rows;
        }

        private List<IScatterPlot> GetViews()
        {
            // TODO: Remove this fake data
            //var plot1 = new Plot() { X = 0, Y = 0 };
            //var plot2 = new Plot() { X = 1000, Y = 1000 };
            //var plots = new List<Plot>() { plot1, plot2 };
            var scatterPlot = new Domain.ScatterPlots.ScatterPlot();
            return new List<IScatterPlot>() { scatterPlot };
        }
    }
}