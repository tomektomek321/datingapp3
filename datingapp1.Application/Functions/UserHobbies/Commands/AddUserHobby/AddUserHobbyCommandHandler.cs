using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.UserHobbies.Commands.AddUserHobby;

public class AddUserHobbyCommandHandler : IRequestHandler<AddUserHobbyCommand, BaseResponse>
{
    private readonly IUserHobbyRepository _UserHobbyRepository;

    public AddUserHobbyCommandHandler(IUserHobbyRepository UserHobbyRepository)
    {
        _UserHobbyRepository = UserHobbyRepository;
    }


    public async Task<BaseResponse> Handle(AddUserHobbyCommand request, CancellationToken cancellationToken)
    {
        var alreadyAdded = _UserHobbyRepository.GetUserHobbyByUserIdAndHobbyId(request.UserId, request.HobbyId);

        if (alreadyAdded != null)
        {
            Console.WriteLine("added");
            return new BaseResponse("Already Added", false);
        }


        await _UserHobbyRepository.Add(new UserHobby() { AppUserId = request.UserId, HobbyId = request.HobbyId });
        return new BaseResponse();
    }
}

