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
        // Return a pass or fail w/ meaningful error messages.

        // Ensure firstname has a value.
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result<User>.Fail("First name cannot be null or whitespace.");
        }

        // Ensure lastname has a value.
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result<User>.Fail("Last name cannot be null or whitespace.");
        }

        // Don't allow people named Ted to be added.
        if (firstName.Equals("ted", StringComparison.OrdinalIgnoreCase))
        {
            return Result<User>.Fail("We don't like people named Ted around here!");
        }

        //var validationResult = ValidateUser(firstName, lastName);
        //if (validationResult.IsFailure)
        //{
        //    return Result<User>.Fail(validationResult.Errors);
        //}

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName
        };

        return Result<User>.Success(user);
    }

    private static Result ValidateUser(string firstName, string lastName)
    {
        var errors = new List<string>();

        // Ensure firstname has a value.
        if (string.IsNullOrWhiteSpace(firstName))
        {
            errors.Add("First name cannot be null or whitespace.");
        }

        // Ensure lastname has a value.
        if (string.IsNullOrWhiteSpace(lastName))
        {
            errors.Add("Last name cannot be null or whitespace.");
        }

        // Don't allow people named Ted to be added.
        if (firstName.Equals("ted", StringComparison.OrdinalIgnoreCase))
        {
            errors.Add("We don't like people named Ted around here!");
        }

        return errors.Count == 0 ? Result.Success() : Result.Fail(errors);
    }
}
