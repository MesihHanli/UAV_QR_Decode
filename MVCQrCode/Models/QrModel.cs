using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQrCode.Models
{
    public class QrModel
    {
        public string GUID { get; set; }
        public int PID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Source { get; set; }
        public int Destinition { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}