using Domain.Models.UserModel;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.RegisterNewUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly MockDatabase _mockDatabase;

        public RegisterUserCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public  Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.newUser == null || string.IsNullOrEmpty(request.newUser.UserName) || string.IsNullOrEmpty(request.newUser.Password))
            {
                throw new ArgumentException("Animal type or name are not given");
            }

            try
            {
                User NewUser = new User
                {
                    UserName = request.newUser.UserName,
                    UserId = Guid.NewGuid(),
                    Password = BCrypt.Net.BCrypt.HashPassword(request.newUser.Password)
                };

                return Task.FromResult(NewUser);
            } catch (Exception ex)
            {
                throw new ArgumentException("Registration failed");
            }
        }
    }
}
