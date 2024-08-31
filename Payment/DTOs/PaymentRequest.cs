namespace Payment.DTOs
{
    public class PaymentRequest
    {
        public int AccountNo { get; set; } 
        public string AccountName { get; set; }
        public int AcqId { get; set; }
        public decimal Amount { get; set; }
        public string AddInfo { get; set; }
        public string Format { get; set; }
        public string Template { get; set; }
    }
}
