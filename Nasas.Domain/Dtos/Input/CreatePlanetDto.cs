using Nasas.Domain.Models;

namespace Nasas.Domain.Dtos.Input;

public class CreatePlanetDto
{

    public string Name { get; set; }

    public double Mass { get; set; }

    public double Radius { get; set; }

    public int Age { get; set; }

    public string? Image { get; set; }

    public string Type { get; set; }

    public string Orbit { get; set; }

    public string Composition { get; set; }

    public string Status { get; set; }

}

