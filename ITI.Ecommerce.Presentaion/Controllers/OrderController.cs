using DTOs;
using ITI.Ecommerce.Models;
using ITI.Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("GetByCustomerId")]
        public async Task<IActionResult> GetOrderListByCustomerId(string CustomerId)
        {
            var Orders  = await _orderService.GetByCustomerId(CustomerId);
            if(Orders == null)
            {
                return NotFound($"we not found your Id : {CustomerId}");
            }
            return Ok(Orders);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetOrderByID(int id)
        {
            var Order = await _orderService.GetById(id);
            if (Order == null)
            {
                return NotFound($"we not found your Id : {id}");
            }
            return Ok(Order);
        }

        [HttpPost("Add")]
        public async Task<int> Add(OrderDto dto)
        {
           var OrderId= await _orderService.add(dto);
            return OrderId;
        }

        [HttpGet("Delete")]

        public void  Delete(int id)
        {
             _orderService.Delete(id);

        }
        [HttpPost("Update")]

        public void Update(OrderDto dto)
        {
            _orderService.Update(dto);

        }

        [HttpGet("GetRate")]
        public async Task<int> GetRate(int orderId, int productId)
        {
            var rate = await _orderService.GetProductRate(orderId, productId);
            return rate;
        }
        [HttpGet("SetRate")]
        public async Task SetRate(int orderId, int productId, int rate)
        {
            await _orderService.SetProductRate(orderId, productId, rate);
            
        }
    }
}
