using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Extensions;
using ExceptionMiddleware.Model;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestForbiddenException
{
    [TestCase("Forbidden", "Forbidden to access resource")]
    public void TestNoArgsConstructor(string title, string defaultMessage)
    {
        ForbiddenException forbiddenException = new ForbiddenException();
        Assert.That(forbiddenException.Title, Is.EqualTo(title));
        Assert.That(forbiddenException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(forbiddenException.ErrorCode, Is.EqualTo((int) ErrorCodes.Forbidden));

        ForbiddenObjectResult? response = forbiddenException.ResponseObject as ForbiddenObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.Title, Is.EqualTo(title));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.Forbidden));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        ForbiddenException forbiddenException = new ForbiddenException(detailMessage);
        Assert.That(forbiddenException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(forbiddenException.ErrorCode, Is.EqualTo((int) ErrorCodes.Forbidden));

        ForbiddenObjectResult? response = forbiddenException.ResponseObject as ForbiddenObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.Forbidden));
    }

    [TestCase("This is a detail message", 40302)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        ForbiddenException forbiddenException = new ForbiddenException(detailMessage, errorCode);
        Assert.That(forbiddenException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(forbiddenException.ErrorCode, Is.EqualTo(errorCode));

        ForbiddenObjectResult? response = forbiddenException.ResponseObject as ForbiddenObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
