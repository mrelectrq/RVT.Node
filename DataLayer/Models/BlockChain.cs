using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class BlockChain
    {
        public int BlockId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Hash { get; set; }
        public string PreviouseHash { get; set; }
        public int? PartyChoosed { get; set; }
        public int? RegionChoosed { get; set; }
        public string Gender { get; set; }
        public int? YearToBirth { get; set; }
        public string Idbd { get; set; }
    }
}
