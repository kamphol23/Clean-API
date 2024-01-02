using Domain.Models;
using Domain.Models.Animal;

namespace Infrastructure.Database
{
    public class MockDatabase
    {

        public List<AnimalModel> allAnimals
        {

            get
            {
                List<AnimalModel> combindAnimalsList = new List<AnimalModel>();
                combindAnimalsList.AddRange(listOfAllDogs);
                return combindAnimalsList;
            }

            set
            {
                listOfAllDogs = value.OfType<Dog>().ToList();
            }


        }

        public List<Dog> listOfAllDogs
        {
            get { return allDogsFromDb; }
            set { allDogsFromDb = value; }
        }

        private static List<Dog> allDogsFromDb = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Frasse"},

        };

    };
};
