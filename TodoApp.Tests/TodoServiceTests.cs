using Moq;
using TodoApp.Data.Repositories.Interfaces;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.Services.Interfaces;

namespace TodoApp.Tests
{
    [TestClass]
    public class TodoServiceTests
    {
        private Mock<ITodoRepository> _repositoryMock;
        private ITodoService _service;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<ITodoRepository>();
            _service = new TodoService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetTodoItems_ShouldReturnItems()
        {
            // Arrange
            var todoItems = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Test 1", IsDone = false },
                new TodoItem { Id = 2, Title = "Test 2", IsDone = true }
            };

            // Act
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(todoItems);

            var result = await _service.GetTodoItemsAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Test 1", result[0].Title);
            Assert.AreEqual("Test 2", result[1].Title);
        }

        [TestMethod]
        public async Task AddTodoItem_ShouldAddItem()
        {
            // Arrange
            var newItem = new TodoItem { Id = 3, Title = "New Task", IsDone = false };

            // Act
            _repositoryMock.Setup(repo => repo.AddAsync(newItem)).Returns(Task.CompletedTask);
            
            await _service.AddTodoItemAsync(newItem);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(newItem), Times.Once);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _service = null;
            _repositoryMock = null;
        }
    }
}