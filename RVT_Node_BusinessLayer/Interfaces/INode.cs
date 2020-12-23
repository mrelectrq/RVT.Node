using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.Interfaces
{
    public interface INode
    {
        NodeRegVerifResp CheckRegistrationHandler(NodeRegVerification message);
        NodeVoteVerifyResponse CheckVoteHandler(NodeVoteVerification message);
    }
}
