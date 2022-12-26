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

        //[HttpGet("GetProductImages")]
        //public async Task<List<ProductImageDto>> GetProductImages(int id)
        //{
        //    var ProImage = await _img.GetByProductId(id);
        //    List<ProductImageDto> li = new List<ProductImageDto>();
        //    foreach (var it in ProImage)
        //    {
        //        li.Add(it);
        //    }
        //    return li;
        //}
        //[HttpGet("FilterPrice")]
        //public async Task<List<ProductDto>> FilterPrice(float Price)
        //{
        //    var product = await _pro.GetByPrice(Price);
        //    List<ProductDto> li = new List<ProductDto>();

        //    foreach (var Prod in product)
        //    {
        //        var ProductImages = await _img.GetByProductId(Prod.ID);
        //        List<ProductImageDto> ListImage = new List<ProductImageDto>();
        //        foreach (var im in ProductImages)
        //        {
        //            ProductImageDto pro = new ProductImageDto()
        //            {
        //                ID = im.ID,
        //                Path = im.Path,
        //                ProductID = im.ProductID,
        //            };

        //            ListImage.Add(pro);
        //        }

        //        ProductDto pr = new ProductDto()
        //        {
        //            ID = Prod.ID,
        //            NameAR = Prod.NameAR,
        //            NameEN = Prod.NameEN,
        //            TotalPrice = Prod.TotalPrice,
        //            Quantity = Prod.Quantity,
        //            Brand = Prod.Brand,
        //            CategoryID = Prod.CategoryID,
        //            Description = Prod.Description,
        //            UnitPrice = Prod.UnitPrice,
        //            Discount = Prod.Discount,
        //            productImageList = ListImage

        //        };

        //        li.Add(pr);
        //    }
        //    return li;
        //}
        //[HttpGet("FilterByName")]
        //public async Task<List<ProductDto>> FilterByName(string name)
        //{
        //    var product = await _pro.FiletrProductBYname(name);
        //    List<ProductDto> li = new List<ProductDto>();

        //    foreach (var Prod in product)
        //    {
        //        var ProductImages = await _img.GetByProductId(Prod.ID);
        //        List<ProductImageDto> ListImage = new List<ProductImageDto>();
        //        foreach (var im in ProductImages)
        //        {
        //            ProductImageDto pro = new ProductImageDto()
        //            {
        //                ID = im.ID,
        //                Path = im.Path,
        //                ProductID = im.ProductID,
        //            };

        //            ListImage.Add(pro);
        //        }

        //        ProductDto pr = new ProductDto()
        //        {
        //            ID = Prod.ID,
        //            NameAR = Prod.NameAR,
        //            NameEN = Prod.NameEN,
        //            TotalPrice = Prod.TotalPrice,
        //            Quantity = Prod.Quantity,
        //            Brand = Prod.Brand,
        //            CategoryID = Prod.CategoryID,
        //            Description = Prod.Description,
        //            UnitPrice = Prod.UnitPrice,
        //            Discount = Prod.Discount,
        //            productImageList = ListImage

        //        };

        //        li.Add(pr);
        //    }
        //    return li;
        //}


        //[HttpGet("GetCategoryBrand")]
        //public async Task<List<string>> GetCategoryBrand(int Cat)
        //{
        //    var product = await _pro.GetCategoryBrand(Cat);
        //    List<string> li = new List<string>();

        //    foreach(var it in product)
        //    {
        //        li.Add(it);
        //    }
        //    return li;
        //}

        //[HttpGet("GetProductByCatAndBrand")]
        //public async Task<List<ProductDto>> GetProductByCatAndBrand( int Category,string Brand)
        //{

        //    var Proudicts = await _pro.GetProductByCategoryAndPranch(Category, Brand);


        //    List<ProductDto> li = new List<ProductDto>();

        //    foreach (var Prod in Proudicts)
        //    {
        //        var ProductImages = await _img.GetByProductId(Prod.ID);
        //        List<ProductImageDto> ListImage = new List<ProductImageDto>();
        //        foreach (var im in ProductImages)
        //        {
        //            ProductImageDto pro = new ProductImageDto()
        //            {
        //                ID = im.ID,
        //                Path = im.Path,
        //                ProductID = im.ProductID,
        //            };

        //            ListImage.Add(pro);
        //        }

        //        ProductDto pr = new ProductDto()
        //        {
        //            ID = Prod.ID,
        //            NameAR = Prod.NameAR,
        //            NameEN = Prod.NameEN,
        //            TotalPrice = Prod.TotalPrice,
        //            Quantity = Prod.Quantity,
        //            Brand = Prod.Brand,
        //            CategoryID = Prod.CategoryID,
        //            Description = Prod.Description,
        //            UnitPrice = Prod.UnitPrice,
        //            Discount = Prod.Discount,
        //            productImageList = ListImage

        //        };

        //        li.Add(pr);
        //    }
        //    return li;
        //}

    }

}
