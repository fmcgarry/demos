# Results Pattern

This subfolder is a simple demo for the Result Pattern.

## Result.cs

This implementation is a very simple version of the Result object. There's better and other ways to create it, as seen in [FluentResults](https://github.com/altmann/FluentResults/blob/master/src/FluentResults/Results/Result.cs) or [here](https://medium.com/@wgyxxbf/result-pattern-a01729f42f8c).

```csharp 
public class Result
{
    protected Result()
    {
        // Don't expose a constructor.
        // Create a new result using the static methods below.
    }

    public IEnumerable<string> Errors { get; protected set; } = [];

    public bool IsSuccessful { get; protected set; }

    public bool IsFailure => !IsSuccessful;

    public static Result Success() => new() { IsSuccessful = true };

    public static Result Fail() => new() { IsSuccessful = false };

    public static Result Fail(string error) => new() { IsSuccessful = false, Errors = [error] };

    public static Result Fail(IEnumerable<string> errors) => new() { IsSuccessful = false, Errors = errors };
}

public class Result<T> : Result
{
    private Result()
    {
        // Don't expose a constructor.
        // Create a new result using the static methods below.
    }

    public T? Data { get; init; } = default;

    public static Result<T> Success(T data) => new() { IsSuccessful = true, Data = data };

    public static new Result<T> Fail() => new() { IsSuccessful = false };

    public static new Result<T> Fail(string error) => new() { IsSuccessful = false, Errors = [error] };

    public static new Result<T> Fail(IEnumerable<string> errors) => new() { IsSuccessful = false, Errors = errors };
}
```
