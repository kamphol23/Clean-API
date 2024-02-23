using Application.Dtos;
using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserLogin
{
   public class LogInQuerys : IRequest<User>
    {   
        public UserDto UserLogIn { get; set; }
        public LogInQuerys(UserDto UserLogIn) {

        this.UserLogIn = UserLogIn;
        }
    }
}
