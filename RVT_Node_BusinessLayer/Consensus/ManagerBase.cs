﻿using RVT_Node_BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.Consensus
{
    public abstract class ManagerBase : IManager
    {
        public abstract Tuple<string, bool, string> CheckNodesValidation(List<Tuple<List<string>, NodeNeighbor>> message);
        public abstract List<Tuple<List<string>, NodeNeighbor>> FormateMessage(IEnumerable<NodeNeighbor> nodes, byte[] data,byte[] key);
        protected abstract string GetBlockKey(List<string> input);
        protected abstract object Send(List<string> data,string Uri);

    }
}
