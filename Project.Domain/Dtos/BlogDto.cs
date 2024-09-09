using Project.Domain.Interfaces;

namespace Project.Domain.Dtos;
public class BlogDto : Entity
{
    public string BlogImageUrl { get; set; } = string.Empty;
    public required string Title { get; set; }
    public required string Content { get; set; }
    public bool CommentsEnabled { get; set; }
    public bool IsPublished { get; set; }
}