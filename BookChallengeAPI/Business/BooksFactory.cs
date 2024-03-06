public class BooksFactory
{
    public virtual Book CreateBook(string title, string author, string description, int year, int pages)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required");
        }

        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentException("Author is required");
        }

        //all other fields apart from Author and Title are optional
        //an external service (like Good reads API) can provide the missing data
        if (string.IsNullOrEmpty(description))
         description = "not provided";

        if (year == 0)
           year = 1900;
        
        var genre = "classic";
        

        return new Book(title, author, description, genre, year, pages);

    }
}