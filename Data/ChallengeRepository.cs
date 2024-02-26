//Repository class for working with Challenges and Books    
using Microsoft.EntityFrameworkCore;

namespace BookChallengeAPI.Data
{
    public class ChallengeRepository : IChallengeRepository
    {

        private ChallengeDbContext _context;

        public ChallengeRepository(ChallengeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// return all challenhges order by ID
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Challenge>> GetChallengesAsync()
        {
            //this would work if thhe relationship between Challenges and Books was one-to-many
            //return await _context.Challenges.OrderBy(ch => ch.Id).Include(ch => ch.Books).ToListAsync();

            //use the join ChallengeBook table to get the books for each challenge
            //this uses LINQ queries
            //     var query = from challenge in _context.Challenges
            //                join challengeBook in _context.ChallengeBooks
            //                on challenge.Id equals challengeBook.ChallengeId
            //                join book in _context.Books
            //                on challengeBook.BookId equals book.Id
            //                orderby challenge.Id
            //                group new { challenge, book } by new { challenge.Id, challenge.Name } into grouped
            //                select new Challenge
            //                 {
            //                 Id = grouped.Key.Id,
            //                 Name = grouped.Key.Name,
            //                 Books = (ICollection<Book>)grouped.Select(g => g.book)
            //                 };

            //    var challengesWithBooks = query.ToList();

            var challengesWithBooks = _context.Challenges
                .Join(_context.ChallengeBooks, challenge => challenge.Id, chBook => chBook.ChallengeId, (challenge, chBook) => new { Challenge = challenge, ChallengeBook = chBook })
                .Join(_context.Books, combined => combined.ChallengeBook.BookId, book => book.Id, (combined, book) => new { Challenge = combined.Challenge, Book = book })
                .GroupBy(combined => new { combined.Challenge.Id, combined.Challenge.Name })
                .Select(grouped => new Challenge
                {
                    Id = grouped.Key.Id,
                    Name = grouped.Key.Name,
                    Books = grouped.Select(combined => combined.Book).Where(book => book != null) as ICollection<Book>
                }).ToList();

            return await Task.FromResult(challengesWithBooks);
        }

        public async Task<Challenge?> GetChallengeByIdAsync(int challengeId)
        {
            return await _context.Challenges.Where(ch => ch.Id == challengeId).FirstOrDefaultAsync();
        }
    }
}


