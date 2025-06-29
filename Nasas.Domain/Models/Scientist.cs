

using Nasas.Domain.Abstraction.Models;

namespace Nasas.Domain.Models;

public class Scientist : User
{
    public ICollection<Planet> Planets { get; set; } = new List<Planet>();


}

