using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCQrCode.Models
{
    public class CombinedQrModel
    {
        public string PName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string SourceCity { get; set; }
        public string DestinitionCity { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
    }
}