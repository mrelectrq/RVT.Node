using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RVT_Node_BusinessLayer;
using RVT_Node_BusinessLayer.Implementation;
using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;

namespace RVT_Node_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegVerificationController : ControllerBase
    {
        INode _check;

        public RegVerificationController()
        {
            var _bl = new BusinessManager();
            _check = _bl.NodeCommunication();
        }

        public ActionResult<NodeRegVerifResp> Post([FromBody] NodeRegVerification message)
        {
            var response = _check.CheckRegistrationHandler(message);
            return response;
        }
    }
}