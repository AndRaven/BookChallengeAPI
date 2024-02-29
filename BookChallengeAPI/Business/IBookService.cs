public interface IBookService
{
    Task<Book> CreateBookAsync(string title, string author);

    Task<Book> GetBookAsync(int bookId);
}