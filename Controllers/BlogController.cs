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

[HttpPut("{id}")]
public IActionResult UpdateBlog(Guid id, UpdateBlogRequestDTO request)
{
    var blog = _blogList.FirstOrDefault(b => b.Id == id);
    if (blog == null)
    {
        return NotFound();
    }

    blog.Title = request.Title ?? blog.Title;
    blog.Content = request.Content ?? blog.Content;
    blog.Author = request.Author ?? blog.Author;

    return Ok(blog);
}

[HttpDelete("{id}")]
public IActionResult DeleteBlogById(Guid id)
{
    var blog = _blogList.FirstOrDefault(b => b.Id == id);
    if (blog == null)
    {
        return NotFound();
    }

    _blogList.Remove(blog);
    return Ok(new { message = "Blog deleted successfully." });
}

[HttpDelete]
public IActionResult DeleteAllBlogs()
{
    _blogList.Clear();
    return Ok(new { message = "All blogs deleted successfully." });
}
}