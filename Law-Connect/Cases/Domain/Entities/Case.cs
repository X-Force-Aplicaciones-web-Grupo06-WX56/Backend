namespace Law_Connect.Cases.Domain.Entities
{
    public class Case
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Case(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
