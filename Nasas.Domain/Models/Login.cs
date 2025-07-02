using Nasas.Domain.Abstraction.Models;

namespace Nasas.Domain.Models;

public class Login
{
    public int Id { get; set; }

    public string Username => $"{User.FirstName}{User.LastName}".ToLowerInvariant();

    public string Email { get; set; }

    public string Password { get; set; }

    public User User { get; set; }
}

