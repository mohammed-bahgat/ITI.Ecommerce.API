using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Models;
using ITI.Ecommerce.Services;
using ITI.Ecommerce.Presentaion.Models;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        IShoppingCartService _cart;
        IProductService _productService;
       public ShoppingCartController(IShoppingCartService cart,IProductService productService)
        {

            _cart=cart;
            _productService = productService;

        }
        [HttpPost("Add")]
        public async void Add(ShoppingCartModel shoppingCart)
        {
            ShoppingCartDto shoppingCartDto = new ShoppingCartDto()
            {
                ID = shoppingCart.ID,
                IsDeleted = false,
            };
            foreach (var prodId in shoppingCart.productListIds)
            {
                var product = await _productService.GetById(prodId);
                shoppingCartDto.productList.Add(product);
            }
            await _cart.add(shoppingCartDto);
        }

    }
}
