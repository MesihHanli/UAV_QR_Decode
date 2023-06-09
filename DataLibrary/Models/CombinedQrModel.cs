using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CombinedQrModel
    {
        public string PName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string SourceCity { get; set; }
        public string DestinitionCity { get; set; }
        public DateTime Date { get; set; }
    }
}
