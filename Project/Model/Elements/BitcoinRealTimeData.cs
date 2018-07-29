using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Elements
{
    /// <summary>
    /// Model of data recieved from public API with information about bitcoin
    /// transactions
    /// </summary>
    public class BitcoinRealTimeData
    {
        public double High { get; set; }
        public double Last { get; set; }
        public double Timestamp { get; set; }
        public double Bid { get; set; }
        public double Vwap { get; set; }
        public double Volume { get; set; }
        public double Low { get; set; }
        public double Ask { get; set; }
        public double Open { get; set; }
    }
}