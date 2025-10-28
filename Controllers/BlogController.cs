using BlogAPI.Models;
using BlogAPI.Models.DTOs;
using BlogAPI.Persistence.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogRepository _blogRepository;
    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    [HttpPost]
    public IActionResult CreateBlog(CreateBlogRequestDTO request)
    {
        var blog = new Blog
        {
            Author = request.Author,
            Title = request.Title,
            Content = request.Content,
        };

        _blogRepository.Add(blog);
        return Ok(blog);
    }
    [HttpGet]
    public IActionResult GetAllBlogs()
    {
        return Ok(_blogRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetBlogById(Guid id)
    {
        var blog = _blogRepository.GetById(id);
        if (blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

[HttpPut("{id}")]
public IActionResult UpdateBlog(Guid id, UpdateBlogRequestDTO request)
{
    var blog = new Blog
    {
        Author = request.Author,
        Title = request.Title,
        Content = request.Content,
    };

    var updatedBlog = _blogRepository.Update(id, blog);
    if (updatedBlog == null)
    {
        return NotFound();
    }

    return Ok(updatedBlog);
}

[HttpDelete("{id}")]
public IActionResult DeleteBlogById(Guid id)
{
    var blog = _blogRepository.DeleteById(id);
    if (blog == null)
    {
        return NotFound();
    }

    return Ok(new { message = "Blog deleted successfully." });
}
}