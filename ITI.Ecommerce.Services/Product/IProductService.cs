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
         
        Task<IEnumerable<ProductDto>> GetAll();
        Task<IEnumerable<CategoryDto>> GetAllCat();
        Task<ProductDto> GetById(int id);
        Task<IEnumerable<ProductDto>> GetByCategoryId(int id);

        Task<IEnumerable<ProductDto>> GetByPrice(float id);
        Task<IEnumerable<ProductDto>> FiletrProductBYname(string name);
        Task<IEnumerable<ProductDto>> FiletrProductBYnameDes();

        Task<List<string>> GetCategoryBrand(int cat);

    }
}
