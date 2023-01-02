using DTOs;
using ITI.Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryServie _categoryService;
        private readonly IProductService _productService;
        public CategoriesController(ICategoryServie categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpGet("GetAll")]
       public  async Task<IActionResult> GetAll()
       {
            var Categories=await _categoryService.GetAll();

        


            return Ok(Categories);
       }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GatByID(int id)
        {

          var Category = await _categoryService.GetById(id);
       

            if (Category != null)
            {
               
                return Ok(Category);
            }
            else
            return Ok("not found category");
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GatByName(string name)
        {
            var Categories = await _categoryService.GetByName(name);

            List<CategoryDto> li = new List<CategoryDto>();

            foreach (var Cat in Categories)
            {
                var Product = await _productService.GetByCategoryId(Cat.ID);
                List<ProductDto> ListPro = new List<ProductDto>();
                foreach (var Prod in Product)
                {
                    ProductDto pro = new ProductDto()
                    {
                        ID = Prod.ID,
                        NameAR = Prod.NameAR,
                        NameEN = Prod.NameEN,
                        TotalPrice = Prod.TotalPrice,
                        Quantity = Prod.Quantity,
                        Brand = Prod.Brand,
                        CategoryID = Prod.CategoryID,
                        Description = Prod.Description,
                        UnitPrice = Prod.UnitPrice,
                        Discount = Prod.Discount,
                      

                    };

                    ListPro.Add(pro);
                }

                CategoryDto Cate = new CategoryDto()
                {
                    ID = Cat.ID,
                    NameAR = Cat.NameAR,
                    NameEN = Cat.NameEN,
                
                };

                li.Add(Cate);

            }
            return Ok(li);
        }
    }
}
