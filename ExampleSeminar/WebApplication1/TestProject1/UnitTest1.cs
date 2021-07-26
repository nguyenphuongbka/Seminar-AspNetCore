using System;
using WebApplication1;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 3, 0)]
        [InlineData(0, 1.5, 2)]
        [InlineData(3.75, 2.5, 1.5)]
        public void TestConvertCurrency(decimal value, decimal rate, decimal expected)
        {
            var converter = new CurrencyConverter();
            int dps = 4;
            var actual = converter.ConvertToGbp(value, rate, dps);

            Assert.Equal(expected, actual);
        }
    }
}