using System.ComponentModel.DataAnnotations;
using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Test.Application.Controllers;

[ApiController]
[Produces("application/json")]
[Route("test")]
[ProducesErrorResponseType(typeof(ErrorResponse))]
public class TestController : ControllerBase
{
    [HttpGet("badRequest")]
    [ProducesDefaultResponseType]
    public ActionResult GetBadRequestException()
    {
        throw new BadRequestException();
    }

    [HttpGet("forbidden")]
    [ProducesDefaultResponseType]
    public ActionResult GetForbiddenException()
    {
        throw new ForbiddenException();
    }

    [HttpGet("internalServerError")]
    [ProducesDefaultResponseType]
    public ActionResult GetInternalServerErrorException()
    {
        throw new InternalServerErrorException();
    }

    [HttpGet("notFound")]
    [ProducesDefaultResponseType]
    public ActionResult GetNotFoundException()
    {
        throw new NotFoundException();
    }

    [HttpGet("notImplementedError")]
    [ProducesDefaultResponseType]
    public ActionResult GetNotImplementedErrorException()
    {
        throw new NotImplementedErrorException();
    }

    [HttpGet("notImplemented")]
    [ProducesDefaultResponseType]
    public ActionResult GetNotImplementedException()
    {
        throw new NotImplementedException();
    }

    [HttpGet("unauthorized")]
    [ProducesDefaultResponseType]
    public ActionResult GetUnauthorizedException()
    {
        throw new UnauthorizedException();
    }

    [HttpGet("userNotFound")]
    [ProducesDefaultResponseType]
    public ActionResult GetUserNotFoundException()
    {
        throw new UserNotFoundException();
    }

    [HttpGet("arbitrary")]
    [ProducesDefaultResponseType]
    public ActionResult GetArbitraryException()
    {
        throw new IOException();
    }

    [HttpGet("validation")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetValidationError([FromQuery, Range(0, 1)] int validationParam)
    {
        return Ok();
    }

    [HttpGet("conflict")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult GetConflictException()
    {
        throw new ConflictException();
    }
}
