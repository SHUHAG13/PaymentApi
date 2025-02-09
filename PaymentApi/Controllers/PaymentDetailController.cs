using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Data;
using PaymentApi.Interfaces;
using PaymentApi.Models;

namespace PaymentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
      
        private readonly IPaymentDetailsInterface _repository;

        public PaymentDetailController(IPaymentDetailsInterface repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentDetails()
        {
            var paymentDetails = await _repository.GetPaymentDetailsasync();
            return Ok(paymentDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentDetailById(int id)
        {
            var paymentDetail = await _repository.GetPaymentDetailByIdasync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            return Ok(paymentDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaymentDetails(PaymentDetails paymentDetails)
        {
            var newPaymentDetails = await _repository.CreatePaymentDetailsAsync(paymentDetails);
            return CreatedAtAction(nameof(GetPaymentDetailById), new { id = newPaymentDetails.PaymentDetailId }, newPaymentDetails);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentDetails(int id, PaymentDetails paymentDetails)
        {
            var updatedPaymentDetails = await _repository.UpdatePaymentDetailsAsync(id, paymentDetails);
            if (updatedPaymentDetails == null)
            {
                return NotFound();
            }
            return Ok(updatedPaymentDetails);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            var result = await _repository.DeletePaymentDetailsAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
