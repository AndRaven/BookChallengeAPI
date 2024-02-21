using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserBook 
{ 

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("BookId")]
    public int BookId { get; set; }
    public Book? Book { get; set; } 

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User? User { get; set; }

}