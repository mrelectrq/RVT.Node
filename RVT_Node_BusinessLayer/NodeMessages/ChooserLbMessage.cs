using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.NodeMessages
{
    public class ChooserLbMessage
    {     
        public string Gender { get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime Vote_date { get; set; }
        public int Region { get; set; }
        public string IDVN  { get; set; }
        public int PartyChoosed { get; set; }
    }
}
