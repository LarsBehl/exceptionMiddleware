# Exception Middleware
[![Nuget Version](https://img.shields.io/nuget/v/Aspnetcore.ExceptionMiddleware)](https://www.nuget.org/packages/Aspnetcore.ExceptionMiddleware/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Aspnetcore.ExceptionMiddleware)](https://www.nuget.org/packages/Aspnetcore.ExceptionMiddleware/)

This project is a small extension for `ASP.NET Core` Applications, which provides the functionality to throw exceptions that are caught by a filter and translated to an error response. Additionally it is possible to add the `ErrorResponse` model and the additional 

## Getting started
After adding the package to an `ASP.NET Core` project
```bash
dotnet add package Aspnetcore.ExceptionMiddleware
```
the application can be configured to to use the exception middleware by adding the following code to method `ConfigureServices`, usually located in the `Startup.cs` file:
```c#
services.AddControllers().AddExceptions();
```
It is also possible to add Controllers with exceptions as one call, by replacing:
```c#
services.AddControllers();
```
with
```c#
services.AddControllersWithExceptions();
```
>Please note that this automatically replaces the errors sent on validation error with an `ErrorResponse` containing the appropriate content

When using `Swashbuckle.AspNetCore` for swagger generation, the schema for `ErrorResponse` and the `ErrorCodes` can be added to the generated `OpenAPI` specification of the api by changing the configuration of the swagger generation:
```c#
services.AddSwaggerGen(c =>
{
  // other configurations

  c.AddExceptions();
});
```
In order to enable the application to automatically respond with an `ErrorResponse` if an error is encountered during parameter validation add the following line to the `Startup.cs` or application configuration:
```c#
services.AddValidationSupport();
```

### Note
In order for the `ErrorResponse` to be shown in the `OpenAPI` specification as the error response an endpoint, one should annotate the Controller with the `ProducesErrorResponseType` attribute. While it is possible to use the `ProducesResponseType` or `ProducesResponseType<T>` attribute on a per method level, the margin of error is smaller when defining the error response type on a controller level.

## Adding additional exceptions
Even though the package already provides some exceptions that are commonly used when developing a Web-API, it is also possible to add additional exceptions for special use. The only issue is, that in `C#` it is not possible to extend an enum. This means that if you want to add the new error codes to the `OpenAPI` specification, they have to be added manually as seen in `ExceptionDocumentFilter.cs`.

The newly added Exception has to be derived from the class `AppException<T>`, provided by this package. The class `AppException<T>` is `abstract` but does not contain any abstract member. This is used to prevent users from throwing a raw `AppException<T>` by accident.

The generic type of `AppException<T>` has a type-constraint, so that the given type has to be derived from `ObjectResult`. The given generic type is used for the error response and thus has impact, for example, on the status code.

## Additional features
In addition to the previously mentioned features, the package also contains multiple type definitions for types derived from `ObjectResult`:
* `ForbiddenObjectResult`
* `InternalServerErrorObjectResult`
* `InternalServerErrorResult`
* `NotImplementedObjectResult`
