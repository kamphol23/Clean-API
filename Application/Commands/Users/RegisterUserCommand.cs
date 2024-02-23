﻿using Domain.Models;
using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.RegisterNewUser
{
    public class RegisterUserCommand : IRequest<User> 
    {
        public UserDto newUser {  get; set; }
        public RegisterUserCommand(UserDto newUser)
        {
            this.newUser = newUser;
        }   
    }
}