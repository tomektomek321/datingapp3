using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Hobbies.Queries.GetHobbiesByTest;

public class GetHobbiesByTextQueryHandler : IRequestHandler<GetHobbiesByTextQuery, GetHobbiesByTextQueryResponse>
{
    private readonly IHobbyRepository _hobbyRepository;

    public GetHobbiesByTextQueryHandler(IHobbyRepository hobbyRepository)
    {
        _hobbyRepository = hobbyRepository;
    }

    public Task<GetHobbiesByTextQueryResponse> Handle(GetHobbiesByTextQuery request, CancellationToken cancellationToken)
    {
        List<Hobby> hobbies = _hobbyRepository.GetHobbiesByText(request.searchText);
        return Task.FromResult(new GetHobbiesByTextQueryResponse(hobbies));
    }
}

