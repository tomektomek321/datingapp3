using datingapp1.Application.Functions.Members.Queries.GetLikedByMembers;
using datingapp1.Application.Functions.Members.Queries.GetLikedMembers;
using datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;
using datingapp1.Application.Functions.Users.Commands.UpdateUserProfile;
using datingapp1.Application.Functions.Users.Queries.GetProfile;
using datingapp1.Application.Functions.Users.Queries.GetProfileByUsername;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.ASP_API2.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("FilterMembers")]
    public async Task<ActionResult<IEnumerable<List<MemberDto>>>> FilterMembers(GetMembersByFilterDto _filter)
    {
        var user = User.GetUsername();
        var userId = User.GetUserId();
        var query = new GetMembersByFilterQuery() {
            gender = _filter.gender,
            minAge = _filter.minAge,
            maxAge = _filter.maxAge,
            orderBy = _filter.orderBy,
            cities = _filter.cities,
            hobbies = _filter.hobbies,
            userName = user,
            userId = userId,
        };

        var users = await _mediator.Send(query);

        return Ok(users);
    }


    [HttpPost("GetLikedMembers")]
    public async Task<ActionResult<IEnumerable<List<MemberDto>>>> GetLikedMembers(GetLikedMembersQuery UserId)
    {
        var users = await _mediator.Send(UserId);

        return Ok(users);
    }


    [HttpPost("GetLikedByMembers")]
    public async Task<ActionResult<IEnumerable<List<MemberDto>>>> GetLikedByMembers(GetLikedByMembersQuery UserId)
    {
        var users = await _mediator.Send(UserId);

        return Ok(users);
    }


    [HttpPost("GetUserProfile")]
    public async Task<ActionResult<AppUserDto>> GetUserProfile(GetProfileQuery UserId)
    {
        var users = await _mediator.Send(UserId);

        return Ok(users);
    }

    [HttpPost("GetUserProfileByUsername")]
    public async Task<ActionResult<AppUserDto>> GetUserProfileByUsername(GetProfileByUsernameQuery Username)
    {
        var users = await _mediator.Send(Username);

        return Ok(users);
    }

    [HttpPost("UpdateUserProfileCity")]
    public async Task<ActionResult<int>> UpdateUserProfileCity(UpdateUserProfileCityCommand dto)
    {
        var users = await _mediator.Send(new UpdateUserProfileCityCommand() { CityId = dto.CityId, UserId = dto.UserId });

        return Ok(users);
    }

    [HttpPost("UpdateUserProfileCountry")]
    public async Task<ActionResult<int>> UpdateUserProfileCountry(UpdateUserProfileCountryCommand dto)
    {
        var users = await _mediator.Send(new UpdateUserProfileCountryCommand() { CountryId = dto.CountryId, UserId = dto.UserId });

        return Ok(users);
    }
}
