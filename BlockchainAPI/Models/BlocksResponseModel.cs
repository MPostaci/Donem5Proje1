using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAPI.Models
{
    public class BlocksResponseModel
    {
        public long? timestamp { get; set; }
        public string? lastHash { get; set; }
        public string? hash { get; set; }
        public List<DataModel>? data { get; set; }
        public int? nonce { get; set; }
        public int? difficulty { get; set; }
    }
}
