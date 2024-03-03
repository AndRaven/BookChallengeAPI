

using AutoMapper;
using BookChallengeAPI.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/challenges/{challengeId}/books")]

public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;

    private readonly IBookService _bookService;

    private readonly IChallengeService _challengeService;

    private readonly IMapper _mapper;
    public BooksController(IChallengeService challengeService, IBookService bookService, ILogger<BooksController> logger, IMapper mapper)
    {
        _challengeService = challengeService ?? throw new ArgumentNullException(nameof(challengeService));
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult> GetBooks(int challengeId)
    {
         if (! await _challengeService.ChallengeExistsAsync(challengeId))
         {
          _logger.LogInformation($"Challenge with id {challengeId} not found");
           return NotFound();
         }

         var challengeBooks = await _challengeService.GetBooksForChallengeAsync(challengeId);
        
        return Ok(_mapper.Map<IEnumerable<BookDto>>(challengeBooks));
    }
    

}