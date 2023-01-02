using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface ICategoryServie
    {
        Task add(CategoryDto categoryDto);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<List<CategoryDto>> GetByName(string name);
        void Delete(CategoryDto categoryDto);
        void CDelete(int id);
     

        void Update( CategoryDto categoryDto);
        //Task Update( CategoryDto categoryDto);
        //void Update(int id ,string NameA , string NameE);
    }
}
