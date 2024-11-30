namespace Domain.Entities;

public class Report(string title, string content)
{
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
}