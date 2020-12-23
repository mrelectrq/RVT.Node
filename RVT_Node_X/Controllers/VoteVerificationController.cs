using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RVT_Node_BusinessLayer;
using RVT_Node_BusinessLayer.BusinessModels;
using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;
using RVTLibrary.Algoritms;

namespace RVT_Node_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VoteVerificationController : ControllerBase
    {
        INode check;

        public VoteVerificationController()
        {
            var _bl = new BusinessManager();
            check = _bl.NodeCommunication();
        }
        [HttpPost]
        public ActionResult<NodeVoteVerifyResponse> Post([FromBody] List<string> message)
        {
            var content = RSAEncryption.Decrypt(message,
                NodeConfig.GetInstance().certificate.PrivateKey.ExportPkcs8PrivateKey());
            NodeVoteVerification verification;
            try
            {
                verification = JsonConvert.DeserializeObject<NodeVoteVerification>(Encoding.UTF8.GetString(content));
            }
            catch
            {
                return new NodeVoteVerifyResponse() { Status = false, Message = "Formatul mesajului este invalid" };
            }
            var response = check.CheckVoteHandler(verification);
            return response;
        }
    }
}