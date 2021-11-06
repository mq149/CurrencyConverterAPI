using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConverterController : Controller
    {
        // GET: api/Converter
        [HttpGet("convert/{amount}/{exchangeRate}")]
        public float convert(float amount, float exchangeRate)
        {
            CurrencyConverterAPI.Models.Converter converter = new Models.Converter(amount, exchangeRate);
            converter.convert();
            return converter.result;
        }
    }
}