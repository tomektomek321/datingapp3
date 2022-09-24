using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Members.Queries.GetMembersByFilter;

public class GetMembersByFilterQueryHandler : IRequestHandler<GetMembersByFilterQuery, GetMembersByFilterQueryResponse>
{
    private readonly IAppUserRepository _appUserRepository;

    public GetMembersByFilterQueryHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public async Task<GetMembersByFilterQueryResponse> Handle(GetMembersByFilterQuery request, CancellationToken cancellationToken)
    {
        var minDob = DateTime.Today.AddYears(-request.maxAge - 1);
        var maxDob = DateTime.Today.AddYears(-request.minAge);

        int[] citiesIds = null;

        if (request.cities != "")
        {
            List<string> stringCitiesId = request.cities.Split("-").ToList();
            citiesIds = new int[stringCitiesId.Count];
            int coutner = 0;
            foreach (var item in stringCitiesId)
            {
                citiesIds[coutner++] = int.Parse(item);
            }
        }


        int[] hobbiesIds = null;

        if (request.hobbies != "")
        {
            List<string> stringhobbiesId = request.hobbies.Split("-").ToList();
            hobbiesIds = new int[stringhobbiesId.Count];
            int coutner = 0;
            foreach (var item in stringhobbiesId)
            {
                hobbiesIds[coutner++] = int.Parse(item);
            }
        }





        List<AppUser> users = await _appUserRepository.GetAppUsersByFilter(minDob, maxDob, request.gender, request.orderBy, citiesIds, hobbiesIds);

        List<MemberDto> returnDto = new List<MemberDto>();

        foreach (var x in users)
        {
            returnDto.Add(new MemberDto()
            {
                Id = x.Id,
                Username = x.UserName,
                KnownAs = x.KnownAs,
                Gender = x.Gender,
                City = x.City.Name,
                LikedUsers = x.LikedUsers
            });
        }

        return new GetMembersByFilterQueryResponse(returnDto);
    }
}

