using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using datingapp1.Application.Contracts.Persistance;
using datingapp1.Domain.Entities;
using MediatR;

namespace datingapp1.Application.Functions.Users.Commands.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, int>
    {
        public readonly IAppUserRepository _appUserRepository;

        public CreateAppUserCommandHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<int> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAppUserCommandValidator(_appUserRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if(!validatorResult.IsValid) {
                throw new DatingAppValidatorException(validatorResult);
            }


            using var hmac = new HMACSHA512();

            AppUser x = new AppUser() {
                UserName = request.UserName.ToLower(),
                KnownAs = request.KnownAs,
                //City = request.City,
                ///Country = request.Country,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key,
            };

            var x2 = await _appUserRepository.Add(x);

            return 1;
        }
    }
}