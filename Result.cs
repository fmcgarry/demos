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

    public static Task<Result> SuccessAsync() => Task.FromResult(Success());

    public static Result Fail() => new() { IsSuccessful = false };

    public static Result Fail(string error) => new() { IsSuccessful = false, Errors = [error] };

    public static Result Fail(IEnumerable<string> errors) => new() { IsSuccessful = false, Errors = errors };

    public static Task<Result> FailAsync() => Task.FromResult(Fail());

    public static Task<Result> FailAsync(string message) => Task.FromResult(Fail(message));

    public static Task<Result> FailAsync(IEnumerable<string> messages) => Task.FromResult(Fail(messages));
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

    public static Task<Result<T>> SuccessAsync(T data) => Task.FromResult(Success(data));

    public static new Result<T> Fail() => new() { IsSuccessful = false };

    public static new Result<T> Fail(string error) => new() { IsSuccessful = false, Errors = [error] };

    public static new Result<T> Fail(IEnumerable<string> errors) => new() { IsSuccessful = false, Errors = errors };

    public static new Task<Result<T>> FailAsync() => Task.FromResult(Fail());

    public static new Task<Result<T>> FailAsync(string error) => Task.FromResult(Fail(error));

    public static new Task<Result<T>> FailAsync(IEnumerable<string> errors) => Task.FromResult(Fail(errors));
}
