using Core.Application.Wrappers.Enums;

namespace Core.Application.Wrappers;

public record Result
{
    public required string Message { get; init; }
    public bool IsSucceed { get; protected init; }
    public bool IsFailed => !IsSucceed;
    public ErrorTypeCode ErrorCode { get; protected init; } = ErrorTypeCode.None;

    protected Result()
    {
    }

    public static Result Successful(string message = "Request Succeed")
    {
        return new Result { Message = message, IsSucceed = true };
    }

    public static Result Failed(ErrorTypeCode errorTypeCode, string message = "Request Failed")
    {
        return new Result { Message = message, IsSucceed = false, ErrorCode = errorTypeCode };
    }
}

public record Result<T> : Result
{
    public T? Data { get; private init; }


    public static Result<T> Successful(T data, string message = "Request Succeed")
    {
        return new Result<T> { Data = data, IsSucceed = true, Message = message };
    }

    public new static Result<T> Failed(ErrorTypeCode errorTypeCode, string message = "Request Failed")
    {
        return new Result<T> { IsSucceed = false, ErrorCode = errorTypeCode, Message = message };
    }
}