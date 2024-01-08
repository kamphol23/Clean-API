using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateAnimal
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpDateAnimalCommand, AnimalModel>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateAnimalCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<AnimalModel> Handle(UpDateAnimalCommand request, CancellationToken cancellationToken)
        {
            AnimalModel animalToUpdate = _mockDatabase.allAnimals.FirstOrDefault(AnimalModel => AnimalModel.animalId == request.AnimalId)!;

            if (animalToUpdate == null)
            {
                return Task.FromResult<AnimalModel>(null!);
            }

         
            animalToUpdate.CanFly = request.UpdatedAnimal.CanFly;
            animalToUpdate.LikesToPlay = request.UpdatedAnimal.LikesToPlay;
            animalToUpdate.LikeToFtech = request.UpdatedAnimal.LikeToFtech;
    


            if(!string.Equals(animalToUpdate.Type, request.UpdatedAnimal.Type, StringComparison.OrdinalIgnoreCase))
            {
                RemoveAnimalFromList(animalToUpdate);
                AnimalModel updatdeAnimal = CreateUpdatedAnimal(request, animalToUpdate);
                updatdeAnimal.animalId = animalToUpdate.animalId;
                AddAnimalToList(updatdeAnimal);
                _mockDatabase.allAnimals.Remove(animalToUpdate);

                return Task.FromResult(updatdeAnimal);
            }
            return Task.FromResult(animalToUpdate);

           
        }


        private AnimalModel CreateUpdatedAnimal(UpDateAnimalCommand request, AnimalModel existingAnimal)
        {

            string? updatedType = string.IsNullOrEmpty(request.UpdatedAnimal.Type) || request.UpdatedAnimal.Type == "string" ? existingAnimal.Type : request.UpdatedAnimal.Type;
            AnimalModel updatedAnimal = updatedType?.ToLower() switch
            {

                "dog" => new Dog(),
                "cat" => new Cat(),
                "bird" => new Bird(),
                _ => new AnimalModel()

            };

            updatedAnimal.Name = string.IsNullOrEmpty(request.UpdatedAnimal.Name) ? existingAnimal.Name : request.UpdatedAnimal.Name;

            return updatedAnimal;
        }

        private void RemoveAnimalFromList(AnimalModel animalType)
        {
            switch (animalType)
            {
                case Dog dog when _mockDatabase.listOfAllDogs.Contains(dog) :
                    _mockDatabase.listOfAllDogs.Remove(dog);
                    break;
                case Cat cat when _mockDatabase.listOfAllCats.Contains(cat) :
                    _mockDatabase.listOfAllCats.Remove(cat);
                    break;
                case Bird bird when _mockDatabase.listOfAllBirds.Contains(bird) :
                    _mockDatabase.listOfAllBirds.Remove(bird);
                    break;
            }
        }

        private void AddAnimalToList(AnimalModel animal)
        {
            switch (animal)
            {
                case Dog dog: 
                    _mockDatabase.listOfAllDogs.Add(dog); 
                    break;
                case Cat cat:
                    _mockDatabase.listOfAllCats.Add(cat);
                    break;
                case Bird bird:
                    _mockDatabase.listOfAllBirds.Add(bird);
                    break;
                
            }
        }

      
    }

}
