using CleanArch.Domain.Common;

namespace CleanArch.Domain.User;

public class User : Entity
{
    public string Name { get; }
    public string Email { get; }

    public User( string name, string email, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Name = name;
        Email = email;
    }

    private User()
    {
        
    }
}