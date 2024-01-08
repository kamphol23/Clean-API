namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        public Guid animalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual string? Type { get; }
        public virtual bool CanFly { get; set; }
        public virtual bool LikesToPlay { get; set; }
        public virtual bool LikeToFtech { get; set; }
    }
}
