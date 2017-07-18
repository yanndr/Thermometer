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
    public class CelsiusToFahrenheitController : Controller
    {
        
        [HttpGet("{value}")]
        public IActionResult Get(decimal value)
        {
            var temp = new Temperature(value,Unit.Celsius);
            
            ITemperature convertedTemp;
            try{
                convertedTemp = Converter.Instance.Convert(temp,Unit.Fahrenheit); 
            }
            catch(Exception e){
                return StatusCode(500,e.Message);
            }
            return new ObjectResult(Math.Round(convertedTemp.Value,2));
        }
    }
}
