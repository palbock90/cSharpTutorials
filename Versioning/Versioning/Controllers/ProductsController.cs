using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Versioning.Contracts;

namespace Versioning.Controllers
{
    [ApiController]
    [Route("api/products")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        // Default version
        [HttpGet("{productId}")]
        public IActionResult GetProductV1([FromRoute] Guid productId)
        {
            var product = new ProductResponseV1
            {
                Id = productId,
                Name = "Visual Studio"
            };

            return Ok(product);
        }

        // Version 2.0 - Need to specify in GET URL or header
        [HttpGet("{productId}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetProductV2([FromRoute] Guid productId)
        {
            var product = new ProductResponseV2
            {
                Id = productId,
                ProductName = "Visual Studio"
            };

            return Ok(product);
        }
    }
}
