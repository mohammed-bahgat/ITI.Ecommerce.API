using DTOs;
using ITI.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext cont)
        {
            _context = cont;
        }

       

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false).Distinct().ToListAsync();

            foreach (var product in products)
            {
                ProductDto productDto = new ProductDto()
                {
                    ID = product.ID,
                    NameAR = product.NameAR,
                    NameEN = product.NameEN,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    TotalPrice = product.TotalPrice,
                    Brand = product.Brand,




                };
                var productImgList = await _context.ProductImages.Where(i => i.ProductID == product.ID).ToListAsync();
                var ProductImgDtoList = new List<ProductImageDto>();
                foreach (var img in productImgList)
                {
                    var imgDto = new ProductImageDto()
                    {
                        ID = img.ID,
                        Path = img.Path,
                        ProductID = img.ProductID,
                    };
                    ProductImgDtoList.Add(imgDto);
                }
                productDto.ProductImageList = ProductImgDtoList;
                productDtoList.Add(productDto);


            }

            return productDtoList;
        }


        public async Task<IEnumerable<ProductDto>> GetByCategoryId(int id)
        {
            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false && p.CategoryID == id).Distinct().ToListAsync();

            foreach (var product in products)
            {
                ProductDto productDto = new ProductDto()
                {
                    ID = product.ID,
                    NameAR = product.NameAR,
                    NameEN = product.NameEN,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    TotalPrice = product.TotalPrice,
                    Brand = product.Brand,
                   



                };
                var productImgList = await _context.ProductImages.Where(i => i.ProductID == product.ID).ToListAsync();
                var ProductImgDtoList = new List<ProductImageDto>();
                foreach (var img in productImgList)
                {
                    var imgDto = new ProductImageDto()
                    {
                        ID = img.ID,
                        Path = img.Path,
                        ProductID = img.ProductID,
                    };
                    ProductImgDtoList.Add(imgDto);
                }
                productDto.ProductImageList = ProductImgDtoList;
                productDtoList.Add(productDto);

            }

            return productDtoList;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id && p.IsDeleted == false);
            if (product == null)
            {
                return null;
            }
            else
            {

                ProductDto productDto = new ProductDto()
                {
                    ID = product.ID,
                    NameAR = product.NameAR,
                    NameEN = product.NameEN,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    TotalPrice = product.TotalPrice,
                
                    Brand = product.Brand,

                };

                var productImgList = await _context.ProductImages.Where(i => i.ProductID == product.ID).ToListAsync();
                var ProductImgDtoList = new List<ProductImageDto>();
                foreach (var img in productImgList)
                {
                    var imgDto = new ProductImageDto()
                    {
                        ID = img.ID,
                        Path = img.Path,
                        ProductID = img.ProductID,
                    };
                    ProductImgDtoList.Add(imgDto);
                }
                productDto.ProductImageList = ProductImgDtoList;


                return productDto;
            }
        }

       
    }
}
