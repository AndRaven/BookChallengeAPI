namespace BookChallengeAPI.Data
{
    public interface IChallengeRepository
    {

        Task<IEnumerable<Challenge>> GetChallengesAsync();

        Task<bool> CheckChallengeExistsAsync(int challengeId);

        Task<Challenge?> GetChallengeByIdAsync(int challengeId);
    }
}