


namespace Nasas.Domain.Models;

    public class Planet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Mass { get; set; }

        public double Radius { get; set; }

        public int Age { get; set; }
        
        public string? Image { get; set; }

        //public int Period { get; set; }

        //public double SemiMajorAxis { get; set; }

        //public int Temperature { get; set; }

        //public decimal DistanceLightYear { get; set; }

        //public int HostStarMass { get; set; }

        //public int HostStarTemperature { get; set; }

        public int ScientistId { get; set; }

        public Scientist Scientist { get; set; }
    }

