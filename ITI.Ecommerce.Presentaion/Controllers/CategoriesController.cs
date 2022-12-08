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

        private readonly ICategoryServie _Cat;
        private readonly IProductService _Pro;
        public CategoriesController(ICategoryServie Cat,IProductService Pro)
        {
            _Cat=Cat;
            _Pro=Pro;
        }
        [HttpGet("GetAll")]
       public  async Task<IActionResult> GetAll()
       {
            var Categories=await _Cat.GetAll();

            List<CategoryDto> li = new List<CategoryDto>();

            foreach (var Cat in Categories)
            {
                var Product = await _Pro.GetByCategoryId(Cat.ID);
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
                       // productImageList = ListImage

                    };

                    ListPro.Add(pro);
                }

                CategoryDto Cate = new CategoryDto()
                {
                    ID = Cat.ID,
                    NameAR = Cat.NameAR,
                    NameEN = Cat.NameEN,
                    ProductList = ListPro,
                };

                li.Add(Cate);
            }



            return Ok(li);
       }
        [HttpGet("GatByID")]
        public async Task<IActionResult> GatByID(int id)
        {

          var Category = await _Cat.GetById(id);
            var Product = await _Pro.GetByCategoryId(Category.ID);
            List<ProductDto> ListPro = new List<ProductDto>();

            if (Category != null)
            {
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
                        // productImageList = ListImage

                    };

                    ListPro.Add(pro);

                }
                CategoryDto Cate = new CategoryDto()
                {
                    ID = Category.ID,
                    NameAR = Category.NameAR,
                    NameEN = Category.NameEN,
                    ProductList = ListPro,
                };
                return Ok(Cate);
            }
            else
            return Ok(null);
        }
        [HttpGet("GatByName")]
        public async Task<IActionResult> GatByName(string name)
        {
            var Categories = await _Cat.GetByName(name);

            List<CategoryDto> li = new List<CategoryDto>();

            foreach (var Cat in Categories)
            {
                var Product = await _Pro.GetByCategoryId(Cat.ID);
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
                        // productImageList = ListImage

                    };

                    ListPro.Add(pro);
                }

                CategoryDto Cate = new CategoryDto()
                {
                    ID = Cat.ID,
                    NameAR = Cat.NameAR,
                    NameEN = Cat.NameEN,
                    ProductList = ListPro,
                };

                li.Add(Cate);

            }
            return Ok(li);
        }
    }
}
