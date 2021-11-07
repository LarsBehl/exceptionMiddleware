namespace ExceptionMiddleware.Exceptions
{
    public enum ErrorCodes
    {
        BadRequest = 40000,
        Unauthorized = 40100,
        Forbidden = 40300,
        RessourceNotFound = 40400,
        UserNotFound = 40401,
        InternalServerError = 50000
    }
}