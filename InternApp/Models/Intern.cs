namespace InternApp.Models
{
    public class Intern
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string Department { get; set; } = "";

        public int DurationInMonths { get; set; }
    }
}
