using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog: AnimalModel
    {
        public override bool LikeToFtech { get; set; } = true;
        public override string Type => "Dog";
    }
}
