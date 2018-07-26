using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class BitcoinRealTimeData
    {
        private double High { get; set; }
        private double Last { get; set; }
        private double Timestamp { get; set; }
        private double Bid { get; set; }
        private double Vwap { get; set; }
        private double Volume { get; set; }
        private double Low { get; set; }
        private double Ask { get; set; }
        private double Open { get; set; }
    }
}