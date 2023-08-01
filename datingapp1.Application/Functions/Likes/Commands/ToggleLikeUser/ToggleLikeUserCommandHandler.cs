using datingapp1.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Likes.Commands.ToggleLikeUser;

public class ToggleLikeUserCommandHandler : IRequestHandler<ToggleLikeUserCommand, ToggleLikeUserCommandResponse>
{
    private readonly ILikeRepository _likeRepository;

    public ToggleLikeUserCommandHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<ToggleLikeUserCommandResponse> Handle(
        ToggleLikeUserCommand request, 
        CancellationToken cancellationToken
    ) {
        bool isLiked = await _likeRepository.ToggleLike(request.SourceUserId, request.TargetUserId);

        if (isLiked) return new ToggleLikeUserCommandResponse();

        return new ToggleLikeUserCommandResponse("Something bad happend", false);
    }
}

