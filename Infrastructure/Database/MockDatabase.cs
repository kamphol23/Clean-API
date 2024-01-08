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
                combindAnimalsList.AddRange(listOfAllCats);
                combindAnimalsList.AddRange(listOfAllBirds);
                return combindAnimalsList;
            }

            set
            {
                listOfAllDogs = value.OfType<Dog>().ToList();
                listOfAllCats = value.OfType<Cat>().ToList();
                listOfAllBirds = value.OfType<Bird>().ToList();
            }


        }

        public List<Dog> listOfAllDogs
        {
            get { return allDogsFromDb; }
            set { allDogsFromDb = value; }
        }
        public List<Cat> listOfAllCats
        {
            get { return allCatsFromDb; }
            set { allCatsFromDb = value; }
        }
        public List<Bird> listOfAllBirds
        {
            get { return allBirdsFromDb; }
            set { allBirdsFromDb = value; }
        }


        private static List<Dog> allDogsFromDb = new()
        {
            new Dog { animalId = Guid.NewGuid(), Name = "Frasse"},

        };

        private static List<Cat> allCatsFromDb = new()
        {
            new Cat { animalId = Guid.NewGuid(), Name = "Toffie"},

        };

        private static List<Bird> allBirdsFromDb = new()
        {
            new Bird { animalId = Guid.NewGuid(), Name = "Kalle"},
        };


    };
};
