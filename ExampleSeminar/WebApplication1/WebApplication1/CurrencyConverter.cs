using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class CurrencyConverter
    {
        public decimal ConvertToGbp(decimal value, decimal exchangeRate, int decimalPlaces)
        {
            if (exchangeRate <= 0)
            {
                throw new ArgumentException("Exchange...", nameof(exchangeRate));
            }
            var valueInGbp = value / exchangeRate;
            return decimal.Round(valueInGbp, decimalPlaces);
        }
    }
}