
using System.Buffers;
using AutoMapper;
using BookChallengeAPI.Data;
using Microsoft.AspNetCore.Mvc;

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

  // public async Task<ActionResult> GetChallenge(string id)
  // {
  //        string message = "Hello from Book Reading Challenge API!";
       
  //      return Ok(message);
  // }

  // //add an HTTPPut fucntion for Challenge
  // public async Task<ActionResult> PutChallenge(string id)
  // {
  //        string message = "Hello from Book Reading Challenge API!";

  //      return Ok(message);
  // }

}