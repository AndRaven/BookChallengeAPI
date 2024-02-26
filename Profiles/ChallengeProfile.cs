
using AutoMapper;

public class ChallengeProfile : Profile
{
    public ChallengeProfile()
    {
          CreateMap<Challenge, ChallengeDto>();
    }

  
}