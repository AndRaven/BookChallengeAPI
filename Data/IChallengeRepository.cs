namespace BookChallengeAPI.Data
{
    public interface IChallengeRepository
    {

        Task<IEnumerable<Challenge>> GetChallengesAsync();

        Task<bool> CheckChallengeExistsAsync(int challengeId);

        Task<Challenge?> GetChallengeByIdAsync(int challengeId);

        Task<IEnumerable<Book>> GetBooksForChallengeAsync(int challengeId);

        Task<Book?> GetBookByIdAsync(int challengeId, int bookId);
    }
}