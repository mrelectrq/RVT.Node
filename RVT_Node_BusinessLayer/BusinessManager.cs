using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer
{
    public class BusinessManager
    {
        public IUser User()
        {
            return new UserLevel();
        }

        public INode NodeCommunication()
        {
            return new NodeLevel();
        }
        public IVote Vote()
        {
            return new VoteLevel();
        }


    }
}
