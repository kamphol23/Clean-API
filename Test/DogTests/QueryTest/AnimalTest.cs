using Application.Queries.Dogs.GetById;
using Application.Commands.Dogs.DeleteDog;
using Infrastructure.Database;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class AnimalTest
    {
        private GetDogByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;
        private DeleteDogCommandHandler _deleteHandler;  

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetDogByIdQueryHandler(_mockDatabase);
            _deleteHandler = new DeleteDogCommandHandler(_mockDatabase);

        }

        [Test]
        public async Task Handle_ValidId_RemoveAnimalFromDatabase()
        {
            // Arrange
            var animalIdToDelete = new Guid("12345678-1234-5678-1234-567812345678");

            var deleteDog = new DeleteDogByIdCommand(animalIdToDelete);

            // Act
            await _deleteHandler.Handle(deleteDog, CancellationToken.None);
            var IsDogDeleted = await _handler.Handle(new GetDogByIdQueryHandler(animalIdToDelete), CancellationToken.None);

            // Assert
            Assert.NotNull(IsDogDeleted);
            
        }

 
    }
}
