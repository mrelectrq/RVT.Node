using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RVT_Node_BusinessLayer.BusinessModels
{
    public class NodeConfig 
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string SoftwareVersion { get; set; }
        public string NodeId { get; set; }
        public X509Certificate2 certificate { get; set; }

        private static readonly Lazy<NodeConfig> nodeConfig =
            new Lazy<NodeConfig>(() => new NodeConfig());

        public static NodeConfig GetInstance()
        {
            
            return nodeConfig.Value;
        }

      //  public string 
    }
}
