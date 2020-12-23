using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public interface IDataProvider
    {
        public void AddBlock(object block);
        public object GetChain();
    }
}
