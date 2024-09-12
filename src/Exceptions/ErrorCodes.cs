namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Custom error codes providing additional information.
/// Can be used as a basis when implementing custom exceptions
/// </summary>
public enum ErrorCodes
{
    /// <summary>
    /// The request sent by the user is not valid
    /// </summary>
    BadRequest = 40000,
    /// <summary>
    /// The requesting user is not authorized to perform the requested action
    /// </summary>
    Unauthorized = 40100,
    /// <summary>
    /// The requesting user is forbidden to perform the requested action
    /// </summary>
    Forbidden = 40300,
    /// <summary>
    /// The ressource requested by the user could not be found
    /// </summary>
    RessourceNotFound = 40400,
    /// <summary>
    /// The user requested could not be found
    /// </summary>
    UserNotFound = 40401,
    /// <summary>
    /// The requested resulted in a conflict
    /// </summary>
    Conflict = 40900,
    /// <summary>
    /// While processing the request an unexcpected error occured
    /// </summary>
    InternalServerError = 50000,
    /// <summary>
    /// The requested action is currently not implemented
    /// </summary>
    NotImplemented = 50100
}
