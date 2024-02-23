using Domain.Models.UserModel;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModle>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateUserCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<UserModle> Handle(UpdateUserCommand request, CancellationToken cancellationToken) 
        {
            UserModle userToBeUpdate = _mockDatabase.listOfAllUsers.FirstOrDefault(User => User.UserId == request.UserId);    
            
            if (userToBeUpdate.UserId != request.UserId)
            {
                throw new Exception("Invalid user ID");
            }

            userToBeUpdate.UserName = request.UpdatedUser.UserName;
            userToBeUpdate.Password = BCrypt.Net.BCrypt.HashPassword(request.UpdatedUser.Password);

            return Task.FromResult(userToBeUpdate); 
        }
    }
}
