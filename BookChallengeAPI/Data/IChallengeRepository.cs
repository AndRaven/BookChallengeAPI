namespace BookChallengeAPI.Data
{
    public interface IChallengeRepository
    {

        Task<IEnumerable<Challenge>> GetChallengesAsync();

        Task<bool> CheckChallengeExistsAsync(int challengeId);

        Task<Challenge?> GetChallengeByIdAsync(int challengeId);

        Task<IEnumerable<Book>> GetBooksForChallengeAsync(int challengeId);

        Task<Book?> GetBookByIdAsync(int bookId);

        Task SaveChangesAsync();

        Task AddBookAsync(Book book);

        Task AddBookToChallengeAsync(int challengeId, Book book);

        Task RemoveBookFromChallengeAsync(int challengeId, Book book);
    }
}