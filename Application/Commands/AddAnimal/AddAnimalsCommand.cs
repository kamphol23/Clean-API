using Application.Dtos;
using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddAnimals
{
    public class AddAnimalsCommand : IRequest<AnimalModel>
    {
        public AddAnimalsCommand(AnimalDto newAnimal) 
        {
            NewAnimal = newAnimal;
        }
        public AnimalDto NewAnimal { get; }
    }
}
