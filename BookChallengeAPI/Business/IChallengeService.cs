public interface IChallengeService
{
    Task<bool> ChallengeExistsAsync(int challengeId);
    
    Task<Challenge?> GetChallengeByIdAsync(int challengeId);

    Task<IEnumerable<Book>> GetBooksForChallengeAsync(int challengeId);

    Task<IEnumerable<Challenge>> GetChallengesAsync();

    Task AddBookToChallengeAsync(int challengeId, Book book);

    Task RemoveBookFromChallengeAsync(int challengeId, Book book);

    Task<Challenge> CreateChallengeAsync(Challenge challenge);
    Task<Challenge> UpdateChallengeAsync(Challenge challenge);

}