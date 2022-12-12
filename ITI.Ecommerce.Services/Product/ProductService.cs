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

        public async Task<IEnumerable<ProductDto>> FiletrProductBYname(string name)
        {
            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false && p.NameEN.Contains(name)).ToListAsync();

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
                    IsDeleted = product.IsDeleted,



                };
                productDtoList.Add(productDto);

            }

            return productDtoList;
        }

        public async Task<IEnumerable<ProductDto>> FiletrProductBYnameDes(string name)
        {
            var products = await _context.Products.OrderByDescending(p => p.NameEN).Where(p=>p.IsDeleted==false).ToListAsync();
            List<ProductDto> productDtoList = new List<ProductDto>();
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
                    IsDeleted = product.IsDeleted,



                };
                productDtoList.Add(productDto);
            }
            return productDtoList;
        }

        public Task<IEnumerable<ProductDto>> FiletrProductBYnameDes()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
          List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false).ToListAsync();           
 
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
                    IsDeleted = product.IsDeleted,

                   
                };
                productDtoList.Add(productDto);
             

            }

            return productDtoList;
        }

        public  async Task<IEnumerable<CategoryDto>> GetAllCat()
        {
            List<CategoryDto> productDtoList = new List<CategoryDto>();

            var products = await _context.Categories.Where(p => p.IsDeleted == false).ToListAsync();

            foreach (var product in products)
            {
                CategoryDto productDto = new CategoryDto()
                {
                    ID= product.ID, 
                    NameAR=product.NameAR,
                    NameEN=product.NameEN,
                };
                productDtoList.Add(productDto);

            }

            return productDtoList;
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryId(int id)
        {
            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false && p.CategoryID==id).ToListAsync();

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
                    IsDeleted = product.IsDeleted,



                };
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
                    IsDeleted = product.IsDeleted,
                    Brand = product.Brand,

                };
                return productDto;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetByPrice(float price)
        {

            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false && p.TotalPrice<price).ToListAsync();

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
                    IsDeleted = product.IsDeleted,



                };
                productDtoList.Add(productDto);

            }

            return productDtoList;

        }

        public async Task<List<string>> GetCategoryBrand(int Cat)
        {
            List<string> li = new List<string>();


            var Products = await _context.Products.Where(p => p.CategoryID == Cat && p.IsDeleted == false).Distinct().ToListAsync();

            if (Products != null)
            {
                foreach (var item in Products)
                {
                    li.Add(item.Brand);
                }

                 
            }
            
                return li;

        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategoryAndPranch(int c, string Brand)
        {
            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false && p.CategoryID ==c && p.Brand==Brand).ToListAsync();

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
                    IsDeleted = product.IsDeleted,



                };
                productDtoList.Add(productDto);

            }

            return productDtoList;
        }
    }
}
