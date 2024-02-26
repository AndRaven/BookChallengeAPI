
using AutoMapper;

public class ChallengeProfile : Profile
{
    public ChallengeProfile()
    {
          CreateMap<Challenge, ChallengeDto>();
          CreateMap<ChallengeWithoutBooksDto, Challenge>();
          CreateMap<ChallengeDto, Challenge>();
          CreateMap<Challenge, ChallengeWithoutBooksDto>();
    }

  
}