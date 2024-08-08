namespace DemoExceptions;

public class User
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class UserService
{
    public User AddUser(string firstName, string lastName)
    {
        // Throw exceptions and let caller figure out what to do with them.

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or whitespace.", firstName);
        }

        // What if we don't like users with the name of Ted?
        if (firstName.Equals("ted", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("We don't like Teds here!", firstName);
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName
        };

        return user;
    }
}
