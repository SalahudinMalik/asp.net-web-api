using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using WebApplication1.classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UnitRController : ApiController
    {
        clsDLLBasedConv obj = new clsDLLBasedConv();
        [HttpPost]
        public string getData(Qdata id)
        {
            //dynamic json = JValue.Parse(data.ToString());
            int pqNo = int.Parse(id.pqCode.ToString());
            string fromUnit = id.fromUnit;
            double fromVal = double.Parse(id.fromVal.ToString());
            string toUnit = id.toUnit;
            return obj.CalConversion(pqNo, fromUnit, ref fromVal, toUnit);
        }
    }
}
