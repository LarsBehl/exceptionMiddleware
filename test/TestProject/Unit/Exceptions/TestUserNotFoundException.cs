using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestUserNotFoundException
{
    [TestCase("Not Found", "User not found")]
    public void TestNoArgsCtor(string title, string defaultMessage)
    {
        UserNotFoundException userNotFoundException = new UserNotFoundException();
        Assert.That(userNotFoundException.Title, Is.EqualTo(title));
        Assert.That(userNotFoundException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(userNotFoundException.ErrorCode, Is.EqualTo((int) ErrorCodes.UserNotFound));

        NotFoundObjectResult? response = userNotFoundException.ResponseObject as NotFoundObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.Title, Is.EqualTo(title));
        Assert.That(content.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.UserNotFound));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        UserNotFoundException userNotFoundException = new UserNotFoundException(detailMessage);
        Assert.That(userNotFoundException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(userNotFoundException.ErrorCode, Is.EqualTo((int) ErrorCodes.UserNotFound));

        NotFoundObjectResult? response = userNotFoundException.ResponseObject as NotFoundObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.UserNotFound));
    }

    [TestCase("This is a detail message", 40405)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        UserNotFoundException userNotFoundException = new UserNotFoundException(detailMessage, errorCode);
        Assert.That(userNotFoundException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(userNotFoundException.ErrorCode, Is.EqualTo(errorCode));
        
        NotFoundObjectResult? response = userNotFoundException.ResponseObject as NotFoundObjectResult;
        Assert.NotNull(response);
        Assert.NotNull(response!.Value);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.NotNull(content);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}
