using Domain.Models.UserModel;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserLogin
{
    public class LogInQueryHandler : IRequestHandler<LogInQuerys, UserModle>
    {
        private readonly MockDatabase _mockDatabase;

        public LogInQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<UserModle> Handle(LogInQuerys request, CancellationToken cancellation)
        {
            var  wantedUser =  _mockDatabase.listOfAllUsers.FirstOrDefault(User => User.UserName == request.UserLogIn.UserName );

            if ( wantedUser == null )
            {
                throw new Exception("Invalid username");
            }else if(!BCrypt.Net.BCrypt.Verify(request.UserLogIn.Password, wantedUser.Password))
            {
                throw new Exception("invalid password");
            }else
            {
                return Task.FromResult(wantedUser);
            }
           
        }
    }
}
