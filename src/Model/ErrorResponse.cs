namespace ExceptionMiddleware.Model;

public class ErrorResponse
{
    public required string Title { get; set; }
    public required string DetailMessage { get; set; }
    public required int ErrorCode { get; set; }
}
