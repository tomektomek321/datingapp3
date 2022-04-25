using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Cities;

public class GetCityByIdQuery: IRequest<List<City>>
{

}
