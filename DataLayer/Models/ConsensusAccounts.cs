using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class ConsensusAccounts
    {
        public string Idbd { get; set; }
        public DateTime? RepDateTime { get; set; }
        public string RepByNodeR { get; set; }
        public string Software { get; set; }
    }
}
