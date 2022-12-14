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
        [HttpGet]
        public async Task<IActionResult> GetOrderListByCustomerId(string CustomerId)
        {
            var Orders  = await _orderService.GetByCustomerId(CustomerId);
            if(Orders == null)
            {
                return NotFound($"we not found your Id : {CustomerId}");
            }
            return Ok(Orders);
        }

        [HttpPost]
        public async Task Add(OrderDto dto)
        {
            await _orderService.add(dto);
           
        }

        [HttpPost("Delete")]

        public void  Delete(int id)
        {
             _orderService.Delete(id);

        }
        [HttpPost("Update")]

        public  void Update(OrderDto dto)
        {
             _orderService.Update(dto);

        }
    }
}
