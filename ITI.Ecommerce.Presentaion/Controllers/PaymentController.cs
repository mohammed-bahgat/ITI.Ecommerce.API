﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;

namespace ITI.Ecommerce.Presentaion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _Pay;
       public PaymentController(IPaymentService Pay)
        {
        _Pay=Pay;

        }
       [HttpPost("Add")]
        public async Task<int> Add(PaymentDto dto)
        {
         var PaymentId= await _Pay.add(dto);
          return PaymentId;
        }

        [HttpPost("Update")]
        public void Update(PaymentDto dto)
        {
            if(dto != null)
            {
                _Pay.Update(dto);
            }
            
            
        }
        [HttpGet(" GetALl")]
        public async Task<List<PaymentDto>> GetALl()
        {
         
            var dto= await _Pay.GetAll();
            List<PaymentDto> li = new List<PaymentDto>();
            foreach(var it in dto)
            {
                li.Add(it);
            }
            return li;
        }
    }
}
