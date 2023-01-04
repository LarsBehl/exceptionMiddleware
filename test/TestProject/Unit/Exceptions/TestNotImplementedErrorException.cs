using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Extensions;
using ExceptionMiddleware.Model;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestNotImplementedErrorException
{
    [TestCase("Not Implemented", "NotImplemented")]
    public void TestNoArgsCtor(string title, string defaultMessage)
    {
        NotImplementedErrorException notImplementedErrorException = new NotImplementedErrorException();
        Assert.That(notImplementedErrorException.Title, Is.EqualTo(title));
        Assert.That(notImplementedErrorException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(notImplementedErrorException.ErrorCode, Is.EqualTo((int) ErrorCodes.NotImplemented));

        NotImplementedObjectResult? response = notImplementedErrorException.ResponseObject as NotImplementedObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.Title, Is.EqualTo(title));
        Assert.That(content.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.NotImplemented));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        NotImplementedErrorException notImplementedErrorException = new NotImplementedErrorException(detailMessage);
        Assert.That(notImplementedErrorException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(notImplementedErrorException.ErrorCode, Is.EqualTo((int) ErrorCodes.NotImplemented));

        NotImplementedObjectResult? response = notImplementedErrorException.ResponseObject as NotImplementedObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.NotImplemented));
    }

    [TestCase("This is a detail message", 50102)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        NotImplementedErrorException notImplementedErrorException = new NotImplementedErrorException(detailMessage, errorCode);
        Assert.That(notImplementedErrorException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(notImplementedErrorException.ErrorCode, Is.EqualTo(errorCode));

        NotImplementedObjectResult? response = notImplementedErrorException.ResponseObject as NotImplementedObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
