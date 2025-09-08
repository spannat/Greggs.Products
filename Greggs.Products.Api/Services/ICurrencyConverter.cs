namespace Greggs.Products.Api.Services
{
    public interface ICurrencyConverter
    {
        decimal ConvertFromGbp(decimal amountInGbp, string targetCurrency);
    }
}
