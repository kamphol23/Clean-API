using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
public class UpdateUserCommand : IRequest<UserModle>
    {
        public UpdateUserCommand(UserDto updatedUser, Guid id) 
        {
            UpdatedUser = updatedUser;
            UserId = id;
        }

        public UserDto UpdatedUser { get; set; }
        public Guid UserId { get; set;}
    }
}
