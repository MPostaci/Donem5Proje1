using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAPI.Models
{
    public class Signature
    {
        public string? r { get; set; }

        public string? s { get; set; }

        public int? recoveryParam { get; set; }
    }
}
