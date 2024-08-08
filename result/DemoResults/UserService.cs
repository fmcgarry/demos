namespace DemoResults;

public class User
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class UserService
{
    public Result<User> AddUser(string firstName, string lastName)
    {
        // Old way - Throw exceptions and let caller figure out what to do with them.
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result<User>.Fail("First name cannot be null or whitespace.");
        }

        // What if we don't like users with the name of Ted?
        if (firstName.Equals("ted", StringComparison.OrdinalIgnoreCase))
        {
            return Result<User>.Fail("We don't like Teds here!");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName
        };

        return Result<User>.Success(user);
    }
}
