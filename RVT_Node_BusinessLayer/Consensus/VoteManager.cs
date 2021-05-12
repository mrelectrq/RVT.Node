using Newtonsoft.Json;
using RVT_Node_BusinessLayer.BusinessModels;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using RVTLibrary.Algoritms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RVT_Node_BusinessLayer.Consensus
{
    public class VoteManager : ManagerBase
    {
        
        public override Tuple<string, bool, string> CheckNodesValidation(List<Tuple<List<string>, NodeNeighbor>> tasks)
        {
            // T1 = hash ads for idbd
            // T2 = status
            // T3 = message
            List<Tuple<string, NodeNeighbor>> todo = new List<Tuple<string, NodeNeighbor>>();
            Task<NodeVoteVerifyResponse>[] taskArray = new Task<NodeVoteVerifyResponse>[tasks.Count];

            int i = 0;
            foreach (var task in tasks)
            {
                taskArray[i] = Task<NodeVoteVerifyResponse>.Factory.StartNew(() =>
               (NodeVoteVerifyResponse)Send(task.Item1, task.Item2.IpAddress));
                i++;
            }
            Task.WaitAll(taskArray);

            bool status = true;
            var result = new  NodeVoteVerifyResponse[taskArray.Length];

            for (int y = 0; y <= taskArray.Length - 1; y++)
            {
                result[y] = taskArray[y].Result;
            }
            var allAreTheSame = result.All(a => a.Status == true);


            var nodeIdToIndex = tasks.Select(t => t.Item2.NodeId).Distinct().ToDictionary(nodeid => nodeid,
                nodeId => tasks.FindIndex(t => t.Item2.NodeId == nodeId));

            var sortedResponses = from noderesponse in result
                                  orderby nodeIdToIndex[noderesponse.NodeID]
                                  select noderesponse;

            if (allAreTheSame)
            {
                foreach (var item in sortedResponses)
                {
                    if (tasks[item.Position].Item2.NodeId != item.NodeID)
                    {
                        status = false;
                        return new Tuple<string, bool, string>(null, status, "NodesValidationError .. See NodeLogs at "
                                + DateTime.Now.ToString());
                    }
                }
                var hashads = GetBlockKey(sortedResponses.Select(m=>m.Thumbprint).ToList());

                return new Tuple<string, bool, string>(hashads, true, "Validation executed succesefull");

            
            }
            else
            {
                status = false;
                return new Tuple<string, bool, string>(null, status, "NodesValidationError .. See NodeLogs at "
                  + DateTime.Now.ToString());
            }
        }
        public override List<Tuple<List<string>, NodeNeighbor>> FormateMessage(IEnumerable<NodeNeighbor> nodes, byte[] IDBD, byte[] key)
        {
            var orderedNodes = nodes.OrderBy(ord => new Random().Next()).ToList();
            var participants = new List<Tuple<List<string>, NodeNeighbor>>();

            foreach (var i in orderedNodes)
            {
                var message = new NodeVoteVerification() { IDBD = IDBD, ConsensusParticipants = orderedNodes,IDVN=key };
                var packet = JsonConvert.SerializeObject(message);

                var byte_message = ASCIIEncoding.UTF8.GetBytes(packet);
                var pubkey = i.PublicKey;
                var encrypted = RSAEncryption.Encrypt(byte_message, pubkey);

                //  var encryptedMessageString = Encoding.ASCII.GetString(encrypted);              
                
                participants.Add(new Tuple<List<string>, NodeNeighbor>(encrypted, i));
            }
            return participants;
        }
        protected override string GetBlockKey(List<string> input)
        {
            var ads = "";
            foreach (var i in input)
            {
                ads += i;
            }
            return ads;
        }

        protected override object Send(List<string> data, string ip)
        {
            var handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(ip);
            string message = JsonConvert.SerializeObject(data);
            var body = new StringContent(message ,Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/VoteVerification", body);

            try
            {
                var stringResponse = response.Result.Content.ReadAsStringAsync().Result;
                var responseFromNode = JsonConvert.DeserializeObject<NodeVoteVerifyResponse>(stringResponse);
                return responseFromNode;
            }
            catch (AggregateException e)
            {
                return new NodeVoteVerifyResponse
                {
                    Status = false,
                    Message = "Eroare de conexiune \r\n" + e.Message
                };
            }
        }
    }
}
