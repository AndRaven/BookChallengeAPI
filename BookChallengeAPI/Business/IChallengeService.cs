public interface IChallengeService
{
    Task<Challenge> GetChallengeAsync(string challengeId);

    Task<IEnumerable<Book>> GetBooksForChallengeAsync(string challengeId);

    Task<IEnumerable<Challenge>> GetChallengesAsync();

    Task AddBookToChallengeAsync(string challengeId, Book book);

    Task RemoveBookFromChallengeAsync(string challengeId, Book book);

    Task<Challenge> CreateChallengeAsync(Challenge challenge);
    Task<Challenge> UpdateChallengeAsync(Challenge challenge);

}