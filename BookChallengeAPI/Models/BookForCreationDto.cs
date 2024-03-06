
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class BookForCreationDto
{
    [Required]
    [MaxLength(1000)]
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Year { get; set; }
    public int Pages { get; set; }
}