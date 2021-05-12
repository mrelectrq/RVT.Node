
using DataLayer.Models;
using Newtonsoft.Json;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using RVTLibrary.Algoritms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RVT_Node_BusinessLayer.Implementation
{
    public class UserImplement
    {
        internal NodeRegResponse RegistrationAction(NodeRegMessage data)
        {
            var crc = new Crc32();
            var VnPassword = crc.Get(Encoding.ASCII.GetBytes(
                data.Message.Name + data.Message.Surname + data.Message.Surname)).ToString();

            var IDVN = IDVN_Gen.HashGen(VnPassword + data.Message.IDNP);

            string toHash = IDVN;
            string node_ids = "";
            foreach (var i in data.NeighBours)
            {
                node_ids += "_" + i.NodeId;
            }
            toHash += node_ids;
            var IDBD = Cipher.Encrypt(toHash, IDVN);
            var request = new NodeRegVerification { IDVN = IDVN, IDBD = IDBD };

            Task<NodeRegVerifResp>[] taskArray = new Task<NodeRegVerifResp>[data.NeighBours.Count];


            var max_i = 0;
            foreach (var i in data.NeighBours)
            {
                taskArray[max_i] = Task<NodeRegVerifResp>.Factory.StartNew(() => VerificationAction(request, i.IpAddress));
                max_i++;            
            }

            Task.WaitAll(taskArray);

            var result = new NodeRegVerifResp[taskArray.Length];
            for (int i = 0; i <= taskArray.Length-1; i++)
            {
                result[i] = taskArray[i].Result;
            }

            var allAreTheSame = result.All(a => a.Status == true);
            if (allAreTheSame == true) // continue
            {
                using (var db = new Themis_SystemContext())
                {
                    var account = new ConsensusAccounts();
                    account.Idbd = IDBD;
                    account.RepDateTime = DateTime.Now;
                    account.RepByNodeR = "Node_1";
                    account.Software = "1.0.1";

                    var npr_data = new NprData();
                    npr_data.Idvn = IDVN;
                    npr_data.HashAds = node_ids;
                    npr_data.IntroducedBy = "Node_1";
                    npr_data.Repdate = DateTime.Now;
                    db.Add(account);
                    db.Add(npr_data);
                    db.SaveChanges();
                }

                return new NodeRegResponse { IDVN = IDVN, Message = "Saved", IDNP = data.Message.IDNP, VnPassword = VnPassword, Status = true };
            }
            else
                return new NodeRegResponse { Status = false, Message = "Error node verification" };
        }


        private NodeRegVerifResp VerificationAction(NodeRegVerification data, string ip)
        {

            var data_req = data.Serialize();
            var content = new StringContent(data_req, Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(ip);


            

            try
            {
                var response = client.PostAsync("api/RegVerification", content);
                var stringResponse = response.Result.Content.ReadAsStringAsync().Result;
                var responseFromNode =  JsonConvert.DeserializeObject<NodeRegVerifResp>(stringResponse);
                return responseFromNode;
            }
            catch (AggregateException e)
            {
                return new NodeRegVerifResp { Status = false, Message = e.Message, ProcessedTime = DateTime.Now };
            }

        }



    }
}
