using Payment.DTOs;
using System.Text;

namespace Payment.Services
{
    public class VNPayService : IPayService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public VNPayService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<string> CreatePaymentQRCode(PaymentRequest paymentRequest)
        {
            var vietQrApiUrl = "https://api.vietqr.io/v2/generate";


            var requestBody = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest),
                Encoding.UTF8,
                "application/json"
            );

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("x-client-id", "22b12fb7-92fa-4f38-a4cc-0a0e4d608301");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "f4c57666-67a2-449b-b5e3-c9febb53e4bf");


            var response = await _httpClient.PostAsync(vietQrApiUrl, requestBody);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }

            throw new HttpRequestException("Failed to generate QR code.");
        }
    }
}
