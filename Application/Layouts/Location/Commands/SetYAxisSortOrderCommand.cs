﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Location.Commands
{
    public class SetYAxisSortOrderCommand : BaseSetLayoutSortOrderCommand
    {
        public SetYAxisSortOrderCommand(SortOrder sortOrder) : base(sortOrder)
        {
        }
    }
}
