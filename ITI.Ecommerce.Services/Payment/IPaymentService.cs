using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IPaymentService
    {
        Task<int> add(PaymentDto paymentDto);
        Task<IEnumerable<PaymentDto>> GetAll();
        Task<PaymentDto> GetById(int id);
        //void Delete(PaymentDto paymentDto);
        void Update(PaymentDto paymentDto);
    }
}
