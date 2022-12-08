using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;
using ITI.Ecommerce.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.Ecommerce.Presentaion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public IProductService _pro;
        public IProductImageService _img;
        public IConfiguration con;



        public ProductController(IProductService pro, IProductImageService img, IConfiguration _con)
        {

            _pro = pro;
            _img = img;
            con = _con;

        }
        [HttpGet("GetAll")]
        public async Task<List<ProductDto>> GetAll()
        {

            var Proudicts = await _pro.GetAll();


            List<ProductDto> li = new List<ProductDto>();

            foreach (var Prod in Proudicts)
            {
                var ProductImages = await _img.GetByProductId(Prod.ID);
                List<ProductImageDto> ListImage = new List<ProductImageDto>();
                foreach (var im in ProductImages)
                {
                    ProductImageDto pro = new ProductImageDto()
                    {
                        ID = im.ID,
                        Path = im.Path,
                        ProductID = im.ProductID,
                    };

                    ListImage.Add(pro);
                }

                ProductDto pr = new ProductDto()
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
                    productImageList = ListImage

                };

                li.Add(pr);
            }
            return li;
        }

        [HttpGet("GetProductByID")]
        public async Task<ProductDto> GetProductByID(int id)
        {

            var Prod = await _pro.GetById(id);
            List<ProductImageDto> ListImage = new List<ProductImageDto>();

            var ProductImages = await _img.GetByProductId(Prod.ID);

            foreach (var img in ProductImages)
            {

                ProductImageDto pro = new ProductImageDto()
                {
                    ID = img.ID,
                    Path = img.Path,
                    ProductID = img.ProductID,
                };

                ListImage.Add(pro);
            }

            ProductDto pr = new ProductDto()
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
                productImageList = ListImage

            };
            if (Prod != null)
            {
                return pr;
            }
            else
            {
                return null;
            }


        }
        [HttpGet("GetProductByCats")]
        public async Task<List<ProductDto>> GetProductByCats(int id)
        {
            var Proudicts = await _pro.GetByCategoryId(id);
            List<ProductDto> li = new List<ProductDto>();

            foreach (var Prod in Proudicts)
            {
                var ProductImages = await _img.GetByProductId(Prod.ID);
                List<ProductImageDto> ListImage = new List<ProductImageDto>();
                foreach (var im in ProductImages)
                {
                    ProductImageDto pro = new ProductImageDto()
                    {
                        ID = im.ID,
                        Path = im.Path,
                        ProductID = im.ProductID,
                    };

                    ListImage.Add(pro);
                }

                ProductDto pr = new ProductDto()
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
                    productImageList = ListImage

                };

                li.Add(pr);
            }
            return li;
        }

        [HttpGet("GetProductImages")]
        public async Task<List<ProductImageDto>> GetProductImages(int id)
        {
            var ProImage = await _img.GetByProductId(id);
            List<ProductImageDto> li = new List<ProductImageDto>();
            foreach (var it in ProImage)
            {
                li.Add(it);
            }
            return li;
        }
        [HttpGet("FilterPrice")]
        public async Task<List<ProductDto>> FilterPrice(float Price)
        {
            var product = await _pro.GetByPrice(Price);
            List<ProductDto> li = new List<ProductDto>();

            foreach (var Prod in product)
            {
                var ProductImages = await _img.GetByProductId(Prod.ID);
                List<ProductImageDto> ListImage = new List<ProductImageDto>();
                foreach (var im in ProductImages)
                {
                    ProductImageDto pro = new ProductImageDto()
                    {
                        ID = im.ID,
                        Path = im.Path,
                        ProductID = im.ProductID,
                    };

                    ListImage.Add(pro);
                }

                ProductDto pr = new ProductDto()
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
                    productImageList = ListImage

                };

                li.Add(pr);
            }
            return li;
        }
        [HttpGet("FilterByName")]
        public async Task<List<ProductDto>> FilterByName(string name)
        {
            var product = await _pro.FiletrProductBYname(name);
            List<ProductDto> li = new List<ProductDto>();

            foreach (var Prod in product)
            {
                var ProductImages = await _img.GetByProductId(Prod.ID);
                List<ProductImageDto> ListImage = new List<ProductImageDto>();
                foreach (var im in ProductImages)
                {
                    ProductImageDto pro = new ProductImageDto()
                    {
                        ID = im.ID,
                        Path = im.Path,
                        ProductID = im.ProductID,
                    };

                    ListImage.Add(pro);
                }

                ProductDto pr = new ProductDto()
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
                    productImageList = ListImage

                };

                li.Add(pr);
            }
            return li;
        }


    }

}
