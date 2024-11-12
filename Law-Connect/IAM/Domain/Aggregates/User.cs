using Law_Connect.IAM.Domain.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace Law_Connect.IAM.Domain.Aggregates
{

    public partial class User
    {
        public int Id { get; }
        public PersonName Name { get; private set; }
        public EmailAddress Email { get; private set; }
        public StreetAddress Street { get; private set; }
        public string Password { get; private set; }

        public User()
        {
            Name = new PersonName();
            Email = new EmailAddress();
            Street = new StreetAddress();
            Password = string.Empty;
        }

        public User(string firstName, string lastName, string password, string email, string street, string number
            , string city, string country)
        {
            Name = new PersonName(firstName, lastName);
            Email = new EmailAddress(email);
            Street = new StreetAddress(street, number, city, country);
            Password = HashPassword(password);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
