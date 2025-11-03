namespace DatabaseAccess;
public class Result<TValue, TError>
{
    public TValue Value { get; }
    public TError Error { get; }
    public bool IsSuccess { get; }

    private Result(TValue value)
    {
        Value = value;
        IsSuccess = true;
        Error = default;
    }

    private Result(TError error)
    {
        Error = error;
        IsSuccess = false;
        Value = default;
    }

    public static Result<TValue, TError> Success(TValue value) => new Result<TValue, TError>(value);
    public static Result<TValue, TError> Failure(TError error) => new Result<TValue, TError>(error);
}
