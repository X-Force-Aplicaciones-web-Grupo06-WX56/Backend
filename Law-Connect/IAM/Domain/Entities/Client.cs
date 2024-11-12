using Law_Connect.IAM.Domain.Aggregates;
using System.Security.Principal;

namespace Law_Connect.IAM.Domain.Entities
{
    public class Client : User
    {
        public Client() : base()
        {
        }

        public Client(string firstName, string lastName, string password, string email, string street, string number, string city, string country)
            : base(firstName, lastName, password, email, street, number, city, country)
        {
        }

        public int ClientId { get; set; }
    }
}
