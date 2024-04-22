using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPItennisEx.DTOs.Responses;
using WebAPItennisEx.Services.PlayerService;

namespace WebAPItennisEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        // Endpoints
        /// <summary>
        /// Retrieves the first 100 players from the database
        /// </summary>
        /// <param name="page_index">the pagination index, the default is 1</param>
        /// <param name="amount">the amount of elements for the pagination, the default is 100</param>
        /// <returns>
        /// List<Player>
        /// </returns>
        [HttpGet("list")]
        public BaseResponse PlayersList(int page_index = 1, int amount = 100) // page_index e quantity sono presi dalla queryString della chiamata
        {
            return playerService.Player_GetAll(page_index, amount);
        }

        /// <summary>
        /// Retrieves the data of the player with the the specified player_id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Player
        /// </returns>
        [HttpGet("/details/{id}")]
        public BaseResponse Player(int id)
        {
            return playerService.Player_GetById(id);
        }

        /// <summary>
        /// Retrieves the list of player matching with the lastname give by params
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// List<Player>
        /// </returns>
        [HttpGet("{name}")]
        public BaseResponse Player(string name) {
            return playerService.Player_GetByName(name);
        }
    }
}
