

namespace Nasas.Domain.Models;

    public abstract class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
    
        public string LastName { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public Login Login { get; set; }
}

