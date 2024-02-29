
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class UserDto 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string Username { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;

    public int NoOfChallenges { get; set; }

    public ICollection<ChallengeDto>? Challenges { get; set; }
}