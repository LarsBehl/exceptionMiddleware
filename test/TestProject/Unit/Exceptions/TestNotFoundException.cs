using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestNotFoundException
{
    [TestCase("Not Found", "Ressource not found")]
    public void TestNoArgsCtor(string title, string defaultMessage)
    {
        NotFoundException notFoundException = new NotFoundException();
        Assert.That(notFoundException.Title, Is.EqualTo(title));
        Assert.That(notFoundException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(notFoundException.ErrorCode, Is.EqualTo((int) ErrorCodes.RessourceNotFound));

        NotFoundObjectResult? response = notFoundException.ResponseObject as NotFoundObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.Title, Is.EqualTo(title));
        Assert.That(content.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.RessourceNotFound));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        NotFoundException notFoundException = new NotFoundException(detailMessage);
        Assert.That(notFoundException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(notFoundException.ErrorCode, Is.EqualTo((int) ErrorCodes.RessourceNotFound));

        NotFoundObjectResult? response = notFoundException.ResponseObject as NotFoundObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.RessourceNotFound));
    }

    [TestCase("This is a detail message", 404002)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        NotFoundException notFoundException = new NotFoundException(detailMessage, errorCode);
        Assert.That(notFoundException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(notFoundException.ErrorCode, Is.EqualTo(errorCode));

        NotFoundObjectResult? response = notFoundException.ResponseObject as NotFoundObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
