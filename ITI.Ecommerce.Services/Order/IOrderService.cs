using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IOrderService
    {
        Task<int> add(OrderDto orderDto);
        Task<IEnumerable<OrderDto>> GetAll();
        Task<IEnumerable<OrderDto>> GetByCustomerId(string CustomerId);
        Task<OrderDto> GetById(int id); 
         //void Delete(OrderDto orderDto);
         void Delete(int id);

        void Update(OrderDto orderDto);
    }
}
