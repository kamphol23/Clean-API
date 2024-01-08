using Application.Commands.AddAnimals;
using Application.Commands.DeleteAnimal;
using Application.Commands.UpdateAnimal;
using Application.Dtos;
using Application.Queries.GetAllAnimals;
using Application.Queries.GetAnimalById;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Test.AnimalTest
{
    [TestFixture]

    public class AnimalTests
    {
        private MockDatabase _mockDatabase;
        private GetAllAnimalsQueryHandler _getAllAnimalsHandler;
        private GetAnimalByIdQueryHandler _getAnimalByIdHandler;
        private DeleteAnimalCommandHandler _deleteAnimalhandler;
        private AddAnimalsCommandHandler _addAnimalsHandler;
        private UpdateAnimalCommandHandler _updateAnimalHandler;


        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _getAnimalByIdHandler = new GetAnimalByIdQueryHandler(_mockDatabase);
            _getAllAnimalsHandler = new GetAllAnimalsQueryHandler(_mockDatabase);
            _deleteAnimalhandler = new DeleteAnimalCommandHandler(_mockDatabase);
            _addAnimalsHandler = new AddAnimalsCommandHandler(_mockDatabase);
            _updateAnimalHandler = new UpdateAnimalCommandHandler(_mockDatabase);
        }

        [Test] //GET Valid Id
        public async Task Handle_ValidAnimalId()
        {
            var animalId = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new GetAnimalByIdQuery(animalId);

            var result = await _getAnimalByIdHandler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.That(result.animalId, Is.EqualTo(animalId));
        }

        [Test] //GET Invalid ID
        public async Task Handle_InvalidAnimalId()
        {
            var invalidAnimalId = Guid.NewGuid();

            var query = new GetAnimalByIdQuery(invalidAnimalId);

            var result = await _getAnimalByIdHandler.Handle(query, CancellationToken.None);

            Assert.IsNull(result);
        }

        [Test] //GET ALL
        public async Task Handle_GetAllTheAnimalFormDb()
        {
            var expextedAnimalAmount = _mockDatabase.allAnimals.Count;
            var query = new GetAllAnimalsQuery();

            var allAnimals = await _getAllAnimalsHandler.Handle(query, CancellationToken.None); 
            Assert.IsNotNull(allAnimals);
            Assert.AreEqual(expextedAnimalAmount, allAnimals.Count);
        }

        [Test]// DELETE
        public async Task Handle_DeleteOfAnimal_WithValidID()
        {
            var animalId = new Guid("12345678-1234-5678-1234-567812345623");
            var query = new DeleteAnimalCommand(animalId);

            await _deleteAnimalhandler.Handle(query, CancellationToken.None);
            var result = await _getAnimalByIdHandler.Handle(new GetAnimalByIdQuery(animalId), CancellationToken.None);

            Assert.IsNull(result);
        }

        [Test]//POST
        public async Task Handle_AddAnimal_WithValidData()
        {
            var animalDto = new AnimalDto { Name = "Melker", Type = "Cat"};
            var query = new AddAnimalsCommand(animalDto);


            var newAnimal = await _addAnimalsHandler.Handle(query, CancellationToken.None);

            Assert.IsNotNull(newAnimal);
            Assert.AreEqual(animalDto.Type, newAnimal.Type);
            Assert.AreEqual(animalDto.Name, newAnimal.Name);

        }

        [Test]//PUT
        public async Task Handle_AnimalUpdate_WithValidId()
        {
            var animalId = new Guid("12345678-1234-5678-1234-567812345622");
            var updateAnimalTo = new AnimalDto { Name = "NameHasBenChanged", Type = "Dog" };
            var query = new UpdateAnimalCommand(updateAnimalTo, animalId);


            var updatedTestAnimal = await _updateAnimalHandler.Handle(query, CancellationToken.None);   


            Assert.IsNotNull(updatedTestAnimal);
            Assert.AreEqual(updateAnimalTo.Type, updatedTestAnimal.Type);
            Assert.AreEqual(updateAnimalTo.Name, updatedTestAnimal.Name);
            Assert.Contains(updatedTestAnimal, _mockDatabase.allAnimals);

        }
       
    }
}
