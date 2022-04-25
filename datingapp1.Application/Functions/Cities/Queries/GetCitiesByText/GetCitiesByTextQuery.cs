using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Cities.Queries.GetCitiesByText
{
    public class GetCitiesByTextQuery: IRequest<List<City>>
    {
        public string searchText { get; set; }
    }
}
