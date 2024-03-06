namespace BookChallengeAPI.Data
{
    public interface IChallengeRepository
    {

        Task<IEnumerable<Challenge>> GetChallengesAsync();

        Task<bool> CheckChallengeExistsAsync(int challengeId);

        Task<Challenge?> GetChallengeByIdAsync(int challengeId);

        Task<IEnumerable<Book>> GetBooksForChallengeAsync(int challengeId);

        Task<bool> CheckBookExistsAsync(int bookId);

        Task<Book?> GetBookByIdAsync(int bookId);

        Task SaveChangesAsync();

        void AddBookAsync(Book book);

        void AddBookToChallengeAsync(int challengeId, Book book);

        void RemoveBookFromChallengeAsync(int challengeId, Book book);
    }
}