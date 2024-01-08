using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAnimalById
{
    public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQuery, AnimalModel>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAnimalByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<AnimalModel> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken) 
        {
            AnimalModel targetedAnimal = _mockDatabase.allAnimals.FirstOrDefault(AnimalModel => AnimalModel.animalId== request.Id)!;
            return Task.FromResult(targetedAnimal);
        }
    }
}
