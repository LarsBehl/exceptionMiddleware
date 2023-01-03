using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestUnauthorizedException
{
    [TestCase("Unauthorized", "Unauthorized")]
    public void TestNoArgsCtor(string title, string defaultMessage)
    {
        UnauthorizedException unauthorizedException = new UnauthorizedException();
        Assert.That(unauthorizedException.Title, Is.EqualTo(title));
        Assert.That(unauthorizedException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(unauthorizedException.ErrorCode, Is.EqualTo((int) ErrorCodes.Unauthorized));

        UnauthorizedObjectResult? response = unauthorizedException.ResponseObject as UnauthorizedObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.Title, Is.EqualTo(title));
        Assert.That(content.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.Unauthorized));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        UnauthorizedException unauthorizedAccessException = new UnauthorizedException(detailMessage);
        Assert.That(unauthorizedAccessException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(unauthorizedAccessException.ErrorCode, Is.EqualTo((int) ErrorCodes.Unauthorized));

        UnauthorizedObjectResult? response = unauthorizedAccessException.ResponseObject as UnauthorizedObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.Unauthorized));
    }

    [TestCase("This is a detaile message", 40102)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        UnauthorizedException unauthorizedException = new UnauthorizedException(detailMessage, errorCode);
        Assert.That(unauthorizedException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(unauthorizedException.ErrorCode, Is.EqualTo(errorCode));
        
        UnauthorizedObjectResult? response = unauthorizedException.ResponseObject as UnauthorizedObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
