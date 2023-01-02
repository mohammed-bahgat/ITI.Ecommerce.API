using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;
using ITI.Ecommerce.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.Ecommerce.Presentaion.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public IProductService _productService;
      



        public ProductController(IProductService productService)
        {

            _productService = productService;
            
           

        }
        [HttpGet("GetAll")]
        public async Task<List<ProductDto>> GetAll()
        {

            var ProductList = await _productService.GetAll();


        
            return (List<ProductDto>)ProductList;
        }

        [HttpGet("GetProductByID")]
        public async Task<ProductDto> GetProductByID(int id)
        {

            var productDto = await _productService.GetById(id);

            return productDto;

        }
        [HttpGet("GetProductByCats")]
        public async Task<List<ProductDto>> GetProductByCats(int id)
        {
            var ProductDtoList = await _productService.GetByCategoryId(id);
            
              var ProductList = new List<ProductDto>();

            foreach (var prd in ProductDtoList)
            {
                ProductList.Add(prd);
            }

            return ProductList;
        }

       

    }

}
