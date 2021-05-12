using System;
using System.Text;
using System.Threading.Tasks;
using RVTLibrary.Algoritms;
using RVT_Node_BusinessLayer.NodeResponses;
using RVT_Node_BusinessLayer.NodeMessages;
using System.Net.Http;
using System.Linq;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RVT_Node_BusinessLayer.Blockchain;
using DataLayer;
using Newtonsoft.Json;
using RVT_Node_BusinessLayer.BusinessModels;
using RVT_Node_BusinessLayer.Consensus;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RVT_Node_BusinessLayer.Implementation
{
    public class VoteImplementation
    {
        //Client
        internal async Task<NodeVoteResponse> VoteAction(NodeVoteMessage data)
        {
            string temporaryIDBD = "";
            string toHash="";

            using (var context = new Themis_SystemContext())
            {
                var account = await context.NprData.FirstOrDefaultAsync(m => m.Idvn == data.message.IDVN);
                if (account == null)
                {
                    return new NodeVoteResponse { Status = false, Message = "Account nu a fost gasit", ProcessedTime = DateTime.Now };
                }
                toHash = account.Idvn + account.HashAds;
                temporaryIDBD = Cipher.Encrypt(toHash, account.Idvn);
            }
            string hashAds = "";

            foreach( var neighbors in data.NeighBours)
            {
                hashAds += "_" + neighbors.NodeId;
            }
           var key = Cipher.Encrypt(temporaryIDBD + hashAds, data.message.IDVN);
            var consensusManager = new VoteManager();
            var nodeTasks = consensusManager.FormateMessage(data.NeighBours, Convert.FromBase64String(key),Convert.FromBase64String(data.message.IDVN));
            var response = consensusManager.CheckNodesValidation(nodeTasks);

            
            if (response.Item2 == true)
            {
                string IDBD = Cipher.Encrypt(data.message.IDVN, response.Item1);
                var chain = new Chain(new SqlDataProvider());
                var block = chain.GenBlock(data.message, IDBD);

                chain.Add(block);

                using (var db = new Themis_SystemContext())
                {
                    var node = NodeConfig.GetInstance();
                    var npv = new NpvData();
                    npv.Idbd = data.message.IDVN;
                    npv.HashAds = hashAds;
                    npv.IntroducedBy = node.NodeId;
                    npv.Repdate = DateTime.Now;
                    db.Add(npv);
                    db.SaveChanges();
                    return new NodeVoteResponse { block = block, Message = "Succes Voted", ProcessedTime = DateTime.Now, Status = true, IDVN = data.message.IDVN };
                }
            }
            else return new NodeVoteResponse { Status = false, Message = "Error validating Vote verification"+response.Item3 , ProcessedTime=DateTime.Now,IDVN = data.message.IDVN};


        }
    }
}
