
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class ChallengeWithoutBooksDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public string  Description{ get; set; } = String.Empty;

}