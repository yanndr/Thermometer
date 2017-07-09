using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Converter_api;
using TemperatureLibrary;

namespace Converter_api.Controllers
{
    [Route("api/[controller]")]
    public class FahrenheitToCelsiusController : Controller
    {
        
        [HttpGet("{value}")]
        public decimal Get(decimal value)
        {
            var temp = new Temperature(value,Unit.Fahrenheit);
            return Math.Round(Converter.Instance.Convert(temp,Unit.Celsius).Value,2);
        }
    }
}
