using DTOs;
using ITI.Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;
        public ShoppingCartsController(IShoppingCartService shoppingCartService, IProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(List<int> ProductIds)
        {
            var shoppingCartDto = new ShoppingCartDto()
            {
                IsDeleted = false
            };

            foreach (var id in ProductIds)
            {
             var prd= await _productService.GetById(id);
                shoppingCartDto.productList.Add(prd);

            }
          var cartId=  await _shoppingCartService.add(shoppingCartDto);
            return Ok(cartId);
        }
        //[HttpPost("Add")]
        //public async Task<IActionResult> Add(ShoppingCartDT shoppingCartDT)
        //{
        //    await _shoppingCartService.add(shoppingCartDT);
        //    return Ok();
        //}

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var ShoppingCart = await _shoppingCartService.GetAll();
            return Ok(ShoppingCart);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var ShoppingCart = await _shoppingCartService.GetById(id);
            return Ok(ShoppingCart);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            _shoppingCartService.DeleteCart(id);
            return Ok();
        }

        //[HttpPut("Update")]
        //public IActionResult Update(int id ,[FromForm]ShoppingCartDto shoppingCartDto)
        //{
        //    _shoppingCartService.UpdateCart(id, shoppingCartDto);
        //    return Ok();
        //}
    }
}
