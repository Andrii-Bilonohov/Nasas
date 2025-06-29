namespace Nasas.Domain.Abstraction.Models;

    public abstract class PlanetFilter
    {
        public string? Name { get; set; }

        public double? Radius { get; set; }
    }

