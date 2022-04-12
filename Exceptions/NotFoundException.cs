using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

public class NotFoundException : AppException
{
    private static readonly string DEFAULT_MESSAGE = "Ressource not found";
    private static readonly string TITLE = "Not Found";

    public override IActionResult ResponseObject => new NotFoundObjectResult(this.GetErrorObject());

    public NotFoundException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    public NotFoundException(string detailMessage) : this(detailMessage, (int)ErrorCodes.RessourceNotFound)
    {

    }

    public NotFoundException() : this(DEFAULT_MESSAGE)
    {

    }
}
