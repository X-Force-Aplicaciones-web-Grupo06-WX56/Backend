namespace Law_Connect.Payments.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
    }
}
