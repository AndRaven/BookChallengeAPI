
using System.Buffers;
using AutoMapper;
using BookChallengeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

[ApiController]
[Route("api/challenges")]
public class ChallengesController : ControllerBase
{

  private readonly ILogger<ChallengesController> _logger;
  private readonly IChallengeRepository _repository;

  private readonly IMapper _mapper;
    public ChallengesController(IChallengeRepository repository, IMapper mapper, ILogger<ChallengesController> logger)
    {

      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }

    [HttpGet]
    public async Task<ActionResult> GetChallenges()
    {
       var challengeEntities = await _repository.GetChallengesAsync();
       
       return Ok(_mapper.Map<IEnumerable<ChallengeDto>>(challengeEntities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetChallenge(string id)
    {
         if (! await _repository.CheckChallengeExistsAsync(int.Parse(id)))
         {
          _logger.LogInformation($"Challenge with id {id} not found");
           return NotFound();
         }

         var challenge = await _repository.GetChallengeByIdAsync(int.Parse(id));
        
        return Ok(_mapper.Map<ChallengeWithoutBooksDto>(challenge));
    }

  // //add an HTTPPut fucntion for Challenge
  // public async Task<ActionResult> PutChallenge(string id)
  // {
  //        string message = "Hello from Book Reading Challenge API!";

  //      return Ok(message);
  // }

}