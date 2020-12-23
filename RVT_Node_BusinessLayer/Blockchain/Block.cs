using RVT_Node_BusinessLayer.NodeMessages;
using RVTLibrary.Algoritms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.Blockchain
{
    public class Block
    {
        public int BlockId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public int? PartyChoosed { get; set; }
        public int? RegionChoosed { get; set; }
        public string Gender { get; set; }
        public int? YearToBirth { get; set; }
        public string Idbd { get; set; }

        public Block()
        {
            BlockId = 1;
            CreatedOn = DateTime.Now;
            Hash = "blablabla";
            PreviousHash = "blablabla";
            Idbd = "Admin";
            PartyChoosed = 352;
            RegionChoosed = 1;
            Gender = "male";
            YearToBirth = 1990;
        }

        public Block GetGenesisBlock()
        {
            return new Block();
        }

        public string GetStringForHash()
        {
            var data = "";
            data += BlockId;
            data += Idbd;
            data += PartyChoosed;
            data += RegionChoosed;
            data += PreviousHash;
            data += Hash;
            data += Gender;
            data += YearToBirth;
            return data;
        }

        public Block(ChooserLbMessage chooser, Block block, string IDBD)
        {
            BlockId = block.BlockId + 1;
            CreatedOn = DateTime.Now;
            PreviousHash = block.Hash;
            Idbd = IDBD;
            RegionChoosed = chooser.Region;
            PartyChoosed = chooser.PartyChoosed;
            YearToBirth = Convert.ToInt32(chooser.Birth_date.Year);
            Gender = chooser.Gender;

            Hash = new SHA_Encryption().GetHash(GetStringForHash());
        }

    }
}
