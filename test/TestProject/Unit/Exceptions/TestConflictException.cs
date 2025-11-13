using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Unit.Exceptions;

public class TestConflictException
{
    [TestCase("Conflict", "Conflict")]
    public void TestNoArgsConstructor(string title, string defaultMessage)
    {
        ConflictException ConflictException = new ConflictException();
        Assert.That(ConflictException.Title, Is.EqualTo(title));
        Assert.That(ConflictException.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(ConflictException.ErrorCode, Is.EqualTo((int) ErrorCodes.Conflict));

        ConflictObjectResult? response = ConflictException.ResponseObject as ConflictObjectResult;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Value, Is.Not.Null);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.That(content, Is.Not.Null);
        Assert.That(content!.DetailMessage, Is.EqualTo(defaultMessage));
        Assert.That(content.Title, Is.EqualTo(title));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.Conflict));
    }

    [TestCase("This is a detail message")]
    public void TestDetailMessageCtor(string detailMessage)
    {
        ConflictException ConflictException = new ConflictException(detailMessage);
        Assert.That(ConflictException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(ConflictException.ErrorCode, Is.EqualTo((int) ErrorCodes.Conflict));

        ConflictObjectResult? response = ConflictException.ResponseObject as ConflictObjectResult;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Value, Is.Not.Null);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.That(content, Is.Not.Null);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo((int) ErrorCodes.Conflict));
    }

    [TestCase("This is a detail message", 40902)]
    public void TestAllArgsConstructor(string detailMessage, int errorCode)
    {
        ConflictException ConflictException = new ConflictException(detailMessage, errorCode);
        Assert.That(ConflictException.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(ConflictException.ErrorCode, Is.EqualTo(errorCode));

        ConflictObjectResult? response = ConflictException.ResponseObject as ConflictObjectResult;
        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Value, Is.Not.Null);

        ErrorResponse? content = response.Value as ErrorResponse;
        Assert.That(content, Is.Not.Null);
        Assert.That(content!.DetailMessage, Is.EqualTo(detailMessage));
        Assert.That(content.ErrorCode, Is.EqualTo(errorCode));
    }
}