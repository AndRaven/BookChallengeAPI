
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookChallenge
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("BookId")]
    public int BookId { get; set; }
    public Book? Book { get; set; } 

    [ForeignKey("ChallengeId")]
    public int ChallengeId { get; set; }
    public Challenge? Challenge { get; set; }
}