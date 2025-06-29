


namespace Nasas.Domain.Models;

    public class Planet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Mass { get; set; }

        public double Radius { get; set; }

        public int Age { get; set; }
        
        public string? Image { get; set; }

        public string Type { get; set; }

        public string  Orbit { get; set; }

        public string Composition { get; set; }

        public string Status { get; set; }

        public int? ScientistId { get; set; }

        public Scientist Scientist { get; set; }
    }

