namespace Law_Connect.IAM.Domain.ValueObjects
{
    public record EmailAddress(string Address)
    {
        public EmailAddress() : this(string.Empty) { }
    }
}
