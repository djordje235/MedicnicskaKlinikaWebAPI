using System.Text;
using DatabaseAccess;
public static class ResultExtensions
{
    public static Result<T, ErrorMessage> ToError<T>(this string message, int statusCode)
    {
        return Result<T, ErrorMessage>.Failure(new ErrorMessage { Message = message, StatusCode = statusCode });
    }
}

