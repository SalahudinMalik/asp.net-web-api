using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Qdata
    {
        //pqCode , fromUnit , fromVal , toUnit
        public int pqCode { get; set; }
        public string fromUnit { get; set; }
        public double fromVal { get; set; }
        public string toUnit { get; set; }
    }
}