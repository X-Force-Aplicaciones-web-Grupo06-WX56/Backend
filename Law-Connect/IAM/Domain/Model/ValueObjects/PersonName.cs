namespace Law_Connect.IAM.Domain.Model.ValueObjects
{
    public record PersonName(string FirstName, string LastName)
    {
        public PersonName() : this(string.Empty,string.Empty) 
        {
        }
        public PersonName(string FirstName) : this(FirstName, string.Empty) { }

        public string FullName => $"{FirstName} {LastName}";
    }
}
