using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace ExceptionMiddleware.Test.Integration;

public class TestOpenApi
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

    [Test]
    public async Task TestModelsPresent()
    {
        HttpResponseMessage response = await this._httpClient.GetAsync("/swagger/v1/swagger.json");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        Stream specStream = await response.Content.ReadAsStreamAsync();
        OpenApiDocument spec = new OpenApiStreamReader().Read(specStream, out OpenApiDiagnostic _);
        IDictionary<string, OpenApiSchema> schemas = spec.Components.Schemas;

        bool success = schemas.TryGetValue("ErrorResponse", out OpenApiSchema? errorResponseSchema);
        Assert.That(success, Is.True);
        Assert.That(errorResponseSchema, Is.Not.Null);

        success = schemas.TryGetValue("ErrorCodes", out OpenApiSchema? errorCodesSchema);
        Assert.That(success, Is.True);
        Assert.That(errorCodesSchema, Is.Not.Null);
    }
}
