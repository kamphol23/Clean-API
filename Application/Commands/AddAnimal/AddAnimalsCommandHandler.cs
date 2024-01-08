
using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddAnimals
{
    internal class AddAnimalsCommandHandler : IRequestHandler<AddAnimalsCommand, AnimalModel>
    {
        private readonly MockDatabase _mockDatabase;

        public AddAnimalsCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<AnimalModel> Handle(AddAnimalsCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.NewAnimal.Type) || string.IsNullOrEmpty(request.NewAnimal.Name))
            {
                throw new ArgumentException("Animal type or name are not given");
            }

            AnimalModel newAnimal;
            switch (request.NewAnimal.Type.ToLower())
            {
                case "dog":
                    newAnimal = new Dog() { LikeToFtech = request.NewAnimal.LikeToFtech };
                    _mockDatabase.listOfAllDogs.Add((Dog)newAnimal);
                    break;
                case "cat":
                    newAnimal = new Cat() { LikesToPlay = request.NewAnimal.LikesToPlay };
                    _mockDatabase.listOfAllCats.Add((Cat)newAnimal);
                    break;
                case "bird": 
                    newAnimal = new Bird() { CanFly = request.NewAnimal.CanFly };
                    _mockDatabase.listOfAllBirds.Add((Bird)newAnimal);
                    break;
                default:
                    newAnimal = new AnimalModel();
                    break;
            }

            newAnimal.animalId = Guid.NewGuid();

            newAnimal.Name = request.NewAnimal.Name;

            return Task.FromResult(newAnimal);
        }
    }
}

