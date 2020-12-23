using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeResponses
{
    public class NodeRegResponse
    {
        /// <summary>
        /// Raspunsul unui nod catre LoadBalancer
        /// </summary> 
        public string IDVN { get; set; }
        public string VnPassword { get; set; }
        public string IDNP { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
