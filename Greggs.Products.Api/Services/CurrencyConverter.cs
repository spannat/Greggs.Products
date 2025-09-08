using System;

namespace Greggs.Products.Api.Services
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private const decimal GbpToEurRate = 1.11m; // could use an external service here to get live rates

        public decimal ConvertFromGbp(decimal amountInGbp, string targetCurrency)
        {
            if (string.Equals(targetCurrency, "gbp", StringComparison.OrdinalIgnoreCase))
                return amountInGbp;

            if (string.Equals(targetCurrency, "eur", StringComparison.OrdinalIgnoreCase))
                return decimal.Round(amountInGbp * GbpToEurRate, 2); //rounds to 2 decimal places so safe for price

            throw new ArgumentException($"Unsupported currency: {targetCurrency}");
        }
    }
}
