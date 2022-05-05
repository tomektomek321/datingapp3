using datingapp1.Application.Contracts.Persistance;
using datingapp1.Application.Functions.UserHobbies.Commands.AddUserHobby;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.UserHobbies.Commands.RemoveUserHobby;

public class RemoveUserHobbyCommandHandler : IRequestHandler<RemoveUserHobbyCommand>
{
    private readonly IUserHobbyRepository _UserHobbyRepository;

    public RemoveUserHobbyCommandHandler(IUserHobbyRepository UserHobbyRepository)
    {
        _UserHobbyRepository = UserHobbyRepository;
    }

    public async Task<Unit> Handle(RemoveUserHobbyCommand request, CancellationToken cancellationToken)
    {
        UserHobby hobby = _UserHobbyRepository.GetUserHobbyByUserIdAndHobbyId(request.UserId, request.HobbyId);

        await _UserHobbyRepository.Delete(hobby);

        return Unit.Value;
    }
}

