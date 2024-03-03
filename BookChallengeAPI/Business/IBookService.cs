public interface IBookService
{
    Book CreateBookAsync(string title, string author, string description, int year, int pages);

    Task<Book> AddBookAsync(Book book);

    Task<Book?> GetBookByIdAsync(int bookId);
}