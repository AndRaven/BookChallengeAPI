public interface IBookService
{
    Book CreateBookAsync(string title, string author, string description, int year, int pages);

    Task AddBookAsync(Book book);

    Task<bool> CheckIfBookExistsAsync(int bookId);

    Task<Book?> GetBookByIdAsync(int bookId);
}