using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class NprData
    {
        public string Idvn { get; set; }
        public string HashAds { get; set; }
        public string IntroducedBy { get; set; }
        public DateTime? Repdate { get; set; }
    }
}
