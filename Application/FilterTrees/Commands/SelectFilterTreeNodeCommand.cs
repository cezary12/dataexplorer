﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Commands
{
    public class SelectFilterTreeNodeCommand : EntityCommand<FilterTreeNode>
    {
        public SelectFilterTreeNodeCommand(FilterTreeNode entity) : base(entity)
        {
        }
    }
}
