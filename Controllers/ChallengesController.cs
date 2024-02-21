
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/challenges")]
public class ChallengesController : ControllerBase
{
    public ChallengesController()
    {
    }

    [HttpGet]
    public async Task<ActionResult> GetChallenges()
    {
       string message = "Hello from Book Reading Challenge API!";
       
       return Ok(message);
    }
}