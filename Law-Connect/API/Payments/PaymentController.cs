using Microsoft.AspNetCore.Mvc;
using Law_Connect.Payments.Application.Services;
using Law_Connect.Payments.Application.DTOs;
using System.Threading.Tasks;

namespace Law_Connect.API.Payments
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentDTO paymentDto)
        {
            var result = await _paymentService.ProcessPaymentAsync(paymentDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }
    }
}
