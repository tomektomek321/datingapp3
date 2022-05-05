﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1.Application.Functions.UserHobbies.Commands.RemoveUserHobby;

public class RemoveUserHobbyCommand : IRequest
{
    public int UserId { get; set; }
    public int HobbyId { get; set; }
}

