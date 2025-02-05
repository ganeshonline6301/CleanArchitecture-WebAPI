using CleanArch.Domain.Common;

namespace CleanArch.Domain.User;

public partial class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public User( string name, string email, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Name = name;
        Email = email;
    }

    private User()
    {
        
    }
}