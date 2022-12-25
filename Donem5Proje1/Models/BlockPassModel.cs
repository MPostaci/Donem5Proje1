using System.Text.Json.Nodes;

namespace Donem5Proje1.Models
{
    public class BlockPassModel
    {
        public List<DateTime> time { get; set; }

        public List<string> hash { get; set; }

        public List<string> data { get; set; }
    }
}
