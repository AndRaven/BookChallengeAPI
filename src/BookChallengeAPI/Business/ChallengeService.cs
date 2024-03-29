
using BookChallengeAPI.Data;

public class ChallengeService : IChallengeService
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly IBookService _bookService;

    public ChallengeService(IChallengeRepository challengeRepository, IBookService bookService)
    {
        _challengeRepository = challengeRepository;
        _bookService = bookService;
    }


    public async Task<Challenge?> GetChallengeByIdAsync(int challengeId)
    {
       var challengeById = await _challengeRepository.GetChallengeByIdAsync(challengeId);

       return challengeById;
    }

    public async Task<IEnumerable<Challenge>> GetChallengesAsync()
    {
        var challenges = await _challengeRepository.GetChallengesAsync();

        return challenges;
    }

    public async Task<IEnumerable<Book>> GetBooksForChallengeAsync(int challengeId)
    {
        var booksInChallenge = await _challengeRepository.GetBooksForChallengeAsync(challengeId);

        return booksInChallenge;
    }

    public async Task AddBookToChallengeAsync(int challengeId, Book book)
    {
        //check book does not already belong to the challeng
        var booksInChallenge = await GetBooksForChallengeAsync(challengeId);

        if (!booksInChallenge.Contains(book))
        {
            //add book to the challenge
            _challengeRepository.AddBookToChallengeAsync(challengeId, book);
            
            await _challengeRepository.SaveChangesAsync();
        }
    }


    public async Task RemoveBookFromChallengeAsync(int challengeId, Book book)
    {
        var booksInChallenge = await GetBooksForChallengeAsync(challengeId);

        if (booksInChallenge.Contains(book))
        {
             _challengeRepository.RemoveBookFromChallengeAsync(challengeId, book);
             await _challengeRepository.SaveChangesAsync();
        }
    }

    public Task<Challenge> CreateChallengeAsync(Challenge challenge)
    {
        throw new NotImplementedException();
    }

    public Task<Challenge> UpdateChallengeAsync(Challenge challenge)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ChallengeExistsAsync(int challengeId)
    {
        return await _challengeRepository.CheckChallengeExistsAsync(challengeId);
    }
}