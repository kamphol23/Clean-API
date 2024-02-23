using Domain.Models;
using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommand : IRequest<UserModle>
    {
        public UserDto newUser { get; set; }
        public RegisterUserCommand(UserDto newUser)
        {
            this.newUser = newUser;
        }
    }
}
