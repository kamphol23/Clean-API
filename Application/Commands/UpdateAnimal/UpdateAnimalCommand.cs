using Application.Dtos;
using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateAnimal
{
   public class UpdateAnimalCommand : IRequest<AnimalModel>
    {
        public UpdateAnimalCommand(AnimalDto updatedAnimal, Guid id) 
        {
            UpdatedAnimal = updatedAnimal;
            AnimalId = id;
        }

        public AnimalDto UpdatedAnimal { get; set; }
        public Guid AnimalId { get; set;}

    }
}
