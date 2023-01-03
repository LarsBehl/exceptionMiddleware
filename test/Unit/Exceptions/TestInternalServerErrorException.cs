using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Extensions;
using ExceptionMiddleware.Model;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestInternalServerErrorException
{
    [TestCase("Internal Server Error", "An unexpected Error occured")]
    public void TestNoArgsConstructor(string title, string defaultMessage)
    {
        InternalServerErrorException internalServerErrorException = new InternalServerErrorException();
        Assert.That(internalServerErrorException.Title, Is.EqualTo(title));
        Assert.That(internalServerErrorException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(internalServerErrorException.ErrorCode, Is.EqualTo((int) ErrorCodes.InternalServerError));

        InternalServerErrorObjectResult? response = internalServerErrorException.ResponseObject as InternalServerErrorObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.Title, Is.EqualTo(title));
        Assert.That(content.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.InternalServerError));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        InternalServerErrorException internalServerErrorException = new InternalServerErrorException(detailMessage);
        Assert.That(internalServerErrorException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(internalServerErrorException.ErrorCode, Is.EqualTo((int) ErrorCodes.InternalServerError));

        InternalServerErrorObjectResult? response = internalServerErrorException.ResponseObject as InternalServerErrorObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.InternalServerError));
    }

    [TestCase("This is a detail message", 50002)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        InternalServerErrorException internalServerErrorException = new InternalServerErrorException(detailMessage, errorCode);
        Assert.That(internalServerErrorException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(internalServerErrorException.ErrorCode, Is.EqualTo(errorCode));

        InternalServerErrorObjectResult? response = internalServerErrorException.ResponseObject as InternalServerErrorObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
