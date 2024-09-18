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
            var todoItems = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Test 1", IsDone = false },
                new TodoItem { Id = 2, Title = "Test 2", IsDone = true }
            };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(todoItems);

            var result = await _service.GetTodoItemsAsync();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Test 1", result[0].Title);
            Assert.AreEqual("Test 2", result[1].Title);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _service = null;
            _repositoryMock = null;
        }
    }
}