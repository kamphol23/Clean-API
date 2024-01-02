using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public override bool LikesToPlay { get; set; } = true;
        public override string Type => "Cat";
    }
}
