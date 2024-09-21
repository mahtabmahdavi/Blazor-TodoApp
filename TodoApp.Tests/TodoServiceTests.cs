using Moq;
using System;
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
        public async Task GetTodoItemsAsync_ShouldReturnItems()
        {
            // Arrange
            var todoItems = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Test 1", IsDone = false },
                new TodoItem { Id = 2, Title = "Test 2", IsDone = true }
            };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(todoItems);

            // Act
            var result = await _service.GetTodoItemsAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Test 1", result[0].Title);
            Assert.AreEqual("Test 2", result[1].Title);
        }

        [TestMethod]
        public async Task AddTodoItemAsync_ShouldAddItem()
        {
            // Arrange
            var newItem = new TodoItem { Id = 3, Title = "New Task", IsDone = false };

            _repositoryMock.Setup(repo => repo.AddAsync(newItem)).Returns(Task.CompletedTask);

            // Act
            await _service.AddTodoItemAsync(newItem);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(newItem), Times.Once);
        }

        [TestMethod]
        public async Task DeleteTodoItemAsync_ShouldDeleteItem()
        {
            // Arrange
            var desiredItem = new TodoItem { Id = 1, Title = "Task to Delete", IsDone = true };

            _repositoryMock.Setup(repo => repo.DeleteAsync(desiredItem.Id)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteTodoItemAsync(desiredItem);

            // Assert
            _repositoryMock.Verify(repo => repo.DeleteAsync(desiredItem.Id), Times.Once);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _service = null;
            _repositoryMock = null;
        }
    }
}