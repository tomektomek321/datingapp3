using datingapp1.Domain.Dto;
using datingapp1.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Auth.Queries.Login;

public class LoginQuery : IRequest<LoginQueryResponse<LoginDto>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

