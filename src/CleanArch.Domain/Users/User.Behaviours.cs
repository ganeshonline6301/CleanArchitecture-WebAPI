namespace CleanArch.Domain.Users;

public partial class User
{
    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Name cannot be empty", nameof(newName));
        }
        Name = newName;
    }

    public void UpdateEmail(string newEmail)
    {
        if (!IsValidEmail(newEmail))
        {
            throw new ArgumentException("Invalid email format", nameof(newEmail));
        }
        Email = newEmail;
    }

    private static bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}