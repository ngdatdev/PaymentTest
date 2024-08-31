using Payment.DTOs;

namespace Payment.Services
{
    public interface IPayService
    {
        Task<string> CreatePaymentQRCode(PaymentRequest paymentRequest);
    }
}
