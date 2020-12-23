using RVTLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeResponses
{
    public class NodeVoteVerifyResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public DateTime ProcessedTime { get; set; }
        public string Thumbprint { get; set; }
        public int Position {get; set; }
        public string NodeID { get; set; }
    }
}
