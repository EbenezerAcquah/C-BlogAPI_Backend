namespace BlogAPI.Models;

public class Blog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Author { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}

 public class UpdateBlogRequestDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
    }
