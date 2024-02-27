
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

public class ChallengeDbContext : DbContext
{

  public DbSet<Challenge> Challenges { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;

  public DbSet<Book> Books { get; set; } = null!;

  public DbSet<ChallengeBook> ChallengeBooks { get; set; } = null!;

  public ChallengeDbContext(DbContextOptions options) : base(options)
  {
  }

  //seeding the database with some data

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {


    modelBuilder.Entity<Challenge>().HasData(
      new Challenge { Id = 1, Name = "summer reading", Description = "Read books set in summer", NoOfBooks = 5, NoOfUsers = 0 },
      new Challenge { Id = 2, Name = "autumn reading", Description = "Read books set in autumn", NoOfBooks = 5, NoOfUsers = 0 }
    );

    modelBuilder.Entity<Book>().HasData(
      new Book
      {
        Id = 1,
        Title = "The Great Gatsby",
        Author = "F. Scott Fitzgerald",
        Description = "Set in the summer of 1922 on Long Island and in New York City, this classic novel captures the essence of the Jazz Age with its lavish parties, love affairs, and societal commentary.",
        Url = "https://www.goodreads.com/book/show/4671.The_Great_Gatsby",
        Genre = "Classic",
        Year = 1925,
        Language = "English",
        Pages = 180
      },

      new Book
      {
        Id = 2,
        Title = "The Secret Life of Bees",
        Author = "Sue Monk Kidd",
        Description = "Set in South Carolina during the summer of 1964, this novel follows a young girl named Lily Owens as she embarks on a journey to uncover the truth about her mother's past and finds solace and healing in the company of beekeeping sisters.",
        Url = "https://www.goodreads.com/book/show/37435.The_Secret_Life_of_Bees",
        Genre = "Fiction",
        Year = 2001,
        Language = "English",
        Pages = 302
      },

      new Book
      {
        Id = 3,
        Title = "The Vacationers",
        Author = "Emma Straub",
        Description = "This novel takes place during a two-week family vacation in Mallorca, Spain, where secrets and tensions bubble to the surface as the Post family navigates love, betrayal, and redemption.",
        Url = "https://www.goodreads.com/book/show/18641982-the-vacationers",
        Genre = "Fiction",
        Year = 2014,
        Language = "English",
        Pages = 292
      },

      new Book
      {
        Id = 4,
        Title = "The Night Circus",
        Author = "Erin Morgenstern",
        Description = "This enchanting novel follows the mysterious Le Cirque des Rêves, a circus that arrives without warning and is only open at night. The story unfolds over many years, capturing the magic and romance of autumn.",
        Url = "https://www.goodreads.com/book/show/9361589-the-night-circus",
        Genre = "Fiction",
        Year = 2011,
        Language = "English",
        Pages = 506
      },

      new Book
      {
        Id = 5,
        Title = "The Secret History",
        Author = "Donna Tartt",
        Description = "This atmospheric novel is set in a New England college town during the fall semester. It follows a group of eccentric classics students who become entangled in a dark and sinister secret.",
        Url = "https://www.goodreads.com/book/show/29044.The_Secret_History",
        Genre = "Classic",
        Year = 1992,
        Language = "English",
        Pages = 559
      });

    modelBuilder.Entity<ChallengeBook>().HasKey(cb => new { cb.BookId, cb.ChallengeId });

    modelBuilder.Entity<ChallengeBook>().HasData(
       new ChallengeBook {  BookId = 1, ChallengeId = 1 },
       new ChallengeBook {  BookId = 2, ChallengeId = 1 },
       new ChallengeBook {  BookId = 3, ChallengeId = 1 },
       new ChallengeBook {  BookId = 4, ChallengeId = 2 },
       new ChallengeBook {  BookId = 5, ChallengeId = 2 });


  }



}