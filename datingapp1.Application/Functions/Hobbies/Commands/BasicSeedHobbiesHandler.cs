using datingapp1.Application.Contracts.Persistance;
using MediatR;

namespace datingapp1.Application.Functions.Hobbies.Commands
{
  public class BasicSeedHobbiesHandler : IRequestHandler<BasicSeedHobbiesCommand, BaseResponse>
  {
    private readonly IHobbyRepository _hobbyRepository;

    public BasicSeedHobbiesHandler(IHobbyRepository hobbyRepository)
    {
      _hobbyRepository = hobbyRepository;
    }
    
    public async Task<BaseResponse> Handle(
      BasicSeedHobbiesCommand request, 
      CancellationToken cancellationToken
    ) {
      var respo = _hobbyRepository.BasicSeed();

      return new BaseResponse();
    }
  }
}