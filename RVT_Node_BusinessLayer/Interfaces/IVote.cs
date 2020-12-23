using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVT_Node_BusinessLayer.Interfaces
{
    public interface IVote
    {
        public Task<NodeVoteResponse> Vote(NodeVoteMessage chooser);
    }
}
