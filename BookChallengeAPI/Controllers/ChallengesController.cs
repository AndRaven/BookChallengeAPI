
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
  private readonly IChallengeService _challengeService;

  private readonly IMapper _mapper;
    public ChallengesController(IChallengeService challengeService, IMapper mapper, ILogger<ChallengesController> logger)
    {
      _challengeService = challengeService ?? throw new ArgumentNullException(nameof(challengeService));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    } 

    [HttpGet]
    public async Task<ActionResult> GetChallenges()
    {
       var challengeEntities = await _challengeService.GetChallengesAsync();
       
       return Ok(_mapper.Map<IEnumerable<ChallengeDto>>(challengeEntities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetChallenge(int id)
    {
         if (! await _challengeService.ChallengeExistsAsync(id))
         {
          _logger.LogInformation($"Challenge with id {id} not found");
           return NotFound();
         }

         var challenge = await _challengeService.GetChallengeByIdAsync(id);
        
        return Ok(_mapper.Map<ChallengeWithoutBooksDto>(challenge));
    }


  // //add an HTTPPut fucntion for Challenge
  // public async Task<ActionResult> PutChallenge(string id)
  // {
  //        string message = "Hello from Book Reading Challenge API!";

  //      return Ok(message);
  // }

}