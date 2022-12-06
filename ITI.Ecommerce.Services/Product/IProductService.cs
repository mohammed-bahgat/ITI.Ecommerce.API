using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public interface IProductService
    {
        Task add(ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<IEnumerable<CategoryDto>> GetAllCat();
        Task<ProductDto> GetById(int id);
        Task<IEnumerable<ProductDto>> GetByCategoryId(int id);
        void Delete(int product);
        void Update(ProductDto productDto);
    }
}
