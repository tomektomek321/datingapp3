using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Hobbies.Queries.GetHobbiesByTest;

public class GetHobbiesByTextQuery : IRequest<GetHobbiesByTextQueryResponse>
{
    public string searchText { get; set; }
}

