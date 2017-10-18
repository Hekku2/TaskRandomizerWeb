using Backend.Models;
using DataStorage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Optional.Unsafe;
using Optional.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStorage.DataObjects;

namespace Backend.Controllers
{
    /// <summary>
    /// Game Session API (starting, stopping, joining, listing)
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GameSessionController : Controller
    {
        private readonly IGameSessionStorage _gameSessionStorage;
        private readonly IGameStorage _gameStorage;

        public GameSessionController(IGameSessionStorage gameSessionStorage, IGameStorage gameStorage)
        {
            _gameSessionStorage = gameSessionStorage;
            _gameStorage = gameStorage;
        }

        /// <summary>
        /// Returns all games
        /// </summary>
        /// <returns>All games</returns>
        [HttpGet]
        public IEnumerable<GameSessionModel> GetAll()
        {
            return _gameSessionStorage.GetAll().Select(CreateGameSessionModel).ToList();
        }

        private GameSessionModel CreateGameSessionModel(GameSession session)
        {
            return new GameSessionModel
            {
                Id = session.Id,
                GameName = session.GameName
            };
        }

        /// <summary>
        /// Starts a game session with given settings.
        /// 
        /// Starting fails if given game doesn't exist.
        /// </summary>
        /// <param name="settings">Session settings</param>
        /// <returns>ID of created session. Can be used for navigating to session.</returns>
        [HttpPost("start")]
        public string StartSession(SessionSettingsModel settings)
        {
            var game = _gameStorage
                .GetSingle(settings.GameId)
                .ValueOrFailure($"No game exists with ID {settings.GameId}");

            return _gameSessionStorage.CreateSession(game, new List<Errand>()).ToString();   
        }
    }
}
