using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.BusinessModels
{
    public class NodeNeighbor
    {
        public string Name { get; set; }
        public string NodeId { get; set; }
        public string SoftwareVersion { get; set; }
        public byte[] PublicKey { get; set; }
        public string IpAddress { get; set; }
    }
}
