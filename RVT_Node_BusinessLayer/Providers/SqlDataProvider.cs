using DataLayer.Models;
using RVT_Node_BusinessLayer.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class SqlDataProvider : IDataProvider
    {
        public void AddBlock(object block)
        {
            using (var context = new Themis_SystemContext())
            {

                var sqlBlock = new BlockChain();
                Block inputBlock =(Block)block;
                sqlBlock.Hash = inputBlock.Hash;
                sqlBlock.Idbd = inputBlock.Idbd;
                sqlBlock.PartyChoosed = inputBlock.PartyChoosed;
                sqlBlock.RegionChoosed = inputBlock.RegionChoosed;
                sqlBlock.PreviouseHash = inputBlock.PreviousHash;
                sqlBlock.YearToBirth = inputBlock.YearToBirth;
                sqlBlock.Gender = inputBlock.Gender;
                sqlBlock.BlockId = inputBlock.BlockId;
                sqlBlock.CreatedOn = inputBlock.CreatedOn;
                context.BlockChain.Add(sqlBlock);
                context.SaveChanges();
            }
        }

        public object GetChain()
        {
            using (var context = new Themis_SystemContext())
            {
                var chain = context.BlockChain.Take(10).OrderByDescending(m => m.CreatedOn).ToList();
                List<Block> blocks = new List<Block>();
                foreach(var i in chain)
                {
                    var block = new Block();
                    block.BlockId = i.BlockId;
                    block.CreatedOn = i.CreatedOn;
                    block.Gender = i.Gender;
                    block.Hash = i.Hash;
                    block.PartyChoosed = i.PartyChoosed;
                    block.RegionChoosed = i.RegionChoosed;
                    block.Idbd = i.Idbd;
                    block.PreviousHash = i.PreviouseHash;
                    block.YearToBirth = i.YearToBirth;
                    blocks.Add(block);
                }

                return blocks;
            }

            
        }

    }
}
