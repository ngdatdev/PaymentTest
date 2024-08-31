using Microsoft.AspNetCore.Mvc;
using Payment.DTOs;
using Payment.Services;


namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPayService _payService;

        public PaymentController(IPayService payService)
        {
            _payService = payService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PaymentRequest paymentRequest)
        {
            var result = _payService.CreatePaymentQRCode(paymentRequest: paymentRequest);

            return Ok(result);
        }

    }
}
