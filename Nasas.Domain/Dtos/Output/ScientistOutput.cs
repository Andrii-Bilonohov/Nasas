namespace Nasas.Domain.Dtos.Output
{
    public class ScientistOutput
    {
        public string Image { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
    }
}
