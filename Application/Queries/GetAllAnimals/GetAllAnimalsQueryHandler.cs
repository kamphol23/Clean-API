
using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAllAnimals
{
    public class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, List<AnimalModel>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllAnimalsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<List <AnimalModel>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
        {
            List<AnimalModel> allAnimalsFromMockDb = _mockDatabase.allAnimals;
            return Task.FromResult(allAnimalsFromMockDb);
        }
    }
}
