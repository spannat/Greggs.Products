using Greggs.Products.Api.Models;
using System.Collections.Generic;

namespace Greggs.Products.Api.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts(string currency, int? pageStart, int? pageSize);
    }
}
