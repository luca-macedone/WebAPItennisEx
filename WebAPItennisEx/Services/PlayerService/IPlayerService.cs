using WebAPItennisEx.DTOs.Responses;

namespace WebAPItennisEx.Services.PlayerService
{
    public interface IPlayerService
    {
        BaseResponse Player_GetAll(int page, int amount);

        BaseResponse Player_GetById(int id);

        BaseResponse Player_GetByName(string name, int index, int amount);
    }
}
