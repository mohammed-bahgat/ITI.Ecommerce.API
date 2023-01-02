using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IOrderService
    {
        Task<int> add(OrderDto orderDto);
        Task<IEnumerable<OrderDto>> GetAll();
        Task<IEnumerable<OrderDto>> GetByCustomerId(string CustomerId);
        Task<OrderDto> GetById(int id); 
         
         void Delete(int id);

        Task Update(OrderDto orderDto);
        public Task<int> GetProductRate(int orderId, int prdId);

        public Task SetProductRate(int orderId, int prdId, int rate);
    }
}
