

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = String.Empty;

    [Required]
    public string LastName { get; set; } = String.Empty;

    [Required]
    public string Email { get; set; } = String.Empty;

    public string Username { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;

    public int NoOfChallenges { get; set; }

    public ICollection<ChallengeDto>? Challenges { get; set; }
}