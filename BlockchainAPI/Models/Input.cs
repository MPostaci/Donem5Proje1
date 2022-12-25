using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAPI.Models
{
    public class Input
    {
        public long? Timestamp { get; set; }

        public int? Amount { get; set; }

        public string? Address { get; set; }

        public Signature? Signature { get; set; }
    }
}
