using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAPI.Models
{
    public class TransactPostModel
    {
        public string? recipient { get; set; }

        public int amount { get; set; }
    }
}
