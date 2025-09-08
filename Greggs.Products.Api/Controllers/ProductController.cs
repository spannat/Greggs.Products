using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    /// <summary>
    /// Default currency is "GDP". Pass in "EUR" to get the prices of the products converted using the converter service.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> Get(string currency = "GBP", int? pageStart = 0, int? pageSize = 5)
    {
        try
        {
            var products = _productService.GetProducts(currency, pageStart, pageSize);
            return Ok(products);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid request.");
            return BadRequest(ex.Message);
        }
    }
}