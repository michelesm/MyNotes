namespace MyNotes.API.Models;

public class Note {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
