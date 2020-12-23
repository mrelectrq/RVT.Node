using RVT_Node_BusinessLayer.Blockchain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeResponses
{
    public class NodeVoteResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public DateTime ProcessedTime { get; set; }
        public Block block { get; set; }
    }
}
