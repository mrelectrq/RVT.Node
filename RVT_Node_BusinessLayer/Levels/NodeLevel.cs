using RVT_Node_BusinessLayer.Implementation;
using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.Levels
{
    public class NodeLevel : NodeVerifHandler, INode
    {
        public NodeRegVerifResp CheckRegistrationHandler(NodeRegVerification message)
        {
            return CheckHandlerAction(message);
        }

        public NodeVoteVerifyResponse CheckVoteHandler(NodeVoteVerification message)
        {
            return NodeVoteVerifyAction(message);
        }
    }
}
