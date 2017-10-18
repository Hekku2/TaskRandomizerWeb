using Backend.Controllers;
using DataStorage.Interfaces;
using DataStorage.DataObjects;
using NUnit.Framework;
using NSubstitute;
using System.Linq;

namespace BackendUnitTests.Controllers
{
    [TestFixture]
    public class GameControllerTests : BaseControllerTests<GameController>
    {
        private IGameStorage _gameStorage;

        protected override void OnSetup()
        {
            _gameStorage = Substitute.For<IGameStorage>();
            Controller = new GameController(_gameStorage);
        }

        [Test]
        public void Test_GetAll_ReturnsAllGames()
        {
            var items = Enumerable.Range(1, 20).Select(i => new Game()
            {
                Id = i,
                Name = "game " + i
            }).ToList();
            _gameStorage.GetAll().Returns(items);

            var result = Controller.GetAll();
            Assert.NotNull(result);

            Assert.AreEqual(items.Count, result.Count());

            foreach (var item in items)
            {
                Assert.IsTrue(
                    result.Any(actual => 
                        actual.Id == item.Id &&
                        actual.Name == item.Name));
            }
        }
    }
}
