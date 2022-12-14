using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IShoppingCartService
    {
        Task<int> add(ShoppingCartDto shoppingCartDto);
        //Task add(ShoppingCartDT shoppingCartDT);
        Task<IEnumerable<ShoppingCartDto>> GetAll();
        Task<ShoppingCartDto> GetById(int id);
        void Delete(ShoppingCartDto shoppingCartDto);
        void DeleteCart(int id);
        void Update(ShoppingCartDto shoppingCartDto);
        void UpdateCart(int id , ShoppingCartDto shoppingCartDto);
    }
}
