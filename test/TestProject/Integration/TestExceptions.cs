using System.Net;
using System.Net.Http.Json;
using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExceptionMiddleware.Test.Integration;

public class TestExceptions
{
    private WebApplicationFactory<ExceptionMiddleware.Test.Application.Program> _applicationFactory = null!;
    private HttpClient _httpClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        this._applicationFactory = new WebApplicationFactory<ExceptionMiddleware.Test.Application.Program>();
        this._httpClient = this._applicationFactory.CreateClient();
    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        await this._applicationFactory.DisposeAsync();
    }

    [TestCase("/test/badRequest", (int) ErrorCodes.BadRequest, HttpStatusCode.BadRequest)]
    [TestCase("/test/forbidden", (int) ErrorCodes.Forbidden, HttpStatusCode.Forbidden)]
    [TestCase("/test/internalServerError", (int) ErrorCodes.InternalServerError, HttpStatusCode.InternalServerError)]
    [TestCase("/test/notFound", (int) ErrorCodes.RessourceNotFound, HttpStatusCode.NotFound)]
    [TestCase("/test/notImplementedError", (int) ErrorCodes.NotImplemented, HttpStatusCode.NotImplemented)]
    [TestCase("/test/notImplemented", (int) ErrorCodes.NotImplemented, HttpStatusCode.NotImplemented)]
    [TestCase("/test/unauthorized", (int) ErrorCodes.Unauthorized, HttpStatusCode.Unauthorized)]
    [TestCase("/test/userNotFound", (int) ErrorCodes.UserNotFound, HttpStatusCode.NotFound)]
    [TestCase("/test/arbitrary", (int) ErrorCodes.InternalServerError, HttpStatusCode.InternalServerError)]
    public async Task TestExplicitErrors(string path, int errorCode, HttpStatusCode statusCode)
    {
        HttpResponseMessage response = await this._httpClient.GetAsync(path);
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        ErrorResponse? content = null;
        Assert.DoesNotThrowAsync(async () => content = await response.Content.ReadFromJsonAsync<ErrorResponse>());
        Assert.NotNull(content);
        Assert.That(content!.ErrorCode, Is.EqualTo(errorCode));
    }

    [Test]
    public async Task TestValidation()
    {
        HttpResponseMessage response = await this._httpClient.GetAsync("/test/validation?validationParam=2");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        ErrorResponse? content = null;
        Assert.DoesNotThrowAsync(async () => content = await response.Content.ReadFromJsonAsync<ErrorResponse>());
        Assert.NotNull(content);
        Assert.That(content!.ErrorCode, Is.EqualTo((int) ErrorCodes.BadRequest));
    }
}