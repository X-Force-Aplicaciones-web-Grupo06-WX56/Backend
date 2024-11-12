namespace Law_Connect.Payments.Application.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
    }
}
