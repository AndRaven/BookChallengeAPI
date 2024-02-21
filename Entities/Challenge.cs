
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Challenge
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; } = String.Empty;
    
    [MaxLength(1000)]
    public string  Description{ get; set; } = String.Empty;

    public int NoOfBooks { get; set; }

    public int NoOfUsers { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}