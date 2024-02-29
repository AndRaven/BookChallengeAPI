

using AutoMapper;
using BookChallengeAPI.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/challenges/{challengeId}/books")]

public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;

    private readonly IChallengeRepository _repository;

    private readonly IMapper _mapper;
    public BooksController(IChallengeRepository repository, ILogger<BooksController> logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult> GetBooks(int challengeId)
    {
         if (! await _repository.CheckChallengeExistsAsync(challengeId))
         {
          _logger.LogInformation($"Challenge with id {challengeId} not found");
           return NotFound();
         }

         var challengeBooks = await _repository.GetBooksForChallengeAsync(challengeId);
        
        return Ok(_mapper.Map<IEnumerable<BookDto>>(challengeBooks));
    }
    

}