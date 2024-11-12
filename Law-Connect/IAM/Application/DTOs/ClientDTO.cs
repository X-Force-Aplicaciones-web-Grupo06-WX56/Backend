using Law_Connect.IAM.Application.DTOs;

namespace Law_Connect.IAM.Application.DTOs
{
    public class ClientDTO : UserDTO
    {
        public int ClientId { get; set; }

        public ClientDTO(int id, string firstName, string lastName, string email, string password, string street, string number, string city, string country, int clientId)
            : base(id, firstName, lastName, email, password, street, number, city, country)
        {
            ClientId = clientId;
        }
    }
}
