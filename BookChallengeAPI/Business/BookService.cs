
using BookChallengeAPI.Data;

public class BookService : IBookService
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly BooksFactory _booksFactory;

    public BookService(IChallengeRepository challengeRepository, BooksFactory booksFactory)
    {
        _challengeRepository = challengeRepository;
        _booksFactory = booksFactory;
    }

    public Book CreateBookAsync(string title, string author, string description, int year, int pages)
    {
        var book = _booksFactory.CreateBook(title, author, description, year, pages);

        return book; 
    }

    public async Task AddBookAsync(Book book)
    {
        await _challengeRepository.AddBookAsync(book);

        await _challengeRepository.SaveChangesAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int bookId)
    {
        return await _challengeRepository.GetBookByIdAsync(bookId);
    }

    Book IBookService.CreateBookAsync(string title, string author, string description, int year, int pages)
    {
        throw new NotImplementedException();
    }

    Task<Book> IBookService.AddBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}