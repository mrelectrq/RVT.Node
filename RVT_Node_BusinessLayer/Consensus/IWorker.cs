using RVT_Node_BusinessLayer.NodeMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.Consensus
{
    public interface IWorker
    {
        public string Decrypt(string message);
    }
}
