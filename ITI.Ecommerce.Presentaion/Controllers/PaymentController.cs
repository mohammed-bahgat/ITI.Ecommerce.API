using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService;
       public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;

        }
       [HttpPost("Add")]
        public async Task<int> Add(PaymentDto dto)
        {
         var PaymentId= await _paymentService.add(dto);
          return PaymentId;
        }

        [HttpPost("Update")]
        public void Update(PaymentDto dto)
        {
            if(dto != null)
            {
                _paymentService.Update(dto);
            }
            
            
        }
        [HttpGet(" GetALl")]
        public async Task<List<PaymentDto>> GetALl()
        {
         
            var dto= await _paymentService.GetAll();
            List<PaymentDto> li = new List<PaymentDto>();
            foreach(var it in dto)
            {
                li.Add(it);
            }
            return li;
        }
    }
}
