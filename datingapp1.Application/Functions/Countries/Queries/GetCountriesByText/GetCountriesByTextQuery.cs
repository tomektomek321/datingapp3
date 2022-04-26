using MediatR;
using datingapp1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Countries.Queries.GetCountriesByText;

public class GetCountriesByTextQuery: IRequest<List<Country>>
{
    public string searchText { get; set; }
}

