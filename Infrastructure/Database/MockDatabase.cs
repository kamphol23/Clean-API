using Domain.Models;
using Domain.Models.Animal;
using Domain.Models.UserModel;

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

        public List<UserModle> listOfAllUsers
        {
           get { return allUsersFromDb; }
           set { allUsersFromDb = value; }
        }


        private static List<UserModle> allUsersFromDb = new()
        {
            new UserModle { Password = "SjöGurka", UserName = "kamphol" }
        };

        private static List<Dog> allDogsFromDb = new()
        {
            new Dog { animalId = Guid.NewGuid(), Name = "Frasse"},
            new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "GetAnimalById"},

        };

        private static List<Cat> allCatsFromDb = new()
        {
            new Cat { animalId = Guid.NewGuid(), Name = "Toffie"},
            new Cat { animalId = new Guid("12345678-1234-5678-1234-567812345623"), Name = "ToBeDeleteTested"}

        };

        private static List<Bird> allBirdsFromDb = new()
        {
            new Bird { animalId = Guid.NewGuid(), Name = "Kalle"},
            new Bird { animalId = new Guid("12345678-1234-5678-1234-567812345622"), Name = "ToBeUpdated"}
        };

        
    };
};
