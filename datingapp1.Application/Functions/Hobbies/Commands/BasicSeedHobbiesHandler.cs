using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto.Hobbies;
using MediatR;

namespace datingapp1.Application.Functions.Hobbies.Commands;
public class BasicSeedHobbiesHandler : IRequestHandler<BasicSeedHobbiesCommand, BaseResponse>
{
  private readonly IHobbyRepository _hobbyRepository;
  private readonly IHobbiesCategoryRepository _hobbiesCategoryRepository;

  public BasicSeedHobbiesHandler(
    IHobbyRepository hobbyRepository,
    IHobbiesCategoryRepository hobbiesCategoryRepository
  ) {
    _hobbyRepository = hobbyRepository;
    _hobbiesCategoryRepository = hobbiesCategoryRepository;
  }
  
  public async Task<BaseResponse> Handle(
    BasicSeedHobbiesCommand request,
    CancellationToken cancellationToken
  ) {
    return new BaseResponse();
  }
}
