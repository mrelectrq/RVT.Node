using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeMessages
{
    public class NodeRegVerification
    {
        [DataMember]
        public string IDVN { get; set; }
        [DataMember]
        public string IDBD { get; set; }

        public string Serialize()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegVerification));
            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, this);
                var result = Encoding.UTF8.GetString(ms.ToArray());
                return result;
            }
        }

        public static NodeRegVerification Deserialize(string json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(NodeRegVerification));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                var result = (NodeRegVerification)jsonSerializer.ReadObject(ms);
                return result;

            }
        }
    }
}
