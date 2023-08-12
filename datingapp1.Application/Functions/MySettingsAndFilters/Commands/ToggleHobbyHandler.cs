using datingapp1.Application.Contracts.Persistance;
using MediatR;

namespace datingapp1.Application.Functions.MySettingsAndFilters.Commands;
public class ToggleHobbyHandler : IRequestHandler<ToggleHobbyCommand, BaseResponse>
{
  private readonly IUserHobbyRepository _userHobbyRepository;

  public ToggleHobbyHandler(IUserHobbyRepository userHobbyRepository)
  {
    _userHobbyRepository = userHobbyRepository;
  }

  public async Task<BaseResponse> Handle(
    ToggleHobbyCommand request,
    CancellationToken cancellationToken
  ) {

    var resp = await _userHobbyRepository.ToggleHobby(request.UserId, request.HobbyId);

    return new BaseResponse();
  }
}
