using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeResponses
{
    public class NodeRegVerifResp
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public DateTime ProcessedTime { get; set; }


        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegVerifResp));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }

        public static NodeRegVerifResp Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegVerifResp));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (NodeRegVerifResp)jsonSerializer.ReadObject(ms);
                return result;

            }
        }
    }
}
