using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAllAnimals
{
    public class GetAllAnimalsQuery : IRequest<List<AnimalModel>>
    {

    }
}
