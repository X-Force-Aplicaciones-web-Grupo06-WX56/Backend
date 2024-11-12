using Law_Connect.IAM.Domain.Aggregates;

namespace Law_Connect.IAM.Domain.Entities
{
    public class Lawyer : User
    {
        public Lawyer() : base()
        {
            Clients = new List<Client>();
        }

        public Lawyer(string firstName, string lastName, string password, string email, string street, string number, string city, string country, string specialization, int yearsOfExperience, ICollection<Client> clients)
            : base(firstName, lastName, password, email, street, number, city, country)
        {
            Specialization = specialization;
            YearsOfExperience = yearsOfExperience;
            Clients = clients;
        }
        public Lawyer(string firstName, string lastName, string password, string email, string street, string number, string city, string country, string specialization, int yearsOfExperience)
    : base(firstName, lastName, password, email, street, number, city, country)
        {
            Specialization = specialization;
            YearsOfExperience = yearsOfExperience;
            Clients = new List<Client>();
        }

        public int LawyerId { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
