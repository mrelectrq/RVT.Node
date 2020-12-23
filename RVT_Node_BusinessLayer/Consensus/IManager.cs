using RVT_Node_BusinessLayer.BusinessModels;
using RVT_Node_BusinessLayer.NodeResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RVT_Node_BusinessLayer.Consensus
{
    public interface IManager 
    {
        public  List<Tuple<List<string>, Node>> FormateMessage(IEnumerable<Node> nodes, byte[] id,byte[] key);
        public Tuple<string,bool,string> CheckNodesValidation(List<Tuple<List<string>,Node>> message);
    }
}
