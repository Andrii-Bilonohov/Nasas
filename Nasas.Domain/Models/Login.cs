using Nasas.Domain.Abstraction.Models;

namespace Nasas.Domain.Models;

public class Login
{
    public int Id { get; set; }

    public string Username {  get; set; }
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public User User { get; set; }
}

