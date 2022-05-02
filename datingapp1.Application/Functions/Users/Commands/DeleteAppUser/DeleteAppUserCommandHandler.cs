using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using MediatR;

namespace datingapp1.Application.Functions.Users.Commands.DeleteAppUser;

public class DeleteAppUserCommandHandler: IRequestHandler<DeleteAppUserCommand>
{
    private readonly IAppUserRepository _appUserRepository;

    public DeleteAppUserCommandHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public async Task<Unit> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _appUserRepository.GetById(request.AppUserId);

        await _appUserRepository.Delete(userToDelete);

        return Unit.Value;
    }
}
