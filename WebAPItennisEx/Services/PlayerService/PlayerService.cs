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
                        Player_id = p.Player_id,
                        Name_first = p.Name_first,
                        Name_last = p.Name_last,
                        Hand = p.Hand,
                        Dob = p.Dob != null ? p.Dob : null,
                        Ioc = p.Ioc,
                        Height = p.Height != null ? p.Height : null,
                        Wikidata_id = p.Wikidata_id
                    }));
                }

                response = new BaseResponse
                {
                    Status_code = StatusCodes.Status200OK,
                    Current_page = index,
                    Result_count = players.Count,
                    Data = new { players }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    Status_code = StatusCodes.Status500InternalServerError,
                    Data = new { message = $"Internal server error: {ex.Message}" }
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
                    var player = context.Players.Where(p => p.Player_id == id).Select(p => new PlayerDTO {
                        Player_id = p.Player_id,
                        Name_first = p.Name_first,
                        Name_last = p.Name_last,
                        Hand = p.Hand,
                        Dob = p.Dob != null ? p.Dob : null,
                        Ioc = p.Ioc,
                        Height = p.Height != null ? p.Height : null,
                        Wikidata_id = p.Wikidata_id
                    }).FirstOrDefault();

                    if(player != null)
                    {
                        response = new BaseResponse
                        {
                            Status_code = StatusCodes.Status200OK,
                            Data = new { player }
                        };

                        return response;
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            Status_code = StatusCodes.Status404NotFound,
                            Data = new { message = $"Error: Player not found" }
                        };

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    Status_code = StatusCodes.Status500InternalServerError,
                    Data = new { message = $"Internal server error: {ex.Message}" }
                };
                
                return response;
            }
        }

        public BaseResponse Player_GetByName(string name, int index, int amount)
        {
            BaseResponse response;

            try
            {
                List<PlayerDTO> players = new List<PlayerDTO>();

                using (context)
                {
                    context.Players.Where(p => p.Name_last == name).ToList().ForEach(p => players.Add(new PlayerDTO
                    {
                        Player_id = p.Player_id,
                        Name_first = p.Name_first,
                        Name_last = p.Name_last,
                        Hand = p.Hand,
                        Height = p.Height != null ? p.Height : null,
                        Dob = p.Dob != null ? p.Dob : null,
                        Ioc = p.Ioc,
                        Wikidata_id = p.Wikidata_id,
                    }));

                    if(players.Count != 0)
                    {
                        if(players.Count > amount)
                        {
                            players = players.Skip((amount) * index).Take(amount).ToList();
                            response = new BaseResponse
                            {
                                Status_code = StatusCodes.Status200OK,
                                Data = new { players },
                                Current_page = index,
                                Result_count = players.Count,
                            };

                            return response;
                        } else {
                            response = new BaseResponse
                            {
                                Status_code = StatusCodes.Status200OK,
                                Data = new { players },
                                Result_count = players.Count,
                            };

                            return response;
                        }
                    }
                    else
                    {
                        return new BaseResponse
                        {
                            Status_code = StatusCodes.Status404NotFound,
                            Data = new { message = $"Error: Player not found with lastname [ {name} ]" }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Status_code = StatusCodes.Status500InternalServerError,
                    Data = new { message = ex.Message }
                };
            }
        }
    }
}
