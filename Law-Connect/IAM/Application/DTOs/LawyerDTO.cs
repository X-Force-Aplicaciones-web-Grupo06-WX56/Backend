using System.Collections.Generic;
using Law_Connect.IAM.Application.DTOs;

namespace Law_Connect.IAM.Application.DTOs
{
    public class LawyerDTO : UserDTO
    {
        public int LawyerId { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }

        public LawyerDTO(int id, string firstName, string lastName, string email, string password, string street, string number, string city, string country, int lawyerId, string specialization, int yearsOfExperience)
            : base(id, firstName, lastName, email, password, street, number, city, country)
        {
            LawyerId = lawyerId;
            Specialization = specialization;
            YearsOfExperience = yearsOfExperience;
        }
    }
}

