using RVT_Node_BusinessLayer.BusinessModels;
using RVTLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeMessages
{
    public class NodeVoteVerification
    {
        public byte[] IDVN{ get; set; }
        public byte[] IDBD { get; set; }
        public List<NodeNeighbor> ConsensusParticipants { get; set; }
    }
}
