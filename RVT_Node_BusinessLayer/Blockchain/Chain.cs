using DataLayer.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using RVT_Node_BusinessLayer.NodeMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RVT_Node_BusinessLayer.Blockchain
{
    public class Chain
    {
        private List<Block> chain;
        private readonly IDataProvider _provider;
        private bool Status = true;

        public Chain(IDataProvider provider)
        {
            _provider = provider;
            chain = (List<Block>)_provider.GetChain();
            if (chain.Count==0)
            {
                CreateNewBlockChain();
            }
            else Status = CheckBlock();
        }

        private bool CheckBlock()
        {
            var prevHash = chain.Last().Hash;
            foreach (var i in Enumerable.Reverse(chain).Skip(1))
            {
                var hash = i.PreviousHash;
                if (prevHash != hash)
                {
                    return false;
                }
                prevHash = i.Hash;
            }


            return true;
        }

        //private Chain()
        //{
        //    CreateNewBlockChain();
        //}

        private void CreateNewBlockChain()
        {
            chain = new List<Block>();
            var genesisBlock = new Block();
            chain.Add(genesisBlock);
            Status = CheckBlock();
        }

        public Block GenBlock(ChooserLbMessage chooser, string IDBD)
        {
            try
            {
                var block = new Block(chooser, chain.First(), IDBD);
                return block;
            }
            catch(AggregateException e)
            {
                return new Block { Hash = e.Message };
            }
            
        }
        
        public void Add(Block block)
        {
                _provider.AddBlock(block);
        }
    }
}