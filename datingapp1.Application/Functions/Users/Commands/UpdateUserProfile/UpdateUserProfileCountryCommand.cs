using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Commands.UpdateUserProfile;

public class UpdateUserProfileCountryCommand : IRequest<BaseResponse>
{
    public int UserId { get; set; }
    public int CountryId { get; set; }
}

