using System.ComponentModel.DataAnnotations;
using ExceptionMiddleware.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Application.Controllers;

[ApiController]
[Produces("application/json")]
[Route("test")]
public class TestController : ControllerBase
{
    [HttpGet("badRequest")]
    public ActionResult GetBadRequestException()
    {
        throw new BadRequestException();
    }

    [HttpGet("forbidden")]
    public ActionResult GetForbiddenException()
    {
        throw new ForbiddenException();
    }

    [HttpGet("internalServerError")]
    public ActionResult GetInternalServerErrorException()
    {
        throw new InternalServerErrorException();
    }

    [HttpGet("notFound")]
    public ActionResult GetNotFoundException()
    {
        throw new NotFoundException();
    }

    [HttpGet("notImplementedError")]
    public ActionResult GetNotImplementedErrorException()
    {
        throw new NotImplementedErrorException();
    }

    [HttpGet("notImplemented")]
    public ActionResult GetNotImplementedException()
    {
        throw new NotImplementedException();
    }

    [HttpGet("unauthorized")]
    public ActionResult GetUnauthorizedException()
    {
        throw new UnauthorizedException();
    }

    [HttpGet("userNotFound")]
    public ActionResult GetUserNotFoundException()
    {
        throw new UserNotFoundException();
    }

    [HttpGet("arbitrary")]
    public ActionResult GetArbitraryException()
    {
        throw new IOException();
    }

    [HttpGet("validation")]
    public ActionResult GetValidationError([FromQuery, Range(0, 1)] int validationParam)
    {
        return Ok();
    }
}
