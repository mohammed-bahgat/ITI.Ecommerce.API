using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Models;
using ITI.Ecommerce.Services;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        IShoppingCartService _cart;
       public ShoppingCartController(IShoppingCartService cart)
        {

            _cart=cart;

        }
        [HttpPost("Add")]
        public async void Add(ShoppingCartDto shop)
        {
            await _cart.add(shop);
        }

    }
}
