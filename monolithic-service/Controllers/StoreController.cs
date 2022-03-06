using Microsoft.AspNetCore.Mvc;
using monolithic_service.Models;
using monolithic_service.Repositories.Interfaces;

namespace monolithic_service.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet("/v1/store/inventory")]
        public async Task<IActionResult> GetInventory()
        {
            var result = await _storeRepository.GetInventory();
            return Ok(result);
        }

        [HttpGet("/v1/store/order/{orderId}")]
        public async Task<IActionResult> GetOrders(int orderId)
        {
            var result = await _storeRepository.GetOrders(orderId);
            return Ok(result);
        }

        [HttpPost("/v1/store/order")]
        public async Task<ActionResult> Place([FromBody] Order order)
        {
            if (order != null)
            {
                var result = await _storeRepository.PostOrder(order);

                return Ok(result);
            }
            return StatusCode(400);
        }

        [HttpDelete("/v1/store/order/{orderId}")]
        public async Task<ActionResult> Delete(int orderId)
        {
            var result = await _storeRepository.DeleteOrder(orderId);
            return Ok(result);
        }
    }
}
