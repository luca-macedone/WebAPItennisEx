using System.Security.Cryptography.X509Certificates;
using WebAPItennisEx.DTOs;
using WebAPItennisEx.DTOs.Responses;

namespace WebAPItennisEx.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDBContext context;

        public PlayerService(ApplicationDBContext applicationDBContext)
        {
            context = applicationDBContext;

        }

        public BaseResponse Player_GetAll(int index, int amount)
        {
            BaseResponse response;

            try
            {
                List<PlayerDTO> players = new List<PlayerDTO>();

                using (context)
                {
                    context.Players.Skip((amount - 1) * index).Take(amount).ToList().ForEach(p => players.Add(new PlayerDTO {
                        player_id = p.player_id,
                        name_first = p.name_first,
                        name_last = p.name_last,
                        hand = p.hand,
                        dob = p.dob != null ? p.dob : null,
                        ioc = p.ioc,
                        height = p.height != null ? p.height : null,
                        wikidata_id = p.wikidata_id
                    }));
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { players }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = $"Internal server error: {ex.Message}" }
                };

                return response;
            }
        }

        public BaseResponse Player_GetById(int id)
        {
            BaseResponse response;

            try
            {
                using (context)
                {
                    var player = context.Players.Where(p => p.player_id == id).Select(p => new PlayerDTO {
                        player_id = p.player_id,
                        name_first = p.name_first,
                        name_last = p.name_last,
                        hand = p.hand,
                        dob = p.dob != null ? p.dob : null,
                        ioc = p.ioc,
                        height = p.height != null ? p.height : null,
                        wikidata_id = p.wikidata_id
                    }).FirstOrDefault();

                    if(player != null)
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { player }
                        };

                        return response;
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status404NotFound,
                            data = new { message = $"Error: Player not found" }
                        };

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = $"Internal server error: {ex.Message}" }
                };
                
                return response;
            }
        }

        public BaseResponse Player_GetByName(string name)
        {
            BaseResponse response;

            try
            {
                List<PlayerDTO> players = new List<PlayerDTO>();

                using (context)
                {
                    context.Players.Where(p => p.name_last == name).ToList().ForEach(p => players.Add(new PlayerDTO
                    {
                        player_id = p.player_id,
                        name_first = p.name_first,
                        name_last = p.name_last,
                        hand = p.hand,
                        height = p.height != null ? p.height : null,
                        dob = p.dob != null ? p.dob : null,
                        ioc = p.ioc,
                        wikidata_id = p.wikidata_id,
                    }));

                    if(players.Count != 0)
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { players }
                        };

                        return response;
                    }
                    else
                    {
                        return new BaseResponse
                        {
                            status_code = StatusCodes.Status404NotFound,
                            data = new { message = $"Error: Player not found with lastname [ {name} ]" }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = ex.Message }
                };
            }
        }
    }
}
