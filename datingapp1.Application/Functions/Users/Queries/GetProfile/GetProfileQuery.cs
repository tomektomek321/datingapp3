using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Queries.GetProfile;

public class GetProfileQuery : IRequest<TBaseResponse<AppUserDto>>
{
    public int UserId { get; set; }
}

