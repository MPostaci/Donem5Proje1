using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAPI.Models
{
    public class DataModel
    {
        
        public string? id { get; set; }
        public Dictionary<string, int>? OutputMap { get; set; }

        public Input? Input { get; set; }
    
    }
}
