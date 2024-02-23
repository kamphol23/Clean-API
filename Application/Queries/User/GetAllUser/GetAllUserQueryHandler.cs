using Application.Queries.GettAllUser;
using Domain.Models.UserModel;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAllUser
{
   public class GetAllUserqueryHandler : IRequestHandler< GetAllUserQuery, List<UserModle>>
    {
        private readonly MockDatabase _mockDatabase;

            public GetAllUserqueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<List<UserModle>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            List<UserModle> allUserfromDb = _mockDatabase.listOfAllUsers;
            return Task.FromResult(allUserfromDb);
        }
    }
    
}
