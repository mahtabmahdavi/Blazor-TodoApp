using Moq;
using TodoApp.Data.Repositories.Interfaces;
using TodoApp.Services;
using TodoApp.Services.Interfaces;

namespace TodoApp.Tests
{
    [TestClass]
    public class TodoServiceTests
    {
        private Mock<ITodoRepository> _mockRepository;
        private ITodoService _todoService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<ITodoRepository>();
            _todoService = new TodoService(_mockRepository.Object);
        }
    }
}