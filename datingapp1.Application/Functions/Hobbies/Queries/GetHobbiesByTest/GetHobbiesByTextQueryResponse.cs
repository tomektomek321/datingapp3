using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Hobbies.Queries.GetHobbiesByTest;

public class GetHobbiesByTextQueryResponse: BaseResponse
{
    public List<Hobby> Data { get; set; }

    public GetHobbiesByTextQueryResponse(List<Hobby> hobbies_): base()
    {
        Data = hobbies_;
    }
}

