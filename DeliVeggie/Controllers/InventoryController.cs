using DeliVeggieGateway.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DeliVeggieGateway.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _inventoryService.Products());
        }

        [HttpGet]
        [Route("products/{productId}")]
        public async Task<IActionResult> GetProduct(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest($"Product Id:{productId} is invalid");
            }

            var discoveredProduct = await _inventoryService.Product(productId);

            if (discoveredProduct == null)
            {
                return NotFound($"Product with Id:{productId} not found");
            }

            return Ok(await _inventoryService.Products());
        }
    }
}
