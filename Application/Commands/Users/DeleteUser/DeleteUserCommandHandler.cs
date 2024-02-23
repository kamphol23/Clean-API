using Domain.Models.UserModel;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.DeleteUser
{
  public class DeleteUserCommandhandler : IRequestHandler<DeleteUserCommand, UserModle>
    {
        private readonly MockDatabase _database;

        public DeleteUserCommandhandler(MockDatabase database)
        { 
            _database = database;
        }

        public Task<UserModle>Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            UserModle userToBeDeleted = _database.listOfAllUsers.FirstOrDefault(use => use.UserId == request.Id);

            if (userToBeDeleted == null)
            {
                throw new ArgumentException("Invalid user Id");
            }else
            {
                return Task.FromResult(userToBeDeleted);
            }

        }
    }
}
