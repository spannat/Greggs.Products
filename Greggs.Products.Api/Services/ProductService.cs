using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataAccess<Product> _dataAccess;
        private readonly ICurrencyConverter _currencyConverter;
        public ProductService(IDataAccess<Product> dataAccess, ICurrencyConverter currencyConverter)
        {
            _dataAccess = dataAccess;
            _currencyConverter = currencyConverter;
        }
        public IEnumerable<ProductDto> GetProducts(string currency, int? pageStart, int? pageSize)
        {
            var products = _dataAccess.List(pageStart, pageSize);
            //map to the dto
            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                PriceInPounds = _currencyConverter.ConvertFromGbp(p.PriceInPounds, currency),
                Currency = currency
            }).ToList();
        }
    }
}
