namespace BookChallengeAPI.Data
{
    public interface IChallengeRepository
    {

        Task<IEnumerable<Challenge>> GetChallengesAsync();

        Task<Challenge?> GetChallengeByIdAsync(int challengeId);
    }
}