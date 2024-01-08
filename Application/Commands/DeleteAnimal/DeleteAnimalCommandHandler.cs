using Application.Commands.AddAnimals;
using Domain.Models.Animal;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Commands.DeleteAnimal
{
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, Unit>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteAnimalCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            AnimalModel selectedAnimal = _mockDatabase.allAnimals.FirstOrDefault(animal => animal.animalId == request.Id)!;

            if(selectedAnimal == null)
            {
                throw new ArgumentException("you need to selcet a animal to delete");
            }
            else
            {
                switch(selectedAnimal) 
                {
                    case Dog dogToDelete when _mockDatabase.listOfAllDogs.Contains(dogToDelete):
                        _mockDatabase.listOfAllDogs.Remove(dogToDelete);
                        break;
                    case Cat catToDelete when _mockDatabase.listOfAllCats.Contains(catToDelete):
                        _mockDatabase.listOfAllCats.Remove(catToDelete);
                        break;
                    case Bird birdToDelete when _mockDatabase.listOfAllBirds.Contains(birdToDelete):
                        _mockDatabase.listOfAllBirds.Remove(birdToDelete);
                        break;
                        default:
                        throw new ArgumentException("hej");
                }
            }
           

            return Task.FromResult(Unit.Value);
        }
    }
}
