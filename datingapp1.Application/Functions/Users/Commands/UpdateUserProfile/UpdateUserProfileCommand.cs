﻿using datingapp1.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.Users.Commands.UpdateUserProfile;
public class UpdateUserProfileCommand : IRequest
{
    public AppUserDto AppUserDto;
}

