public class BooksFactory
{
    public virtual Book CreateBook(string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required");
        }

        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentException("Author is required");
        }

        return new Book(title, author);

    }
}