
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = String.Empty;

    [Required]
    public string Author { get; set; } = String.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; } 
    public string? Url { get; set; }
    public string? Genre { get; set; }
    public int Year { get; set; }
    public string? Language { get; set; }
    public int? Pages { get; set; }

    
}