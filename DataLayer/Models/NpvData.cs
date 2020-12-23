using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class NpvData
    {
        public string Idbd { get; set; }
        public string HashAds { get; set; }
        public string IntroducedBy { get; set; }
        public DateTime? Repdate { get; set; }
    }
}
