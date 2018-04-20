using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UnitConvController : ApiController
    {
        clsDLLBasedConv obj = new clsDLLBasedConv();
        public List<PQModel> getPQData()
        {
            return obj.getAllPQ();
        }
        // [HttpGet]
        // [Route("api/UnitConv/Convert/{pqNo}/{fromUnit}/{fromVal}/")]
        public string Cal(int pqNo, string fromUnit, Double fromVal, string toUnit)
        {
            return obj.CalConversion(pqNo, fromUnit, ref fromVal, toUnit);
        }
        // UnitConvo/id
        public List<string> getAllUnits(int id)
        {
            return obj.getAllUnits(id);
        }
       

    }
}
