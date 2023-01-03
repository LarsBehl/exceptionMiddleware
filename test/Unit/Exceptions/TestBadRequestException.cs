using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestBadRequestException
{
    [TestCase("Bad Request", "BadRequest")]
    public void TestNoArgsConstructor(string title, string defaultMessage)
    {
        BadRequestException badRequestException = new BadRequestException();
        Assert.That(badRequestException.Title, Is.EqualTo(title));
        Assert.That(badRequestException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(badRequestException.ErrorCode, Is.EqualTo((int) ErrorCodes.BadRequest));

        BadRequestObjectResult? response = badRequestException.ResponseObject as BadRequestObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.Title, Is.EqualTo(title));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.BadRequest));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        BadRequestException badRequestException = new BadRequestException(detailMessage);
        Assert.That(badRequestException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(badRequestException.ErrorCode, Is.EqualTo((int) ErrorCodes.BadRequest));

        BadRequestObjectResult? response = badRequestException.ResponseObject as BadRequestObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.BadRequest));
    }

    [TestCase("This is a detail message", 40002)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        BadRequestException badRequestException = new BadRequestException(detailMessage, errorCode);
        Assert.That(badRequestException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(badRequestException.ErrorCode, Is.EqualTo(errorCode));

        BadRequestObjectResult? response = badRequestException.ResponseObject as BadRequestObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
