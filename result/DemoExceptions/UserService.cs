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
        // Throw exceptions and make the caller figure out what to do with them.

        // Ensure firstname has a value.
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or whitespace.", firstName);
        }

        // Ensure lastname has a value.
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or whitespace.", firstName);
        }

        // Don't allow people named Ted to be added.
        if (firstName.Equals("ted", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("We don't like people named Ted around here!", firstName);
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName
        };

        return user;
    }
}
