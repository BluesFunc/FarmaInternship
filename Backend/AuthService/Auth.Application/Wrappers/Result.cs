using Auth.Application.Wrappers.Enums;

namespace Auth.Application.Wrappers;

public record Result
{
    public bool IsSuccessful { get; init; }
    public string Message { get; init; }
    public ErrorStatusCode StatusCode { get; init; }

    public static Result Succeed(string message = "")
    {
        return new Result() { IsSuccessful = true, Message = message };
    }

    public static Result Failed(ErrorStatusCode statusCode, string message = "")
    {
        return new Result() { StatusCode = statusCode, IsSuccessful = false, Message = message };
    }

    protected Result()
    {
    }
}

public record Result<T> : Result
{
    public T Data { get; init; }

    

    public static Result<T> Succeed(T data, string message = "")
    {
        return new Result<T>() { Data = data, IsSuccessful = true, Message = message };
    }

    public new static Result<T> Failed(ErrorStatusCode statusCode, string message = "")
    {
        return new Result<T>() { IsSuccessful = false, StatusCode = statusCode, Message = message };
    }
}