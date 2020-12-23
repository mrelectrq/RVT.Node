using RVT_Node_BusinessLayer.BusinessModels;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using RVTLibrary.Algoritms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RVT_Node_BusinessLayer.Implementation
{
    public class NodeVerifHandler
    {
        internal NodeRegVerifResp CheckHandlerAction(NodeRegVerification message)
        {   
            var content = Cipher.Decrypt(message.IDBD, message.IDVN);
            var node = NodeConfig.GetInstance();

            bool status = content.Contains("_"+node.NodeId);

            if (status == true)
            {
                return new NodeRegVerifResp { Status = true, Message = "Confirmed", ProcessedTime = DateTime.Now };
            }
            else
                return new NodeRegVerifResp { Status = false, Message = "IDBD formated incorrectly", ProcessedTime = DateTime.Now };

        }

        internal NodeVoteVerifyResponse NodeVoteVerifyAction(NodeVoteVerification message)
        {
            var content = Cipher.Decrypt(Convert.ToBase64String(message.IDBD), Convert.ToBase64String(message.IDVN));
            var node = NodeConfig.GetInstance();
            bool status = content.Contains(node.NodeId);
            int position = message.ConsensusParticipants.FindIndex(m => m.NodeId == node.NodeId);
            if(status == true)
            {
                return new NodeVoteVerifyResponse
                {
                    Status = true,
                    Message = "Confirmed",
                    ProcessedTime = DateTime.Now,
                    NodeID = node.NodeId,
                    Thumbprint = node.certificate.Thumbprint,
                    Position = position
                }; 
            }
            else
                return new NodeVoteVerifyResponse { Status = false, Message = "Key formated incorrectly", ProcessedTime = DateTime.Now };
           
        }
    }
}
