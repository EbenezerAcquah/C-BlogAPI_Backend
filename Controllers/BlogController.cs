using BlogAPI.Models;
using BlogAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private static readonly List<Blog> _blogList = new List<Blog>();
    [HttpPost]
    public IActionResult CreateBlog(CreateBlogRequestDTO request)
    {
        var blog = new Blog
        {
            Author = request.Author,
            Title = request.Title,
            Content = request.Content,
        };

        _blogList.Add(blog);
        return Ok(blog);
    }
    [HttpGet]
    public IActionResult GetAllBlogs()
    {
        return Ok(_blogList);
    }

    [HttpGet("{id}")]
   public IActionResult GetBlogById(Guid id)
    {
        var blog = _blogList.FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

} 