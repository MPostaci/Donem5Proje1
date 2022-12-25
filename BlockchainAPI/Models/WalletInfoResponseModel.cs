using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAPI.Models
{
    public class WalletInfoResponseModel
    {
        public string? Address { get; set; }
        public int Balance { get; set; }
    }
}
