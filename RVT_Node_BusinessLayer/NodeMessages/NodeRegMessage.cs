using RVT_Node_BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeMessages
{
    public class NodeRegMessage
    {
        public RegistrationMessage Message { get; set; }

        public List<Node> NeighBours { get; set; }
    }
}
