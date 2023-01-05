# Exception Middleware
![Nuget Version](https://img.shields.io/nuget/v/Aspnetcore.ExceptionMiddleware)
![Nuget downloads](https://img.shields.io/nuget/dt/Aspnetcore.ExceptionMiddleware)

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
Please note that, if the controller method should be annotated with the `ProducesResponseType` attribute, the type `ErrorResponse` has to be specified explicitly in addition to the `StatusCode`, as extension constructors are not supported by `C#`. One possible solution could be extending the `ProducesResponseType` attribute and modifying the constructor to use the `ErrorResponse` object as the default type.

## Adding additional exceptions
Even though the package already provides some exceptions that are commonly used when developing a Web-API, it is also possible to add additional exceptions for special use. The only issue is, that in `C#` it is not possible to extend an enum. This means that if you want to add the new error codes to the `OpenAPI` specification, they have to be added manually as seen in `ExceptionDocumentFilter.cs`.

The newly added Exception has to be derived from the class `AppException`, provided by this package. The class `AppException` is `abstract` and contains a single `abstract` property `ResponseObject`
```c#
public abstract IActionResult ResponseObject { get; }
```
all its other properties and methods are already implemented. Implementing the property is as simple as returning a new object of a type derived from `ObjectResult`. To add the value expected by the constructor, simply call the `GetErrorObject` method provided by `AppException`, which creates an instance of `ErrorResponse` containing the data of the exception. For further information have a look at `Exceptions/BadRequestException.cs`.

## Additional features
In addition to the previously mentioned features, the package also contains the definition of for `InternalServerErrorObjectResult` and `InternalServerErrorResult`.
