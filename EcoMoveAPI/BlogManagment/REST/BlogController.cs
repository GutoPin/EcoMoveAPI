using System.Net.Mime;
using EcoMoveAPI.BlogManagment.Domain.Model.Queries;
using EcoMoveAPI.BlogManagment.Domain.Services;
using EcoMoveAPI.BlogManagment.REST.Resources;
using EcoMoveAPI.BlogManagment.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.BlogManagment.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BlogController(
    IBlogCommandService blogCommandService,
    IBlogQueryService blogQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a blog",
        Description = "Creates a blog with a given user id, title, and content",
        OperationId = "CreateBlog")]
    [SwaggerResponse(201, "The blog was created", typeof(BlogResource))]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogResource createBlogResource)
    {
        var createBlogCommand = CreateBlogCommandFromResourceAssembler.ToCommandFromResource(createBlogResource);
        var blog = await blogCommandService.Handle(createBlogCommand);
        if (blog is null) return BadRequest();
        var blogResource = BlogResourceFromEntityAssembler.ToResourceFromEntity(blog);
        return CreatedAtAction(nameof(GetBlogByBlogIdQuery), new { id = blog.BlogId }, blogResource);
    }
    
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all blogs",
        Description = "Gets all blogs",
        OperationId = "GetAllBlogs")]
    [SwaggerResponse(200, "The blogs were found", typeof(BlogResource))]
    public async Task<IActionResult> GetAllBlogs()
    {
        var getAllBlogsQuery = new GetAllBlogsQuery();
        var blogs = await blogQueryService.Handle(getAllBlogsQuery);
        var blogResources = blogs.Select(BlogResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(blogResources);
    }
    
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a blog by id",
        Description = "Gets a blog for a given identifier",
        OperationId = "GetBlogByBlogId")]
    [SwaggerResponse(200, "The blog was found", typeof(BlogResource))]
    public async Task<IActionResult> GetBlogByBlogIdQuery(int id)
    {
        var getBlogByBlogIdQuery = new GetBlogByBlogIdQuery(id);
        var blog = await blogQueryService.Handle(getBlogByBlogIdQuery);
        if (blog == null) return NotFound();
        var blogResource = BlogResourceFromEntityAssembler.ToResourceFromEntity(blog);
        return Ok(blogResource);
    }
    
    [HttpGet("user-id/{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets all blogs by user id",
        Description = "Gets all blogs for a given user identifier",
        OperationId = "GetAllBlogsByUserId")]
    [SwaggerResponse(200, "The blogs were found", typeof(BlogResource))]
    public async Task<IActionResult> GetAllBlogsByUserId(int userId)
    {
        var getAllBlogsByUserIdQuery = new GetAllBlogsByUserIdQuery(userId);
        var blogs = await blogQueryService.Handle(getAllBlogsByUserIdQuery);
        var blogResources = blogs.Select(BlogResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(blogResources);
    }

}