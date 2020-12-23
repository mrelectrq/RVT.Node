using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RVT_Node_BusinessLayer;
using RVT_Node_BusinessLayer.Interfaces;
using RVT_Node_BusinessLayer.NodeMessages;
using RVT_Node_BusinessLayer.NodeResponses;

namespace RVT_Node_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RegisterController : ControllerBase
    {
        IUser _service;

        public RegisterController()
        {
            var _bl = new BusinessManager();
            _service = _bl.User();
        }


        [HttpPost]

        public ActionResult<NodeRegResponse> Register([FromBody] NodeRegMessage message)
        {
            var response = _service.Registration(message);




            return response;
        }
    }
}