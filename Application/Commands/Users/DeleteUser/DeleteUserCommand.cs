using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.DeleteUser
{
   public class DeleteUserCommand : IRequest<UserModle>
    {
        public Guid Id { get; set; }    
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
