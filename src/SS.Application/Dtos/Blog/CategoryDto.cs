namespace SS.Application.Dtos.Blog;

public class CategoryDto : IComparable<CategoryDto>
{
    public int CategoryId { get; set; }
    public bool IsSelected { get; set; }
    public string Category { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public int ArticleCount { get; set; }
    public DateTime DateCreated { get; set; }

    public int CompareTo(CategoryDto? other)
    {
        return string.Compare(Category.ToLower(), other.Category.ToLower(), StringComparison.Ordinal);
    }
}