namespace Nasas.Domain.Dtos.Input;

public class ScientistDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName => $"{LastName} {FirstName}";
}

