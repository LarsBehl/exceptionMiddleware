namespace ExceptionMiddleware.Model;

/// <summary>
/// Content of the HTTP response for all exceptions defined in this package
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Title of the encountered error
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// A detailed description of the encountered error
    /// </summary>
    public required string DetailMessage { get; set; }
    /// <summary>
    /// A custom error code providing further information
    /// </summary>
    public required int ErrorCode { get; set; }
}
