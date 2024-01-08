using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAnimalById
{
    public class GetAnimalByIdQuery : IRequest<AnimalModel>
    {
        public GetAnimalByIdQuery(Guid animalId) 
        { 
            Id = animalId;
        }

        public Guid Id { get; set; }    
    }
}
