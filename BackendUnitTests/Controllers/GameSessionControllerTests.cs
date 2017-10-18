using Backend.Controllers;
using DataStorage.Interfaces;
using DataStorage.DataObjects;
using NUnit.Framework;
using NSubstitute;
using System.Linq;
using Optional;
using Optional.Unsafe;
using Backend.Models;
using System;
using System.Collections.Generic;

namespace BackendUnitTests.Controllers
{
    [TestFixture]
    public class GameSessionControllerTests : BaseControllerTests<GameSessionController>
    {
        private IGameSessionStorage _mockGameSessionStorage;
        private IGameStorage _mockGameStorage;

        protected override void OnSetup()
        {
            _mockGameSessionStorage = Substitute.For<IGameSessionStorage>();
            _mockGameStorage = Substitute.For<IGameStorage>();
            Controller = new GameSessionController(_mockGameSessionStorage, _mockGameStorage);
        }

        #region GetAll

        [Test]
        public void Test_GetAll_ReturnsNothingIfThereAreNoGames()
        {
            var result = Controller.GetAll();
            Assert.NotNull(result);
            Assert.IsFalse(result.Any());
        }

        [Test]
        public void Test_GetAll_ReturnsAllGames()
        {
            var items = Enumerable.Range(1, 20).Select(i => new GameSession
            {
                Id = Guid.NewGuid(),
                GameName = "name of the game " + i
            }).ToList();
            _mockGameSessionStorage.GetAll().Returns(items);

            var result = Controller.GetAll();
            Assert.NotNull(result);

            Assert.AreEqual(items.Count, result.Count());

            foreach (var item in items)
            {
                Assert.IsTrue(
                    result.Any(actual =>
                        actual.Id == item.Id &&
                        actual.GameName == item.GameName));
            }
        }

        #endregion

        #region StartSession
        [Test]
        public void Test_StartSession_ReturnsIdForSession()
        {
            var settings = new SessionSettingsModel
            {
                GameId = 8887
            };

            var game = new Game() { Id = settings.GameId };
            _mockGameStorage.GetSingle(game.Id).Returns(game.Some());

            var guid = Guid.NewGuid();
            _mockGameSessionStorage.CreateSession(game, Arg.Any<IEnumerable<Errand>>()).Returns(guid);

            var result = Controller.StartSession(settings);
            Assert.AreEqual(guid.ToString(), result);
        }

        [Test]
        public void Test_StartSession_ThrowsOptionValueMissingExceptionWhenGamesIsNotFound()
        {
            var settings = new SessionSettingsModel
            {
                GameId = 666
            };
            var ex = Assert.Throws<OptionValueMissingException>(() => Controller.StartSession(settings));
            Assert.AreEqual("No game exists with ID 666", ex.Message);
        }

        #endregion
    }
}
