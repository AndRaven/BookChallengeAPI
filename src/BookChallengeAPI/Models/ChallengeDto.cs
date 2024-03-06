
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class ChallengeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public string  Description{ get; set; } = String.Empty;

    public int NoOfBooks { get; set; }

    public int NoOfUsers { get; set; }

    public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
}