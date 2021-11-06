using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterAPI.Models
{
    public class Converter
    {
        public float amount;
        public float exchangeRate;
        public float result;

        public Converter(float amount, float exchangeRate)
        {
            this.amount = amount;
            this.exchangeRate = exchangeRate;
        }

        public void convert()
        {
            result = amount * exchangeRate;
        }
    }
}
