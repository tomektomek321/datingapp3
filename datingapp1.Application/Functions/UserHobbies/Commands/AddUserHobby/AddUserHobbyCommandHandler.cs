using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.UserHobbies.Commands.AddUserHobby;

public class AddUserHobbyCommandHandler : IRequestHandler<AddUserHobbyCommand>
{
    private readonly IUserHobbyRepository _UserHobbyRepository;

    public AddUserHobbyCommandHandler(IUserHobbyRepository UserHobbyRepository)
    {
        _UserHobbyRepository = UserHobbyRepository;
    }


    public async Task<Unit> Handle(AddUserHobbyCommand request, CancellationToken cancellationToken)
    {
        var x = await _UserHobbyRepository.Add(new UserHobby() { AppUserId = request.UserId, HobbyId = request.HobbyId });
        return Unit.Value;
    }
}

