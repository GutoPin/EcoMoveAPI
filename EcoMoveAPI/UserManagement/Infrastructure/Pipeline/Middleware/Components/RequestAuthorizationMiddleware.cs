using EcoMoveAPI.UserManagement.Application.Internal.OutboundServices;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;
using EcoMoveAPI.UserManagement.Domain.Services;
using EcoMoveAPI.UserManagement.Infrastructure.Pipeline.Middleware.Attributes;

namespace EcoMoveAPI.UserManagement.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");
        
        var endpoint = context.Request.HttpContext.GetEndpoint();
        if (endpoint == null)
        {
            Console.WriteLine("Endpoint not found, skipping authorization");
            await next(context);
            return;
        }
        var allowAnonymous = endpoint.Metadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        
        
        // skip authorization if endpoint is decorated with [AllowAnonymous] attribute
        /*var allowAnonymous = context.Request.HttpContext.GetEndpoint()!.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));*/
        
        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            // [AllowAnonymous] attribute is set, so skip authorization
            await next(context);
            return;
        }
        Console.WriteLine("Entering authorization");
        // get token from request header
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();


        // if token is null then throw exception
        if (token == null) throw new Exception("Null or invalid token");

        // validate token
        var userId = await tokenService.ValidateToken(token);

        // if token is invalid then throw exception
        if (userId == null) throw new Exception("Invalid token");

        // get user by id
        var getUserByIdQuery = new GetUserByUserIdQuery(userId.Value);

        // set user in HttpContext.Items["User"]

        var user = await userQueryService.Handle(getUserByIdQuery);
        Console.WriteLine("Successful authorization. Updating Context...");
        context.Items["User"] = user;
        Console.WriteLine("Continuing with Middleware Pipeline");
        // call next middleware
        await next(context);
    }
}