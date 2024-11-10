using Org.BouncyCastle.Asn1.Mozilla;

namespace Law_Connect.IAM.Domain.Model.ValueObjects
{
    public record StreetAddress(string Street, string Number, string City, string Country)
    {
        public StreetAddress() : this(string.Empty, string.Empty, string.Empty, string.Empty) { }

        public StreetAddress(string Street): this(Street, string.Empty, string.Empty,string.Empty) { }
         
    }
}
