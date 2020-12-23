using RVT_Node_BusinessLayer.Implementation;
using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVT_Node_BusinessLayer.Levels
{
    public class VoteLevel : VoteImplementation, IVote
    {
        public Task<NodeVoteResponse> Vote(NodeVoteMessage vote)
        {
            return VoteAction(vote);
        }
    }
}
