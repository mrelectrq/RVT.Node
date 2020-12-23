using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVT_Node_BusinessLayer;
using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RVT_Node_X.Controllers
{
    [Route("api/[controller]")]
    public class VoteController : Controller
    {
        IVote check;
        
        public VoteController()
        {
            var _bl = new BusinessManager();
            check = _bl.Vote();
        }
        [HttpPost]
        public ActionResult<NodeVoteResponse> Post([FromBody] NodeVoteMessage data)
        {
            var response =  check.Vote(data);

            return response.Result;
        }

    }
}
