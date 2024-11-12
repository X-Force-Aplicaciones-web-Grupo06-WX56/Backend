namespace Law_Connect.IAM.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public UserDTO(int id, string firstName, string lastName, string email, string password, string street, string number, string city, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Street = street;
            Number = number;
            City = city;
            Country = country;
        }
    }
}
