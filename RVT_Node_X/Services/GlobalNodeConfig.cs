using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RVT_Node_BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RVT_Node_X.Services
{
    public class GlobalNodeConfig : IHelloMessage
    {
        private readonly string _balancerURL;
        private readonly string _requestUri;
        private readonly NodeConfig _node;
        private readonly ILogger<GlobalNodeConfig> _logger;
        public GlobalNodeConfig(ILogger<GlobalNodeConfig> factory, IConfiguration root)
        {
            _node = NodeConfig.GetInstance();
             _node.Url = root["NodeConfig:URL"];
            _node.NodeId = root["NodeConfig:NodeID"];
            _node.SoftwareVersion = root["NodeConfig:SoftwareVersion"];
            _node.Name = root["NodeConfig:Name"];
            _balancerURL = root["LoadBalancerInfo:URL"];
            _requestUri = root["LoadBalancerInfo:RequestUri"];
            _node.certificate = new X509Certificate2(Path.Combine(root["NodeConfig:Cert_Root"], root["NodeConfig:Cert_file"]), "ar4iar4i"
                , X509KeyStorageFlags.Exportable);
            _logger = factory;
        }

        public async Task HelloMessage()
        {
            try
            {

                var message = new Node();
                message.Name = _node.Name;
                message.NodeId = _node.NodeId;
                message.SoftwareVersion = _node.SoftwareVersion;
                message.IpAddress = _node.Url;
                //message.Thumbprint = _node.certificate.Thumbprint;
                message.PublicKey = _node.certificate.GetPublicKey();

                var handler = new HttpClientHandler();
                handler.ClientCertificates.Add(_node.certificate);
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var client = new HttpClient(handler);
                
                client.BaseAddress = new Uri(_balancerURL);

                var data_req = JsonConvert.SerializeObject(message);
                var content = new StringContent(data_req, Encoding.UTF8, "application/json");
                var response = await  client.PostAsync(_requestUri, content);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Succesefull registered Node on LoadBalancer"+
                        _node.Name+"\r\n"
                        +_node.NodeId+"\r\n"
                        +_node.Url);
                }
            }
            catch(AggregateException e)
            {
                _logger.LogError(e.Message);
            }

           
        }
    }
}
