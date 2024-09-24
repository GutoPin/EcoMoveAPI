using System.Net.Mime;
using EcoMoveAPI.UserManagement.Domain.Services;
using EcoMoveAPI.UserManagement.Infrastructure.Pipeline.Middleware.Attributes;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;
using EcoMoveAPI.UserManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.UserManagement.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    /**
     * <summary>
     *     Sign in endpoint. It allows to authenticate a user
     * </summary>
     * <param name="signInResource">The sign in resource containing username and password.</param>
     * <returns>The authenticated user resource, including a JWT token</returns>
     */
    [HttpPost("sign-in")]
    [SwaggerOperation(
        Summary = "Signs in a user",
        Description = "Signs in a user with a given username and password",
        OperationId = "SignIn")]
    [SwaggerResponse(200, "The user was authenticated", typeof(AuthenticatedUserResource))]
    [AllowAnonymous]
    
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var resource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(resource);
    }
    
    /**
     * <summary>
     *     Sign up endpoint. It allows to create a new user
     * </summary>
     * <param name="signUpResource">The sign up resource containing username and password.</param>
     * <returns>A confirmation message on successful creation.</returns>
     */
    [HttpPost("sign-up")]
    [SwaggerOperation(
        Summary = "Signs up a user",
        Description = "Signs up a user with a given username and password",
        OperationId = "SignUp")]
    [SwaggerResponse(201, "The user was created", typeof(AuthenticatedUserResource))]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await userCommandService.Handle(signUpCommand);
        return Ok(new { message = "User created successfully" });
    }
}