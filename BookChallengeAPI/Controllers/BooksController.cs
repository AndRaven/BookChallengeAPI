

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

    [HttpGet("{bookId}", Name="GetBook")]
    public async Task<ActionResult> GetBook(int bookId)
    {
        if (! await _bookService.CheckIfBookExistsAsync(bookId))
         {
          _logger.LogInformation($"Book with id {bookId} not found");
           return NotFound();
         }

         var book = await _bookService.GetBookByIdAsync(bookId);

         return Ok(_mapper.Map<BookDto>(book));
    }


    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook(int challengeId, 
    [FromBody] BookForCreationDto bookForCreationDto)
    {
        if (! await _challengeService.ChallengeExistsAsync(challengeId))
         {
          _logger.LogInformation($"Challenge with id {challengeId} not found");
           return NotFound();
         }

         //validate bookForCreationDto

         //create a book
        
        var bookCreated = _bookService.CreateBookAsync(bookForCreationDto.Title,
                          bookForCreationDto.Author,
                          bookForCreationDto.Description,
                          bookForCreationDto.Year,
                          bookForCreationDto.Pages);

        await _bookService.AddBookAsync(bookCreated);

        await _challengeService.AddBookToChallengeAsync(challengeId, bookCreated);

        var bookToReturn = _mapper.Map<BookDto>(bookCreated);

        return CreatedAtRoute("GetBook",
        new 
        {
           challengeId = challengeId,
           bookId = bookToReturn.Id
        },
        bookToReturn);

    }
    

}